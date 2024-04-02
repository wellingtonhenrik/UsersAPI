﻿using Microsoft.Extensions.DependencyInjection;

namespace UserAPI.Infra.IoC.Extensions;

public static class AutoMapperExtension
{
    public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}