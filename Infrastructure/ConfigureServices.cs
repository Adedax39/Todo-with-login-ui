using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Repository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static Task<IServiceCollection> AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyConnectionString") ??
                    throw new InvalidOperationException("Connection string not found")); ;
            });

            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient<IRegisterRepository, RegisterRepository>();
            services.AddScoped<IPasswordGenerator, PasswordRepository>();
            services.AddTransient<IEmailService>(sp => new PapercutEmailService("127.0.0.1", 25));
            services.AddScoped<PasswordHasher>();

            
            return Task.FromResult(services);
        }
    }
}
