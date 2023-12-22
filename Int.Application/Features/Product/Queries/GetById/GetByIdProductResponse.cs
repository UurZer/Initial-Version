namespace Int.Application.Features.Queries;

public class GetByIdProductResponse
{
    public Guid Id { get; set; }

    public Guid LabelId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string LabelUType { get; set; }

    public string LabelName { get; set; }

    public decimal UnitPrice { get; set; }

    public string ImageUrl { get; set; }
}
