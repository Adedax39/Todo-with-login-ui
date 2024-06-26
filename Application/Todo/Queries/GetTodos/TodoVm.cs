using Application.Common.Mappings;
using Application.Register.Commands.CreateRegister;
using Application.Todo.Queries.GetTodoById;
using Domain.Enums;
using MediatR;

namespace Application.Todo.Queries.GetTodos;

public class TodoVm : IMapFrom<Domain.Entity.Todo>
{
    public int Id { get; set; }
    public string? Task { get; set; }
    public TaskActivation TaskActivation { get; set; }
    public DateTime DateOnly { get; set; }
    public int RegisterId { get; set; }
    public RegisterVm Register { get; set; }
}