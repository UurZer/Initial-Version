using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Int.Application.Features.Queries;

public class GetListDynamicProductQuery : IRequest<GetListResponse<GetListProductListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public Guid LabelId { get; set; }

    public class GetListProductQueryHandler : IRequestHandler<GetListDynamicProductQuery, GetListResponse<GetListProductListItemDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductListItemDto>> Handle(GetListDynamicProductQuery request, CancellationToken cancellationToken)
        {
            Paginate<Product> products = await _productRepository.GetListByDynamicAsync(
                 request.DynamicQuery,
                 x => x.LabelId == request.LabelId,
                 include: m => m.Include(m => m.Labels),
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize
                 );

            var response = _mapper.Map<GetListResponse<GetListProductListItemDto>>(products);

            return response;
        }
    }
}
