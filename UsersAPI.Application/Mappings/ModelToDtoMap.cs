using AutoMapper;
using UserApi.Domain.Models;
using UsersAPI.Application.Dtos.Responses;

namespace UsersAPI.Application.Mappings;

public class ModelToDtoMap : Profile
{
    public ModelToDtoMap()
    {
        CreateMap<User, UserResponseDto>();//.AfterMap((model, dto) =>
        // {
        //     dto.Id = model.id;
        // })
        
    }
}