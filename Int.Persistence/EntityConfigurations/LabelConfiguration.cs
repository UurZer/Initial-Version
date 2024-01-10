using Int.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int.Persistence.EntityConfigurations;

public class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.ToTable("Label","Int").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.Code).HasColumnName("Code").IsRequired();
        builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
        builder.Property(b => b.LabelUType).HasColumnName("LabelUType").IsRequired();
        builder.Property(b => b.Level).HasColumnName("Level").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.ParentLabelId).HasColumnName("ParentLabelId");
        builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Code, name: "UK_Label_Code").IsUnique();

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        builder.HasData(GetLabelSeed());
    }

    private HashSet<Label> GetLabelSeed()
    {
        HashSet<Label> result = new HashSet<Label> {
            new()
            {
                Id= Guid.Parse("6BD4B764-D306-4EB2-AABA-367CC6D1FB3C"),
                Code="ZARA",
                Name = "Zara",
                Description = "Zara",
                CreatedDate= DateTime.Now,
                LabelUType="BRAND",
                Level=1,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/2/p/6861/450/485/2/w/750/6861450485_1_1_1.jpg?ts=1673368279180"
            },
            new()
            {
                Id= Guid.Parse("A2C5B038-46D3-4B6E-8B49-852EE78BFEF5"),
                ParentLabelId= Guid.Parse("6BD4B764-D306-4EB2-AABA-367CC6D1FB3C"),
                ParentLabelCode="ZARA",
                Code="ZARA-GIYIM-0001",
                Name = "Giyim",
                Description = "Giyim",
                CreatedDate= DateTime.Now,
                LabelUType="CAT",
                Level=2,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/2/p/6861/450/485/2/w/750/6861450485_1_1_1.jpg?ts=1673368279180"
            },
            new()
            {
                Id= Guid.Parse("4FAC3BEA-9FC6-447D-A622-4CB67418F2CD"),
                ParentLabelId= Guid.Parse("A2C5B038-46D3-4B6E-8B49-852EE78BFEF5"),
                ParentLabelCode="ZARA-GIYIM-0001",
                Code="ZARA-AG-0001",
                Name = "Alt Giyim",
                Description = "Alt Giyim",
                CreatedDate= DateTime.Now,
                LabelUType="CAT",
                Level=3,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/2/p/6861/450/485/2/w/750/6861450485_1_1_1.jpg?ts=1673368279180"
            },
            new()
            {
                Id= Guid.Parse("262506CC-AC24-4B61-A9A0-01212A1E055E"),
                ParentLabelId= Guid.Parse("A2C5B038-46D3-4B6E-8B49-852EE78BFEF5"),
                ParentLabelCode="ZARA-GIYIM-0001",
                Code="ZARA-UG-0001",
                Name = "Ust Giyim",
                Description = "Ust Giyim",
                CreatedDate= DateTime.Now,
                LabelUType="CAT",
                Level=3,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/2/p/6861/450/485/2/w/750/6861450485_1_1_1.jpg?ts=1673368279180"
            },
            new()
            {
                Id= Guid.Parse("EAC012A7-726F-4435-98AB-D7B463BD3D38"),
                ParentLabelId= Guid.Parse("4FAC3BEA-9FC6-447D-A622-4CB67418F2CD"),
                ParentLabelCode="ZARA-AG-0001",
                Code="ZARA-PANTS-0001",
                Name = "Pantalon",
                Description = "Pantalon",
                CreatedDate= DateTime.Now,
                LabelUType="CAT",
                Level=4,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/2/p/6861/450/485/2/w/750/6861450485_1_1_1.jpg?ts=1673368279180"
            },
            new()
            {
                Id= Guid.Parse("B3A5F2AF-0D82-49D7-A8B0-F4BE031056BE"),
                ParentLabelId= Guid.Parse("262506CC-AC24-4B61-A9A0-01212A1E055E"),
                ParentLabelCode="ZARA-UG-0001",
                Code="ZARA-SHIRT-0001",
                Name = "Gömlek",
                Description = "Gömlek",
                CreatedDate= DateTime.Now,
                LabelUType="CAT",
                Level=4,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/2/p/6861/450/485/2/w/750/6861450485_1_1_1.jpg?ts=1673368279180"
            },
            new()
            {
                Id= Guid.Parse("EA95C1D7-5490-4273-B988-02A350125F08"),
                Code="TOP-SELLER",
                Name = "En Çok Satanlar",
                Description = "En Çok Satanlar",
                CreatedDate= DateTime.Now,
                LabelUType="FLT",
                Level=1,
                ImageUrl = "https://static.zara.net/photos///2023/V/0/2/p/6861/450/485/2/w/750/6861450485_1_1_1.jpg?ts=1673368279180"
            },
        };

        return result;
    }
}
