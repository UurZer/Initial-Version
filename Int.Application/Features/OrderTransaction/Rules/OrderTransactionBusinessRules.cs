using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;

namespace Int.Application.Features.Rules;

public class OrderTransactionBusinessRules : BaseBusinessRules
{
    private readonly IOrderTransactionRepository _orderTransactionRepository;

    public OrderTransactionBusinessRules(IOrderTransactionRepository orderTransactionRepository)
    {
        _orderTransactionRepository = orderTransactionRepository;
    }

    public async Task IsCanUpdatable(Guid id)
    {
        OrderTransaction? result = await _orderTransactionRepository.GetAsync(predicate: b => b.Id == id && b.Status != "CMP");

        if (result != null)
        {
            throw new BusinessException("Hata");
        }
    }
}
