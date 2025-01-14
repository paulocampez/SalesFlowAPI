namespace Ambev.DeveloperEvaluation.Application.Products.Commands
{
    public class CreateProductResult
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
