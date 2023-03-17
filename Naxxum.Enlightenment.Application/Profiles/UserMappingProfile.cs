using AutoMapper;
using Naxxum.Enlightenment.Application.DTOs.Auth;
using Naxxum.Enlightenment.Application.DTOs.Users;
using Naxxum.Enlightenment.Domain.Entities;

namespace Naxxum.Enlightenment.Application.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>()
            .ForCtorParam(nameof(UserDto.RegistrationDate),
                dest => dest.MapFrom(u => u.CreatedAtUtc));

        CreateMap<User, UserWithTokenDto>();
    }
}