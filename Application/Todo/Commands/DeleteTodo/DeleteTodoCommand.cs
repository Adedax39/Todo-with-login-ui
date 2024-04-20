using Application.Todo.Queries.GetTodos;
using MediatR;

namespace Application.Todo.Commands.DeleteTodo;

public class DeleteTodoCommand : IRequest<int>
{
    public int TodoId { get; set; }
}