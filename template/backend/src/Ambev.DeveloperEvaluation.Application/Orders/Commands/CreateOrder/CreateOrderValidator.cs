using Ambev.DeveloperEvaluation.Application.Orders.Commands.CreateOrder;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Customer name is required.");
            RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("Total amount must be greater than zero.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Order status is required.");
        }
    }
}
