using Core.Persistence.Repositories;
using Int.Domain.Entities;

namespace Int.Application.Services.Repositories;
public interface IOrderTransactionRepository : IAsyncRepository<OrderTransaction, Guid>, IRepository<OrderTransaction, Guid>
{
}
