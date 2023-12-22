namespace Int.Application.Features.Commands;

public class UpdatedLabelResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? ParentLabelId { get; set; }

    public string? ParentLabelCode { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
