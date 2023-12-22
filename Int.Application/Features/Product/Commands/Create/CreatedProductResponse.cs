namespace Int.Application.Features.Commands;

public class CreatedProductResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal UnitPrice { get; set; }

    public string? ImageUrl { get; set; }

    public string LabelId { get; set; }

    public string LabelCode { get; set; }

    public DateTime CreatedDate { get; set; }
}
