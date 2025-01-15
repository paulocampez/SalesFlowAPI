using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public List<SaleItem> Items { get; set; } = new();
    }
}
