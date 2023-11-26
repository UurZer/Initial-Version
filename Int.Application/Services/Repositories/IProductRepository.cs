using Core.Persistence.Repositories;
using Int.Domain.Entities;

namespace Int.Application.Services.Repositories;
public interface IProductRepository : IAsyncRepository<Product, Guid>, IRepository<Product, Guid>
{
}
