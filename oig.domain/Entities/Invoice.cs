namespace oig.domain.Entities
{
    public class Invoice<T>: Entity<T>
    {
        public required Company<T> Company { get; set; }

        public required Order<T> Order { get; set; }

        public required int InvoiceNumber { get; set; }

        public DateTimeOffset InvoiceDateTimeUTCOffset { get; } = DateTimeOffset.UtcNow.UtcDateTime;

        public DateTimeOffset InvoiceDueDateTimeUTCOffset { get; set; } = DateTimeOffset.UtcNow.UtcDateTime.AddDays(30);

        public T PONumber
        {
            get
            {
                return Order.Id;
            }
        }

        public DateTimeOffset PODate
        {
            get
            {
                return Order.OrderedDateTimeUTCOffset;
            }
        }

        public decimal BalanceDue
        {
            get
            {
                return Order.GrandTotalPrice;
            }
        }

        public required string Description { get; set; }
    }
}
