using Int.Domain.Entities;
using Int.Identity.Entity;

namespace Int.Utility.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,
            List<OperationClaim> operationClaims);
    }
}
