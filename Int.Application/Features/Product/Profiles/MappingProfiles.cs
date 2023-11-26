﻿using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Int.Application.Features.Commands;
using Int.Application.Features.Queries;
using Int.Domain.Entities;

namespace Int.Application.Features.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, CreatedProductResponse>().ReverseMap();

        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Product, UpdatedProductResponse>().ReverseMap();

        CreateMap<Product, DeleteProductCommand>().ReverseMap();
        CreateMap<Product, DeletedProductResponse>().ReverseMap();

        CreateMap<Product, GetListProductListItemDto>().ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ReverseMap();
        CreateMap<Paginate<Product>, GetListResponse<GetListProductListItemDto>>().ReverseMap();
    }
}
