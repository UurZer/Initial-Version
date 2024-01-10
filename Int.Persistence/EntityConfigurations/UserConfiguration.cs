using Int.Domain.Entities;
using Int.Utilities.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "idn").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(b => b.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(b => b.FullName).HasColumnName("FullName").IsRequired();
        builder.Property(b => b.Status).HasColumnName("Status").IsRequired();
        builder.Property(b => b.Email).HasColumnName("Email").IsRequired();
        builder.Property(b => b.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(b => b.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(b => b.Address);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        builder.HasData(GetUserSeed());
    }

    private HashSet<User> GetUserSeed()
    {
        HashingHelper.CreatePasswordHash(
            "serdar.biroglu",
            out byte[] hash,
            out byte[] salt
            );

        HashSet<User> result = new HashSet<User> {
            new()
            {
                Id= Guid.Parse("929FD82B-4556-498F-AED5-424AE312B9AE"),
                FirstName = "Serdar",
                LastName = "Biroğlu",
                FullName = "Serdar Biroğlu",
                Email = "serdar.biroglu@info.com",
                PasswordHash = hash,
                PasswordSalt = salt,
                Status = true,
            }
        };

        return result;
    }
}
