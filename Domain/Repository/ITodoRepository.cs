using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Repository
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllTasksAsync();
        Task<Todo> GetIdAsync(int id);
        Task<Todo> CreateAsync(Todo todo);
        Task<int> UpdateAsync(int id, Todo todo);
        Task<int> DeleteAsync(int id);

    }
}
