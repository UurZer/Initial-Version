using FluentValidation;
namespace Int.Application.Features.Commands;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(c => c.Destination).NotEmpty();
    }
}
