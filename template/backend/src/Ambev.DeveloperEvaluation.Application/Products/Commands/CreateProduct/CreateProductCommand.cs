using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
