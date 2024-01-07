namespace Int.Application.Features.Queries;

public class GetListCartItemsListItemDto
{
    public Guid Id { get; set; }

    public Guid CartId { get; set; }

    public Guid ProductId { get; set; }

    public Guid UserId { get; set; }

    public string ProductBrandCode { get; set; }

    public string ProductBrandName { get; set; }

    public string ProductCode { get; set; }

    public string ProductGender { get; set; }

    public string ProductRating { get; set; }

    public string ProductOffer { get; set; }

    public decimal ProductOfferUnitPrice { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public decimal ProductUnitPrice { get; set; }

    public decimal ProductStockQuantity { get; set; } = 0;

    public string ProductImageUrl { get; set; }

    public decimal Quantity { get; set; }
}
