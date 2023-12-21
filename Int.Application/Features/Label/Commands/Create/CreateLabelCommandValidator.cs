using FluentValidation;
namespace Int.Application.Features.Commands;

public class CreateLabelCommandValidator : AbstractValidator<CreateLabelCommand>
{
    public CreateLabelCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
    }
}
