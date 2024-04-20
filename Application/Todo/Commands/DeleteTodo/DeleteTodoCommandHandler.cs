using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Todo.Commands.DeleteTodo;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand,int>
{
    private readonly ITodoRepository _repository;
    private readonly IMapper _mapper;

    public DeleteTodoCommandHandler(ITodoRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.TodoId);
    }
}