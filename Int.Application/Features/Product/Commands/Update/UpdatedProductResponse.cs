namespace Int.Application.Features.Commands;

public class UpdatedProductResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string LabelCode { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
