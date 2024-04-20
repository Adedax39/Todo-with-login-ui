using Application.Todo.Queries.GetTodos;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Todo.Queries.GetTodoById;

public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery,TodoVm>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public GetTodoByIdQueryHandler(ITodoRepository todoRepository,IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }
    
    public async Task<TodoVm> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetIdAsync(request.TodoId);
        return _mapper.Map<TodoVm>(todo);
    }
}