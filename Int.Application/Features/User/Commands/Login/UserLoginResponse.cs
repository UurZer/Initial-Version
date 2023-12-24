namespace Int.Identity.Features.Commands;

public class UserLoginResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
