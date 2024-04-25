using Domain.Entity;

namespace Domain.Repository;

public interface IRegisterRepository
{
    Task<Register> CreateAccAsync(Register register);
}

public interface IPasswordGenerator
{
    string GenerateRandomPassword();
}
public interface IEmailService
{
    Task SendEmailAsync(string email, string password);

}