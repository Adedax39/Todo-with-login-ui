using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Register.Commands.CreateRegister;

public class CreateRegisterCommandHandler : IRequestHandler<CreateRegisterCommand, RegisterVm>
{
    private readonly IRegisterRepository _registerRepository;
    private readonly IMapper _mapper;
    private readonly PasswordHasher _passwordHasher;


    public CreateRegisterCommandHandler(IRegisterRepository registerRepository, IMapper mapper,PasswordHasher passwordHasher)
    {
        _registerRepository = registerRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<RegisterVm> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
    {
        PasswordHasher passwordHasher = new PasswordHasher();
        string hashedPassword = passwordHasher.HashPassword(request.Password);
        var registerEntity = new Domain.Entity.Register()
            { UserName = request.UserName, EmailAddress = request.EmailAddress, Password = hashedPassword };
        var register = await _registerRepository.CreateAccAsync(registerEntity);
        var registered = _mapper.Map<RegisterVm>(register);

        return registered;
    }
}