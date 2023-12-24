using Int.Domain.Entities;
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

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
