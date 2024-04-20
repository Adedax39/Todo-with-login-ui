using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Register> Registers { get; set; }

}