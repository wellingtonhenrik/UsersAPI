using AutoMapper;
using UserApi.Domain.Exceptions;
using UserApi.Domain.Interfaces.Services;
using UserApi.Domain.Models;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;

namespace UsersAPI.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IUserDomainService? _userDomainService;
    private readonly IMapper? _mapper;

    public UserAppService(IUserDomainService? userDomainService, IMapper? mapper)
    {
        _userDomainService = userDomainService;
        _mapper = mapper;
    }

    public void Dispose()
    {
        _userDomainService?.Dispose();
    }

    public UserResponseDto Add(UserAddRequestDto dto)
    {
        try
        {
            var user = new User()
            {
                id = Guid.NewGuid(),
                Email = dto.Email,
                DataCadastro = DateTime.UtcNow,
                Nome = dto.Nome,
                Password = dto.Password,
            };
            _userDomainService?.Add(user);

            return _mapper.Map<UserResponseDto>(user);

        }
        catch (EmailJaExisteException e)
        {
            throw new ApplicationException(e.Message);
        }
    }

    public UserResponseDto Update(Guid id, UserUpdateRequestDto dto)
    {
        var userBase = _userDomainService?.Get(id);
        userBase.Nome = dto.Nome;

        _userDomainService?.Update(userBase);
        return _mapper.Map<UserResponseDto>(userBase);
    }

    public UserResponseDto Delete(Guid id)
    {
        var user = _userDomainService?.Get(id);
        _userDomainService?.Delete(user);
        return _mapper.Map<UserResponseDto>(user);
    }

    public UserResponseDto Get(Guid id)
    {
        var user = _userDomainService?.Get(id);
        return _mapper.Map<UserResponseDto>(user);
    }
}