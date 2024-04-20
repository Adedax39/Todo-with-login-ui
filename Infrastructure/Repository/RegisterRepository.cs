using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class RegisterRepository : IRegisterRepository
{
    private readonly TodoDbContext _todoDbContext;

    public RegisterRepository(TodoDbContext todoDbContext)
    {
        _todoDbContext = todoDbContext;
    }

    public async Task<Register> CreateAccAsync(Register register)
    {
        await _todoDbContext.Registers.AddAsync(register);
        await _todoDbContext.SaveChangesAsync();
        return register;
    }
}