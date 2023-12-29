using Core.Persistence.Repositories;

namespace Int.Domain.Entities;

public class Cart : Entity<Guid>
{
    public Guid UserId { get; set; }

    #region [ Navigation Property ]

    public User User { get; set; }

    #endregion
}
