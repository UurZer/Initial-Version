using Core.Persistence.Repositories;
using Int.Domain.Entities;

namespace Int.Application.Services.Repositories;
public interface ICartRepository : IAsyncRepository<Cart, Guid>, IRepository<Cart, Guid>
{
}
