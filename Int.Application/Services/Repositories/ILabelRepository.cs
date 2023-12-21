using Core.Persistence.Repositories;
using Int.Domain.Entities;

namespace Int.Application.Services.Repositories;
public interface ILabelRepository : IAsyncRepository<Label, Guid>, IRepository<Label, Guid>
{
}
