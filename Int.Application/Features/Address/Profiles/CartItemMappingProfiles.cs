using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Int.Application.Features.Commands;
using Int.Application.Features.Queries;
using Int.Domain.Entities;

namespace Int.Application.Features.Profiles;

public class AddressMappingProfiles : Profile
{
    public AddressMappingProfiles()
    {
        CreateMap<Address, CreateAddressCommand>().ReverseMap();
        CreateMap<Address, CreatedAddressResponse>().ReverseMap();

        CreateMap<Address, DeleteAddressCommand>().ReverseMap();
        CreateMap<Address, DeletedAddressResponse>().ReverseMap();

        CreateMap<User, GetListAddressListItemDto>().ReverseMap();
        CreateMap<Address, GetListAddressListItemDto>().ReverseMap();
        CreateMap<Paginate<Address>, GetListResponse<GetListAddressListItemDto>>().ReverseMap();
    }
}
