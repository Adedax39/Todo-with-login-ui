using Application.Todo.Queries.GetTodos;
using Domain.Enums;
using MediatR;

namespace Application.Todo.Commands.UpdateTodo;

public class UpdateTodoCommand : IRequest<int>, IRequest<List<TodoVm>>
{
    public int Id { get; set; }
    public string? Task { get; set; }
    public TaskActivation TaskActivation { get; set; }
    public DateTime DateOnly { get; set; }
}