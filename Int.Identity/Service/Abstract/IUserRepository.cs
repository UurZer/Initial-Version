using Core.Persistence.Repositories;
using Int.Domain.Entities;
using Int.Identity.Entity;

namespace Int.Identity.Repository.Service;
public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid>
{
    Task<List<OperationClaim>> GetClaimsAsync(Guid userId);
}
