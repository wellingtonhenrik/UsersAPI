using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.LogBee;

namespace UserAPI.Infra.IoC.Extensions;

public static class SerilogExtension
{
    public static IServiceCollection AddSerilogConfig(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddHttpContextAccessor();
        service.AddSerilog((services, lc) => lc
            .WriteTo.LogBee(new LogBeeApiKey(
                    configuration["SerilogSettings:LogBee.OrganizationId"]!,
                   configuration["SerilogSettings:LogBee.ApplicationId"]!,
                    configuration["SerilogSettings:LogBee.ApiUrl"]!
                ),
                services
            ));

        return service;
    }
}