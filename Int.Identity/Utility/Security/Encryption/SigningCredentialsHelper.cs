using Microsoft.IdentityModel.Tokens;

namespace Int.Utility.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);//Appsetting.dev.json dosyasındaki bite çevirilen keyin kimlğini oluşturur
        }
    }
}
