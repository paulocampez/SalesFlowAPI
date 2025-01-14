namespace Ambev.DeveloperEvaluation.Application.Products.Queries
{
    public class GetProductsResult
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
