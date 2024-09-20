using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Job.Hangfire.Backend.Application.Models.Request;
using Job.Hangfire.Backend.Application.Services;
using Job.Hangfire.Backend.Application.Services.Interfaces;
using Job.Hangfire.Backend.Application.Validators;
using Job.Hangfire.Backend.Domain.Entities;
using Job.Hangfire.Backend.Infra.Data;
using Job.Hangfire.Backend.Infra.Data.Repository;
using Job.Hangfire.Backend.Infra.Data.Repository.Interfaces;

namespace Job.Hangfire.Backend.Infra.IoC;

[ExcludeFromCodeCoverage]
public static class IoCServiceExtension
{
    public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureDbContext(services, configuration);
        
        services.AddScoped<IGenericRepository<EmailEntity>, GenericRepository<EmailEntity>>();
        services.AddScoped<IGenericRepository<EmailLogEntity>, GenericRepository<EmailLogEntity>>();
        
        services.AddScoped<IEmailService, EmailService>();
        
        services.AddScoped<IValidator<EmailRequest>, EmailRequestValidator>();
    }

    private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });
    }
}
