using Core.Persistence.Repositories;

namespace Int.Domain.Entities;

public class Product : Entity<Guid>
{
    public long CategoryId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal UnitPrice { get; set; }
    
    public string ImageUrl { get; set; }

}
