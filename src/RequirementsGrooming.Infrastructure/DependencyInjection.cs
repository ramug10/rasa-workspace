using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequirementsGrooming.Application.Contracts;
using RequirementsGrooming.Infrastructure.Data;
using RequirementsGrooming.Infrastructure.Repositories;

namespace RequirementsGrooming.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString = "Data Source=requirements-grooming.db";
        }

        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IRequirementRepository, RequirementRepository>();
        return services;
    }
}
