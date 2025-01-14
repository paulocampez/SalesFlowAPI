using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<List<GetProductsResult>>
    {
    }
}
