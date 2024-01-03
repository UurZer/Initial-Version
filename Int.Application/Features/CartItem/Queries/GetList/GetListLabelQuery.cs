using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Int.Application.Features.Queries;

public class GetListCartItemQuery : IRequest<GetListResponse<GetListCartItemsListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public Guid UserId { get; set; }
    public class GetListCartItemQueryHandler : IRequestHandler<GetListCartItemQuery, GetListResponse<GetListCartItemsListItemDto>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public GetListCartItemQueryHandler(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCartItemsListItemDto>> Handle(GetListCartItemQuery request, CancellationToken cancellationToken)
        {
            Paginate<CartItem> models = await _cartItemRepository.GetListAsync(
                 include : x => x.Include(x => x.Cart).Include(x => x.Product),
                 predicate : x => x.Cart.UserId == request.UserId,
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize,
                 cancellationToken: cancellationToken,
                 withDeleted: true
                 );

            GetListResponse<GetListCartItemsListItemDto> response = _mapper.Map<GetListResponse<GetListCartItemsListItemDto>>(models);

            return response;
        }
    }
}
