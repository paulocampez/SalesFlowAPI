namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleModifiedEvent
    {
        public Guid SaleId { get; set; }
        public DateTime ModifiedAt { get; set; }

        public SaleModifiedEvent(Guid saleId, DateTime modifiedAt)
        {
            SaleId = saleId;
            ModifiedAt = modifiedAt;
        }
    }

    public class SaleCancelledEvent
    {
        public Guid SaleId { get; set; }
        public DateTime CancelledAt { get; set; }

        public SaleCancelledEvent(Guid saleId, DateTime cancelledAt)
        {
            SaleId = saleId;
            CancelledAt = cancelledAt;
        }
    }

    public class ItemCancelledEvent
    {
        public Guid SaleId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime CancelledAt { get; set; }

        public ItemCancelledEvent(Guid saleId, Guid itemId, DateTime cancelledAt)
        {
            SaleId = saleId;
            ItemId = itemId;
            CancelledAt = cancelledAt;
        }
    }
}
