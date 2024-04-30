using Application.Common.Mappings;

namespace Application.Register.Commands.CreateRegister;

public class RegisterVm : IMapFrom<Domain.Entity.Register>
{
    public int Id { get; set; }
    public string UserName { get; set; } = "Lasath";
    public string EmailAddress { get; set; } = "lasathrathnayake@gmail.com";
    public string? Password { get; set; }


}