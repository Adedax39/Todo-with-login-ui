using Application.Todo.Queries.GetTodos;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Todo.Commands.UpdateTodo;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, int>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var updateTodoEntity = new Domain.Entity.Todo()
        {
            Id = request.Id,
            Task = request.Task, 
            TaskActivation = request.TaskActivation, 
            DateOnly = request.DateOnly
        };
        var todo = await _todoRepository.UpdateAsync(request.Id, updateTodoEntity);
        return todo;
    }
}