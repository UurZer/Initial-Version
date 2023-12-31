﻿using Int.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int.Persistence.EntityConfigurations;

public class OrderTransactionConfiguration : BaseEntityConfiguration<OrderTransaction, Guid>
{
    public void Configure(EntityTypeBuilder<OrderTransaction> builder) 
    {
        builder.ToTable("OrderTransaction", "Int").HasKey(b => b.Id);
        
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.ProductId).HasColumnName("ProductId");
        builder.Property(b => b.UserId).HasColumnName("UserId");
        builder.Property(b => b.Status).HasColumnName("Status");
        builder.Property(b => b.OrderGroupId).HasColumnName("OrderGroupId");
        builder.Property(b => b.TransactionTime).HasColumnName("TransactionTime");
        builder.Property(b => b.TotalAmount).HasColumnName("TotalAmount");
        builder.Property(b => b.TotalQuantity).HasColumnName("TotalQuantity");
        builder.Property(b => b.AddressId).HasColumnName("AddressId");

        base.Configure(builder);

        builder.HasOne("Product");
        builder.HasOne("Cart");
        builder.HasOne("Address");
    }
}
