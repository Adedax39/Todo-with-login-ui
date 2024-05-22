using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _todoDbContext;

        public TodoRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        public async Task<List<Todo>> GetAllTasksAsync()
        {
            return await _todoDbContext.Todos
                .Include(t => t.Register)
                .ToListAsync();
        }

        public async Task<Todo> GetIdAsync(int id)
        {
            return await _todoDbContext.Todos.AsNoTracking()
                .FirstOrDefaultAsync(TodoDbContext => TodoDbContext.Id == id);
        }

        public async Task<Todo> CreateAsync(Todo todo)
        { 
            await _todoDbContext.Todos.AddAsync(todo);
          await _todoDbContext.SaveChangesAsync();
          return todo;
        }

        public async Task<int> UpdateAsync(int id, Todo todo)
        {
            var existingTodo = _todoDbContext.Todos
                .FirstOrDefault(model => model.Id == id);
            if (existingTodo != null)
            {
                existingTodo.Task = todo.Task;
                existingTodo.TaskActivation = todo.TaskActivation;
                existingTodo.DateOnly = todo.DateOnly;
                _todoDbContext.Todos.Update(existingTodo);
                return await _todoDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var todo = _todoDbContext.Todos
                .FirstOrDefault(model => model.Id == id);
            if (todo != null)
            {
                _todoDbContext.Todos.Remove(todo);
                return await _todoDbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
