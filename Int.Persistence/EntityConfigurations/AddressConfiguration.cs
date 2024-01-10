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
        builder.HasData(GetAddressSeed());
    }

    private HashSet<Address> GetAddressSeed()
    {
        HashSet<Address> result = new HashSet<Address> {
            new()
            {
                Id= Guid.NewGuid(),
                UserId = Guid.Parse("929FD82B-4556-498F-AED5-424AE312B9AE"),
                Building = "M2 Blok Kat 3",
                City = "Düzce",
                Destination = "Düzce Üniversitesi Mühendislik Fakültesi M2 Blok Kat 3, Konuralp Kampüsü Merkez/Düzce 81620",
                IsDefault = true,
                Name = "Düzce Üniversitesi",
                Phone = "(0380) 542 10 36 Dahili: 4672",
                PostalCode = "816000",
                State = "Merkez",
                Street = "Konuralp",
            }
        };

        return result;
    }
}
