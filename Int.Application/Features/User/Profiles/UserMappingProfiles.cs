using AutoMapper;
using Int.Domain.Entities;
using Int.Identity.Features.Commands;
using Int.Utility.Security.JWT;

namespace Int.Identity.Features.Profiles;

public class UserMappingProfiles : Profile
{
    public UserMappingProfiles()
    {
        CreateMap<User, UserLoginCommand>().ReverseMap();
        CreateMap<User, UserLoginResponse>().ReverseMap();

        CreateMap<User, UserRegisterCommand>().ReverseMap();
        CreateMap<AccessToken, UserRegisterResponse>().ReverseMap();
        CreateMap<AccessToken, UserLoginResponse>().ReverseMap();

        CreateMap<User, UserDeleteCommand>().ReverseMap();
        CreateMap<User, UserDeleteResponse>().ReverseMap();
    }
}
