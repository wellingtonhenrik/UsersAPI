using AutoMapper;
using Microsoft.VisualBasic.CompilerServices;
using UserApi.Domain.Interfaces.Services;
using UserApi.Domain.Models;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;

namespace UsersAPI.Application.Services;

public class AuthAppService : IAuthAppService
{
    private readonly IUserDomainService? _userDomainService;
    private readonly IMapper _mapper;

    public AuthAppService(IUserDomainService? userDomainService, IMapper mapper)
    {
        _userDomainService = userDomainService;
        _mapper = mapper;
    }

    public void Dispose()
    {
        _userDomainService?.Dispose();
    }

    public LoginResponseDto Login(LoginRequestDto dto)
    {
        var user = _userDomainService?.Get(dto.Email, dto.Password);

        var response = new LoginResponseDto()
        {
            Expiration = DateTime.UtcNow,
            AcessToken = string.Empty,
            User = _mapper.Map<UserResponseDto>(user),
        };
        return response;
    }

    public UserResponseDto ForgotPassword(ForgotPasswordRequestDto dto)
    {
        var user = _userDomainService?.Get(dto.Email);
        return _mapper.Map<UserResponseDto>(user);

    }

    public UserResponseDto ResetPassword(Guid id,ResetPasswordRequestDto dto)
    {
        var user = _userDomainService?.Get(id);
        return _mapper.Map<UserResponseDto>(user);
    }
}