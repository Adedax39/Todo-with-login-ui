using MediatR;

namespace Application.Register.Commands.CreateRegister;

public class CreateRegisterCommand : IRequest<RegisterVm>
{
    public string UserName { get; set; } = "Lasath";
    public string EmailAddress { get; set; } = "lasathrathnayake@gmail.com";
    public string Password { get; set; }


}