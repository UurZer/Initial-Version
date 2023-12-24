using Int.Domain.Entities;
using Int.Utility.Security.JWT;

namespace Int.Identity.Service
{
    public interface IAuthService
    {
        AccessToken CreateAccessToken(User user);
    }
}
