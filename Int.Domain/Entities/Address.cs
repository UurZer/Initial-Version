using Core.Persistence.Repositories;

namespace Int.Domain.Entities;

public class Address : Entity<Guid>
{
    public Guid UserId { get; set; }

    public string Building { get; set; }

    public string City { get; set; }

    public string Destination { get; set; }

    public bool IsDefault { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string PostalCode { get; set; }

    public string State { get; set; }

    public string Street { get; set; }

    public User User { get; set; }
}
