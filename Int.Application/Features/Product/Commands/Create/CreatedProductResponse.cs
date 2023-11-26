namespace Int.Application.Features.Commands;

public class CreatedProductResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }
}
