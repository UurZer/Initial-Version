using Core.Persistence.Repositories;

namespace Int.Domain.Entities;

public class Label : Entity<Guid>
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string LabelUType { get; set; }
    
    public int Level { get; set; }

    public Guid ParentLabelId { get; set; }

    public string? ImageUrl { get; set; }

}
