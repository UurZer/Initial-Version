using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Int.Utility.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));//Appsetting.dev.json dosyasındaki keyi bite çevirir
        }
    }
}
