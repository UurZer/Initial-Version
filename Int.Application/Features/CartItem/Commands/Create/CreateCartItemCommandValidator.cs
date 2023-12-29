using FluentValidation;
namespace Int.Application.Features.Commands;

public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
    }
}
