using Int.Application.Services.Repositories;
using AutoMapper;
using Int.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Core.Persistence.Paging;
using Core.Application.Responses;
using Core.Application.Requests;

namespace Int.Application.Features.Queries;

public class GetByIdOrderTransactionQuery : IRequest<GetListResponse<GetByIdOrderTransactionResponse>>
{
    public PageRequest PageRequest { get; set; }

    public GetByIdOrderTransactionQuery()
    {
        PageRequest = new PageRequest();
    }

    public Guid OrderGroupId { get; set; }

    public class GetByIdOrderTransactionQueryHandler : IRequestHandler<GetByIdOrderTransactionQuery, GetListResponse<GetByIdOrderTransactionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderTransactionRepository _orderTransactionRepository;

        public GetByIdOrderTransactionQueryHandler(IMapper mapper, IOrderTransactionRepository OrderTransactionRepository)
        {
            _mapper = mapper;
            _orderTransactionRepository = OrderTransactionRepository;
        }

        public async Task<GetListResponse<GetByIdOrderTransactionResponse>> Handle(GetByIdOrderTransactionQuery request, CancellationToken cancellationToken)
        {
            Paginate<OrderTransaction> orderTransactions = await _orderTransactionRepository.GetListAsync(predicate: b => b.OrderGroupId == request.OrderGroupId,
                                                                 include: x => x.Include(x => x.User).Include(x => x.Product),
                                                                 withDeleted: true,
                                                                 cancellationToken: cancellationToken);

            GetListResponse<GetByIdOrderTransactionResponse> response = _mapper.Map<GetListResponse<GetByIdOrderTransactionResponse>>(orderTransactions);

            return response;
        }
    }
}
