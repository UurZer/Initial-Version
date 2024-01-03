using Int.Domain.Entities;

namespace Int.Application.Features.Commands;

public class CreatedCartItemResponse
{
    public Guid Id { get; set; }
    
    public Guid CartId { get; set; }

    public Guid ProductId { get; set; }

    public decimal Quantity { get; set; }

    #region [ Navigation Property ]

    public Cart Cart { get; set; }

    public Product Product { get; set; }

    #endregion
}
