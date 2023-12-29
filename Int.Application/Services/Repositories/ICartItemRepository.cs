using Core.Persistence.Repositories;
using Int.Domain.Entities;

namespace Int.Application.Services.Repositories;
public interface ICartItemRepository : IAsyncRepository<CartItem, Guid>, IRepository<CartItem, Guid>
{
}
