using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Int.Application.Features.Rules;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.OrderTransactions.Upsert;
public class CreateOrderTransactionCommand : IRequest, ITransactionalRequest
{
    #region [ Model ]

    public List<OrderTransactionRequest> OrderTransactionRequests { get; set; }

    #endregion

    public class CreateOrderTransactionCommandHandler : IRequestHandler<CreateOrderTransactionCommand>
    {
        private readonly IOrderTransactionRepository _orderTransactionRepository;
        private readonly OrderTransactionBusinessRules _orderTransactionBusinessRules;
        private readonly IMapper _mapper;

        public CreateOrderTransactionCommandHandler(IOrderTransactionRepository orderTransactionRepository, OrderTransactionBusinessRules orderTransactionBusinessRules, IMapper mapper)
        {
            _mapper = mapper;
            _orderTransactionBusinessRules = orderTransactionBusinessRules;
            _orderTransactionRepository = orderTransactionRepository;
        }

        public async Task? Handle(CreateOrderTransactionCommand request, CancellationToken cancellationToken)
        {
            List<OrderTransaction> orderTransactions = _mapper.Map<List<OrderTransaction>>(request.OrderTransactionRequests);
            OrderTransaction currentTransaction = null;
            List<CreatedOrderTransactionResponse> createdLabelResponse;
            Guid orderGroupId = Guid.NewGuid();

            foreach (OrderTransaction orderTransactionRequest in orderTransactions)
            {
                currentTransaction = _orderTransactionRepository.GetAsync(x => x.Id == orderTransactionRequest.Id).Result;
                if (currentTransaction != null)
                {
                    await _orderTransactionBusinessRules.IsCanUpdatable(orderTransactionRequest.Id);
                    await _orderTransactionRepository.UpdateAsync(currentTransaction);
                }
                else
                {
                    orderTransactionRequest.Id = Guid.NewGuid();
                    orderTransactionRequest.OrderGroupId = orderGroupId;
                    orderTransactionRequest.TransactionTime = DateTime.Now;
                    await _orderTransactionRepository.AddAsync(orderTransactionRequest);
                }
            }
        }
    }
}