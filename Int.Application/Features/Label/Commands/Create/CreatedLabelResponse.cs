namespace Int.Application.Features.Commands;

public class CreatedLabelResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string LabelUType { get; set; }

    public int Level { get; set; }

    public Guid? ParentLabelId { get; set; }

    public string? ImageUrl { get; set; }
}
