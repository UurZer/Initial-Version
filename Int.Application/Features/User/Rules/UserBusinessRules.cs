using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Int.Domain.Entities;
using Int.Identity.Features.Constants;
using Int.Identity.Service;
using Int.Utilities.Security.Hashing;

namespace Int.Identity.Features.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserService _userService;

    public UserBusinessRules(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<User> CheckToUserForLogin(string email)
    {
        User result = _userService.GetByMailAsync(email).Result;

        if (result is null)
        {
            throw new BusinessException(UserMessages.UserNotExists);
        }

        return result;
    }

    public async Task CheckToUserForRegister(string email)
    {
        User? result = _userService.GetByMailAsync(email).Result;

        if (result != null)
        {
            throw new BusinessException(UserMessages.UserAlreadyRegistered);
        }
    }

    public async Task CheckUserPasswordHash(string password, User user)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new BusinessException(UserMessages.UserPasswordError);
        }
    }
}
