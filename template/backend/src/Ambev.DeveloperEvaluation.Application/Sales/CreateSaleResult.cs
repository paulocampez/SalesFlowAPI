namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Represents the result of a sale creation operation.
    /// </summary>
    public class CreateSaleResult
    {
        /// <summary>
        /// Gets or sets the unique identifier for the created sale.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Gets or sets the date and time the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
