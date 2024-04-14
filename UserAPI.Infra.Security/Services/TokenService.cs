using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using UserApi.Domain.Interfaces.Security;
using UserApi.Domain.ValueObjects;
using UserAPI.Infra.Security.Settings;

namespace UserAPI.Infra.Security.Services;

public class TokenService : ITokenService
{
    private readonly TokenSettings? _tokenSettings;

    public TokenService(IOptions<TokenSettings>? tokenSettings)
    {
        _tokenSettings = tokenSettings?.Value;
    }

    public string CreateToken(UserAuthVO userAuthVO)
    {
        //Definiar as CLAIMS que serão gravadas no token
        //CLAIMS -> Identificação para o usuário
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(userAuthVO)),
            new Claim(ClaimTypes.Role, userAuthVO.Roles),
        };
        
        //gerando a assinatura antifalsificação do token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
       //preencher as informações do token
       var jwtSecurityToken = new JwtSecurityToken(
           issuer: _tokenSettings.Issuer,
           audience: _tokenSettings.Audience,
           claims : claims,
           expires: DateTime.Now.AddMinutes(Convert.ToDouble(_tokenSettings.ExpirationInMinutes)),
           signingCredentials: credentials
           );

           //retornando token
           var tokenHandle = new JwtSecurityTokenHandler();
           return tokenHandle.WriteToken(jwtSecurityToken);
    }
}