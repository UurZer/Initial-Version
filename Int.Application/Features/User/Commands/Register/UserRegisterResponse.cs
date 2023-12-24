namespace Int.Identity.Features.Commands;

public class UserRegisterResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
