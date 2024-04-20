using Application.Todo.Queries.GetTodos;
using MediatR;

namespace Application.Todo.Queries.GetTodoById;

public class GetTodoByIdQuery : IRequest<TodoVm>
{
    public int TodoId { get; set; }
}