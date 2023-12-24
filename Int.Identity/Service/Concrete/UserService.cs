using Core.Persistence.Paging;
using Int.Domain.Entities;
using Int.Identity.Entity;
using Int.Identity.Repository.Service;

namespace Int.Identity.Service
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        async Task IUserService.AddAsync(User user)
        {
            _userRepository.AddAsync(user);
        }

        async Task IUserService.DeleteAsync(User user)
        {
            _userRepository.DeleteAsync(user);
        }

        async Task IUserService.UpdateAsync(User user)
        {
            _userRepository.UpdateAsync(user);
        }

        async Task<Paginate<User>> IUserService.GetAllAsync()
        {
            return await _userRepository.GetListAsync();
        }

        Task<User> IUserService.GetByIdAsync(Guid userId)
        {
            return _userRepository.GetAsync(u => u.Id == userId);
        }

        Task<User> IUserService.GetByMailAsync(string email)
        {
            return _userRepository.GetAsync(u => u.Email == email);
        }

        public Task<List<OperationClaim>> GetClaimsAsync(Guid userId)
        {
            return _userRepository.GetClaimsAsync(userId);
        }
    }
}
