using Ambev.DeveloperEvaluation.Application.Products.Queries;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<GetProductsResult>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<GetProductsResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsAsync();

            return products.Select(product => new GetProductsResult
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price
            }).ToList();
        }
    }
}
