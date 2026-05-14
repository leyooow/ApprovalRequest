using ApprovalRequest.Application.Interfaces.Repositories;
using ApprovalRequest.Infrastructure.Persistence;
using ApprovalRequest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ApprovalRequest.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("ApprovalSystemDB")));


        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        return services;
    }
}