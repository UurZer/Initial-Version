using Core.Persistence.Paging;
using Int.Domain.Entities;
using Int.Identity.Entity;

namespace Int.Identity.Service
{
    public interface IUserService
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<Paginate<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid userId);
        Task<List<OperationClaim>> GetClaimsAsync(Guid userId);
        Task<User> GetByMailAsync(string email);
    }
}
