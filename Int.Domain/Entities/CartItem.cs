using Core.Persistence.Repositories;

namespace Int.Domain.Entities;

public class CartItem : Entity<Guid>
{
    public Guid CartId { get; set; }

    public Guid ProductId { get; set; }
    
    public decimal Quantity { get; set; }

    #region [ Navigation Property ]

    public Cart Cart { get; set; }

    public Product Product { get; set; }

    #endregion
}
