using Core.Persistence.Repositories;
using Int.Domain.Entities;

namespace Int.Application.Services.Repositories;
public interface IAddressRepository : IAsyncRepository<Address, Guid>, IRepository<Address, Guid>
{
}
