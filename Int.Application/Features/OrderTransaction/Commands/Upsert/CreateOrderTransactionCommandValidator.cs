using FluentValidation;

namespace Int.Application.Features.OrderTransactions.Upsert;


public class CreateOrderTransactionCommandValidator : AbstractValidator<CreateOrderTransactionCommand>
{
    public CreateOrderTransactionCommandValidator()
    {
    }
}
