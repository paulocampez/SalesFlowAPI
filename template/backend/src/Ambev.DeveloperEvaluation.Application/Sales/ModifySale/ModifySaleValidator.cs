using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale
{
    public class ModifySaleValidator : AbstractValidator<ModifySaleCommand>
    {
        public ModifySaleValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID is required.");
            RuleFor(x => x.Customer).NotEmpty().WithMessage("Customer is required.");
            RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("Total amount must be greater than zero.");
            RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required.");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.ProductId).NotEmpty().WithMessage("Product ID is required.");
                item.RuleFor(i => i.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
                item.RuleFor(i => i.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero.");
                item.RuleFor(i => i.Discount).GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.");
            });
        }
    }
}
