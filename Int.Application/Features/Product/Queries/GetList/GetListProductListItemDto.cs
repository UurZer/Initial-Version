namespace Int.Application.Features.Queries;

public class GetListProductListItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string LabelType { get; set; }

    public string LabelName { get; set; }

    public decimal UnitPrice { get; set; }

    public string ImageUrl { get; set; }
}
