namespace Int.Application.Features.Queries;

public class GetListProductListItemDto
{
    public Guid Id { get; set; }

    public string LabelCode { get; set; }

    public string LabelName { get; set; }

    public string BrandCode { get; set; }

    public string BrandName { get; set; }

    public string Code { get; set; }

    public string Gender { get; set; }

    public string Rating { get; set; }

    public string Offer { get; set; }

    public decimal OfferUnitPrice { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal StockQuantity { get; set; } = 0;

    public string ImageUrl { get; set; }
}
