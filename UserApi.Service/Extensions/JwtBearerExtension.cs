using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace UsersAPI.Extensions;

public static class JwtBearerExtension
{
    public static IServiceCollection AddJwtBearer(this IServiceCollection services)
    {
        //Definindo a politica de autenticação
        services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //Definindo as preferencias para autenticação com JWT
            .AddJwtBearer(options =>
            {
                //definindo as preferencias para autenticação com TOKEN JWT
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, //validar o emissor do token
                    ValidateAudience = true, //validar o destinatario do token
                    ValidateLifetime = true, //validar o tempo de expiração do token
                    ValidateIssuerSigningKey = true, //validar a chave secreta utilizada elo emissor do token
                };
            });

        return services;
    }
}