using Core.Persistence.Repositories;

namespace Int.Domain.Entities;

public class OrderTransaction : Entity<Guid>
{
    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal TotalQuantity { get; set; }
    
    public DateTime TransactionTime { get; set; }

    public string Status { get; set; }

    #region [ Navigation Property ]

    public User User { get; set; }

    public Product Product { get; set; }

    #endregion

}
