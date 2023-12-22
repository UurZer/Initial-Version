using Int.Domain.Entities;

namespace Int.Application.Features.Queries;

public class LabelResponse
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string LabelUType { get; set; }

    public int Level { get; set; }

    public string? ParentLabelCode { get; set; }

    public string? ImageUrl { get; set; }

    public Label ParentLabel { get; set; }
}
