using Int.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int.Persistence.EntityConfigurations;

public class CartItemConfiguration : BaseEntityConfiguration<CartItem, Guid>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItem", "Int").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Quantity).HasColumnName("Quantity");
        builder.Property(b => b.ProductId).HasColumnName("ProductId");
        builder.Property(b => b.CartId).HasColumnName("CartId");

        builder.HasOne("Product");
        builder.HasOne("Cart");
    }
}
