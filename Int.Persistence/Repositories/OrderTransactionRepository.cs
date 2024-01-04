using Core.Persistence.Repositories;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using Int.Persistence.Contexts;

namespace Int.Persistence.Repositories;

public class OrderTransactionRepository : EfRepositoryBase<OrderTransaction, Guid, BaseDbContext>, IOrderTransactionRepository
{
    public OrderTransactionRepository(BaseDbContext context) : base(context)
    {
    }
}
