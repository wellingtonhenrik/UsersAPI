using UserApi.Domain.ValueObjects;

namespace UserApi.Domain.Interfaces.Security;

public interface ITokenService
{
    string CreateToken(UserAuthVO userAuthVO);
}