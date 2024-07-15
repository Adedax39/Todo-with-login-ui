using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigureServices).Assembly);
            services.AddValidatorsFromAssembly(typeof(ConfigureServices).Assembly);
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly);
                ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder
                        .WithOrigins("http://localhost:3000") // Add the React app URL
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            return services;
        }
    }

}