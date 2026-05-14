using ApprovalRequest.Application.Interfaces.Services;
using ApprovalRequest.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.DepenedencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));


        return services;
    }
}