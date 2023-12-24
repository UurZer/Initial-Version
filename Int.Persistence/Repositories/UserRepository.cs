using Core.Persistence.Repositories;
using Int.Domain.Entities;
using Int.Identity.Entity;
using Int.Identity.Repository.Service;
using Int.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Int.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, BaseDbContext>, IUserRepository
{
    private BaseDbContext _context;

    public UserRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<List<OperationClaim>> GetClaimsAsync(Guid userId)
    {
        var result = from operationClaim in _context.OperationClaims
                     join userOperationClaim in _context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                     where userOperationClaim.UserId == userId
                     select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
        return result.ToListAsync();

    }
}
