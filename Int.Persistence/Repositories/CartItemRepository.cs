using Core.Persistence.Repositories;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using Int.Persistence.Contexts;

namespace Int.Persistence.Repositories;

public class CartItemRepository : EfRepositoryBase<CartItem, Guid, BaseDbContext>, ICartItemRepository
{
    public CartItemRepository(BaseDbContext context) : base(context)
    {
    }
}
