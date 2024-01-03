using Core.Persistence.Repositories;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using Int.Persistence.Contexts;

namespace Int.Persistence.Repositories;

public class CartRepository : EfRepositoryBase<Cart, Guid, BaseDbContext>, ICartRepository
{
    public CartRepository(BaseDbContext context) : base(context)
    {
    }
}
