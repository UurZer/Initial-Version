﻿using Int.Application.Services.Repositories;
using AutoMapper;
using Int.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Int.Application.Features.Queries;

public class GetByIdProductQuery : IRequest<GetByIdProductResponse>
{
    public Guid Id { get; set; }

    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetByIdProductQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: b => b.Id == request.Id,
                                                                 x => x.Include(x => x.Labels),
                                                                 withDeleted: true,
                                                                 cancellationToken: cancellationToken);

            GetByIdProductResponse response = _mapper.Map<GetByIdProductResponse>(product);

            return response;
        }
    }


}
