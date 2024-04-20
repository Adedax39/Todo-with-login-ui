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