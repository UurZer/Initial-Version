using Int.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int.Persistence.EntityConfigurations;

public class AddressConfiguration : BaseEntityConfiguration<Address, Guid>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address", "Int").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
    }
}
