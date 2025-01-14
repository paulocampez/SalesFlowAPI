using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.Queries
{
    public class GetOrdersQuery : IRequest<List<GetOrdersResult>>
    {
    }
}
