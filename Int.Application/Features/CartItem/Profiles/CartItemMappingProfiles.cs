﻿using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Int.Application.Features.Commands;
using Int.Application.Features.Queries;
using Int.Domain.Entities;

namespace Int.Application.Features.Profiles;

public class CartItemMappingProfiles : Profile
{
    public CartItemMappingProfiles()
    {
        CreateMap<CartItem, CreateCartItemCommand>().ReverseMap();
        CreateMap<CartItem, CreatedCartItemResponse>().ReverseMap();

        CreateMap<CartItem, DeleteCartItemCommand>().ReverseMap();
        CreateMap<CartItem, DeletedCartItemResponse>().ReverseMap();

        CreateMap<CartItem, UpdateCartItemCommand>().ReverseMap();
        CreateMap<CartItem, UpdatedCartItemResponse>().ReverseMap();

        CreateMap<User, GetListCartItemsListItemDto>().ReverseMap();
        CreateMap<CartItem, GetListCartItemsListItemDto>().ReverseMap();
        CreateMap<Paginate<CartItem>, GetListResponse<GetListCartItemsListItemDto>>().ReverseMap();
    }
}
