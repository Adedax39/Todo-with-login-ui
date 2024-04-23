using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Register.Commands.CreateRegister;

public class CreateRegisterCommandHandler : IRequestHandler<CreateRegisterCommand,RegisterVm>
{
    private readonly IRegisterRepository _registerRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordGenerator passwordGenerator;

    public CreateRegisterCommandHandler(IRegisterRepository registerRepository,IMapper mapper,IPasswordGenerator passwordGenerator)
    {
        _registerRepository = registerRepository;
        _mapper = mapper;
        this.passwordGenerator = passwordGenerator;
    }

    public async Task<RegisterVm> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
    {
        string randomPassword = this.passwordGenerator.GenerateRandomPassword();
        var registerEntity = new Domain.Entity.Register() { UserName = request.UserName,EmailAddress = request.EmailAddress,Password = randomPassword};
        var register = await _registerRepository.CreateAccAsync(registerEntity);
        var registered = _mapper.Map<RegisterVm>(register);
        return registered;
    }
}