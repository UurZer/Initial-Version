using Int.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata.Ecma335;

namespace Int.Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product","Int").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Code).HasColumnName("Code").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.LabelId).HasColumnName("LabelId").IsRequired();
        builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
        builder.Property(b => b.UnitPrice).HasColumnName("UnitPrice").IsRequired();
        builder.Property(b => b.StockQuantity).HasColumnName("StockQuantity").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");


        builder.HasMany(b => b.Labels);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        builder.HasData(GetProductSeed());
    }

    private HashSet<Product> GetProductSeed()
    {
        HashSet<Product> result = new HashSet<Product> {
            new()
            {
                Id= Guid.NewGuid(),
                Code="ZARA-PANTS-0001-00001",
                LabelId = Guid.Parse("EAC012A7-726F-4435-98AB-D7B463BD3D38"),
                LabelCode="ZARA-PANTS-0001",
                BrandCode="ZARA",
                BrandName="ZARA",
                Gender = "Male",
                Name = "STRAIGHT FIT SOLUK EFEKTLİ PANTOLON",
                Description = "Çok esnek kumaşlı pantolon. Elastik belli, ön cepli, biyeli arka cepli, fermuarlı ve üstü düğmeli.",
                CreatedDate= DateTime.Now,
                Offer = "%37",
                Rating = 4.5m,
                UnitPrice = 990,
                Size = "M",
                OfferUnitPrice = 620,
                StockQuantity = 55,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/2/p/6861/450/485/2/w/750/6861450485_1_1_1.jpg?ts=1673368279180"
            },
            new()
            {
                Id= Guid.NewGuid(),
                Code="ZARA-PANTS-0001-00002",
                LabelId = Guid.Parse("EAC012A7-726F-4435-98AB-D7B463BD3D38"),
                LabelCode="ZARA-PANTS-0001",
                BrandCode="ZARA",
                BrandName="ZARA",
                Gender = "Male",
                Name = "KARGO PANTOLON",
                Description = "Ayarlanabilen bağcıklı elastik belli, relaxed fit pantolon. Ön cepli ve biyeli arka cepli. Bacakları kapaklı yama cepli. Paçaları elastik manşetli.",
                CreatedDate= DateTime.Now,
                Offer = "%37",
                Rating = 4.8m,
                UnitPrice = 1000,
                Size = "M",
                OfferUnitPrice = 630,
                StockQuantity = 50,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/1/p/0108/401/805/2/w/750/0108401805_1_1_1.jpg?ts=1683803852567"
            },
            new()
            {
                Id= Guid.NewGuid(),
                Code="ZARA-SHIRT-0001-00001",
                LabelId = Guid.Parse("B3A5F2AF-0D82-49D7-A8B0-F4BE031056BE"),
                LabelCode="ZARA-SHIRT-0001",
                BrandCode="ZARA",
                BrandName="ZARA",
                Gender = "Male",
                Name = "KONTRAST DİKİŞ DETAYLI GÖMLEK",
                Description = "Uzun kollu, manşetleri ve önü düğmeli, yakalı, yama göğüs cepli, tamamı kontrast üst dikişli, relaxed fit gömlek.",
                CreatedDate= DateTime.Now,
                Offer = "%46",
                Rating = 4.9m,
                UnitPrice = 1390,
                Size = "M",
                OfferUnitPrice = 750,
                StockQuantity = 50,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/1/p/0108/401/805/2/w/750/0108401805_1_1_1.jpg?ts=1683803852567"
            },
            new()
            {
                Id= Guid.NewGuid(),
                Code="ZARA-SHIRT-0001-00002",
                LabelId = Guid.Parse("B3A5F2AF-0D82-49D7-A8B0-F4BE031056BE"),
                LabelCode="ZARA-SHIRT-0001",
                BrandCode="ZARA",
                BrandName="ZARA",
                Gender = "Female",
                Name = "FİYONKLU GÖMLEK",
                Description = "Kontrast bağcıklı ve pilili fırfırlı katlı yaka, önü uyumlu düğmeli gömlek.",
                CreatedDate= DateTime.Now,
                Offer = "%49",
                Rating = 5m,
                UnitPrice = 890,
                Size = "M",
                OfferUnitPrice = 450,
                StockQuantity = 40,
                ImageUrl = "https://static.zara.net/photos///2023/I/0/1/p/3564/188/250/2/w/750/3564188250_2_1_1.jpg?ts=1694691243756"
            },
            new()
            {
                Id= Guid.NewGuid(),
                Code="ZARA-SHIRT-0001-00003",
                LabelId = Guid.Parse("B3A5F2AF-0D82-49D7-A8B0-F4BE031056BE"),
                LabelCode="ZARA-SHIRT-0001",
                BrandCode="ZARA",
                BrandName="ZARA",
                Gender = "Female",
                Name = "ZW COLLECTION ÇİZGİLİ VE KONTRAST TASARIMLI GÖMLEK",
                Description = "İnceltilmiş %100 pamuklu kumaştan, uzun kollu, manşetleri ve önü düğmeli, yakalı, kontrast kumaş detaylı, asimetrik kesim gömlek.",
                CreatedDate= DateTime.Now,
                Offer = "%50",
                Rating = 3.8m,
                UnitPrice = 1390,
                Size = "M",
                OfferUnitPrice = 690,
                StockQuantity = 40,
                ImageUrl = "https://static.zara.net/photos///2023/I/0/1/p/9479/307/030/2/w/750/9479307030_2_1_1.jpg?ts=1697629023301"
            }
        };

        return result;
    }
}