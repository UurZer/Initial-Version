using Core.Persistence.Repositories;

namespace Int.Domain.Entities;

public class Product : Entity<Guid>
{
    public Guid LabelId { get; set; }

    public string LabelCode { get; set; }

    public string BrandCode { get; set; }

    public string BrandName { get; set; }

    public string Code { get; set; }

    public string Gender { get; set; }

    public string Rating { get; set; }

    public string Offer { get; set; }

    public decimal OfferUnitPrice { get; set; }

    public string Name { get; set; }

    public string Size { get; set; }

    public string Description { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal StockQuantity { get; set; } = 0;

    public string ImageUrl { get; set; }

    #region [ Navigation Property ]

    public ICollection<Label> Labels { get; set; }

    #endregion
}
