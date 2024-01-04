using Int.Domain.Entities;

namespace Int.Application.Features.Queries;

public class GetListOrderTransactionListItemDto
{
    public Guid OrderGroupId { get; set; }

    public Guid UserId { get; set; }

    public string UserFullName { get; set; }

    public Guid ProductId { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal TotalQuantity { get; set; }

    public DateTime TransactionTime { get; set; }

    public string Status { get; set; }
}
