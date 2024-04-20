using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Todo.Queries.GetTodos;

public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery,List<TodoVm>>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public GetTodoQueryHandler(ITodoRepository todoRepository,IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }
    public async Task<List<TodoVm>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.GetAllTasksAsync();
        var todolist = _mapper.Map<List<TodoVm>>(todos);
        return todolist;
    }
}