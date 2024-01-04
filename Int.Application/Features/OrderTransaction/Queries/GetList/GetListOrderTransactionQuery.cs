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

public class GetListOrderTransactionQuery : IRequest<GetListResponse<GetListOrderTransactionListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public GetListOrderTransactionQuery()
    {
        PageRequest = new PageRequest();
    }
    public Guid UserId { get; set; }

    public class GetListOrderTransactionQueryHandler : IRequestHandler<GetListOrderTransactionQuery, GetListResponse<GetListOrderTransactionListItemDto>>
    {
        private readonly IOrderTransactionRepository _orderTransactionRepository;
        private readonly IMapper _mapper;

        public GetListOrderTransactionQueryHandler(IOrderTransactionRepository orderTransactionRepository, IMapper mapper)
        {
            _orderTransactionRepository = orderTransactionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrderTransactionListItemDto>> Handle(GetListOrderTransactionQuery request, CancellationToken cancellationToken)
        {
            Paginate<OrderTransaction> orderTransactions = await _orderTransactionRepository.GetListAsync(
                 x => x.UserId == request.UserId,
                 include: m => m.Include(m => m.User).Include(x => x.Product),
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize
                 );

            var response = _mapper.Map<GetListResponse<GetListOrderTransactionListItemDto>>(orderTransactions);

            return response;
        }
    }
}
