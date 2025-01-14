using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductByIdResult>
    {
        public Guid ProductId { get; set; }

        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
