using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.Validators
{
    public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required.");
        }
    }
}
