using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Int.Application.Features.Queries;
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

        CreateMap<User, GetByIdUserResponse>().ReverseMap();
        CreateMap<User, GetListUserResponse>().ReverseMap();

        CreateMap<Paginate<User>, GetListResponse<GetListUserResponse>>().ReverseMap();

        CreateMap<User, UserRegisterCommand>().ReverseMap();
        CreateMap<AccessToken, UserRegisterResponse>().ReverseMap();
        CreateMap<AccessToken, UserLoginResponse>().ReverseMap();

        CreateMap<User, UserDeleteCommand>().ReverseMap();
        CreateMap<User, UserDeleteResponse>().ReverseMap();
    }
}
