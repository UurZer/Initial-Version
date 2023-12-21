using Core.Persistence.Repositories;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using Int.Persistence.Contexts;

namespace Int.Persistence.Repositories;

public class LabelRepository : EfRepositoryBase<Label, Guid, BaseDbContext>, ILabelRepository
{
    public LabelRepository(BaseDbContext context) : base(context)
    {
    }
}
