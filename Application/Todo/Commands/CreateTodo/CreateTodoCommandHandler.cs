using Application.Todo.Queries.GetTodos;
using AutoMapper;
using Domain.Repository;
using MediatR;


namespace Application.Todo.Commands.CreateTodo;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand,TodoVm>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public CreateTodoCommandHandler(ITodoRepository todoRepository,IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }
    public async Task<TodoVm> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todoEntity = new Domain.Entity.Todo() { Task = request.Task, TaskActivation = request.TaskActivation, DateOnly = request.DateOnly,RegisterId = request.RegisterId};
        var todo = await _todoRepository.CreateAsync(todoEntity);
        var todolist = _mapper.Map<TodoVm>(todo);
        return todolist;
    }
}