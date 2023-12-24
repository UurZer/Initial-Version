using Int.Domain.Entities;
using Int.Identity.Entity;
using Int.Utility.Security.JWT;

namespace Int.Identity.Service
{
    public class AuthService : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthService(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public AccessToken CreateAccessToken(User user)
        {
            List<OperationClaim> claims = _userService.GetClaimsAsync(user.Id).Result;
            AccessToken accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }
    }
}
