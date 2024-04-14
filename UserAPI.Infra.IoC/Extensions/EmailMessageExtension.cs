using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersAPI.Infra.Messages.Services;
using UsersAPI.Infra.Messages.Settings;

namespace UserAPI.Infra.IoC.Extensions;

public static class EmailMessageExtension
{
    public static IServiceCollection AddEmailMessage(this IServiceCollection service, IConfiguration configuration)
    {
        service.Configure<EmailMessageSetings>(configuration.GetSection("EmailMessageSetings"));
        service.AddTransient<EmailMessageService>();
        return service;
    } 
}