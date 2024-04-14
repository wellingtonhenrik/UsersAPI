using Microsoft.Extensions.DependencyInjection;
using UserApi.Domain.Interfaces.Repositories;
using UserApi.Domain.Interfaces.Services;
using UserApi.Domain.Services;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Application.Services;
using UsersApi.Infra.Data.Repositories;

namespace UserAPI.Infra.IoC.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<IUserAppService, UserAppService>();
        services.AddTransient<IAuthAppService, AuthAppService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}