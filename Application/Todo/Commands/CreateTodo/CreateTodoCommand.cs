using Application.Todo.Queries.GetTodos;
using Domain.Enums;
using MediatR;

namespace Application.Todo.Commands.CreateTodo;

public class CreateTodoCommand : IRequest<TodoVm>
{
    public string? Task { get; set; }
    public TaskActivation TaskActivation { get; set; }
    public DateTime DateOnly { get; set; }
   
    public int RegisterId { get; set; }
}