using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Register.Commands.CreateRegister;

public class CreateRegisterCommandHandler : IRequestHandler<CreateRegisterCommand,RegisterVm>
{
    private readonly IRegisterRepository _registerRepository;
    private readonly IMapper _mapper;

    public CreateRegisterCommandHandler(IRegisterRepository registerRepository,IMapper mapper)
    {
        _registerRepository = registerRepository;
        _mapper = mapper;
    }

    public async Task<RegisterVm> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
    {
        var registerEntity = new Domain.Entity.Register() { UserName = request.UserName,EmailAddress = request.EmailAddress};
        var register = await _registerRepository.CreateAccAsync(registerEntity);
        var registered = _mapper.Map<RegisterVm>(register);
        return registered;
    }
}