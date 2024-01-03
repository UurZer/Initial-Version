namespace Int.Application.Features.Queries;

public class GetListCartItemsListItemDto
{
    public Guid CartId { get; set; }

    public Guid CartDetailId { get; set; }

    public Guid ProductId { get; set; }

    public Guid UserId { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public decimal ProductUnitPrice { get; set; }

    public string ProductImageUrl { get; set; }

    public decimal Quantity { get; set; }
}
