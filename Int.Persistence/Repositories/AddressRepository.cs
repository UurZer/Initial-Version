using Core.Persistence.Repositories;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using Int.Persistence.Contexts;

namespace Int.Persistence.Repositories;

public class AddressRepository : EfRepositoryBase<Address, Guid, BaseDbContext>, IAddressRepository
{
    public AddressRepository(BaseDbContext context) : base(context)
    {
    }
}
