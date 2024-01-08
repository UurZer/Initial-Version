using Int.Domain.Entities;
using Int.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Int.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
    public DbSet<OrderTransaction> OrderTransaction { get; set; }
    public DbSet<OperationClaim> OperationClaim { get; set; }
    public DbSet<CartItem> CartItem { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Label> Label { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<Address> Address { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    public BaseDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
