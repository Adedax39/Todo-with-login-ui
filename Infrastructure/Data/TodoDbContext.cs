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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasOne(b => b.Register)
            .WithMany(a => a.Todos)
            .HasForeignKey(b => b.RegisterId);
    }

}