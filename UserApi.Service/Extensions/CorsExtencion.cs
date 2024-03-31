namespace UsersAPI.Extensions;

public static class CorsExtencion
{
    private static string _policyName = "DefaultPolicy";
    
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(s => s.AddPolicy(_policyName, builder =>
        {
            builder
                //qualquer dominio pode acessar a api
                .AllowAnyOrigin()
                //qualquer método (POST, PUT, DELETE, GET etc) pode ser acessado)
                .AllowAnyMethod()
                //qualquer parametro de cabeçalho de requisição pode ser enviado
                .AllowAnyHeader();

        }));

        return services;
    }
    public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
    {
        app.UseCors(_policyName);
        return app;
    }
}