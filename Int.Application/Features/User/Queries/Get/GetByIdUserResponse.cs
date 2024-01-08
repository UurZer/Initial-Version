namespace Int.Application.Features.Queries;

public class GetByIdUserResponse
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
}
