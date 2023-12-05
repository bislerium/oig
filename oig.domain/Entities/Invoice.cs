namespace oig.domain.Entities
{

    [ToString]
    public class Invoice : Entity<string>
    {
        public required Order Order { get; set; }

        public required int InvoiceNumber { get; set; }

        public DateTimeOffset InvoiceIssueDateTimeUTCOffset { get; } = DateTimeOffset.UtcNow.UtcDateTime;

        public DateTimeOffset InvoiceDueDateTimeUTCOffset { get; set; } = DateTimeOffset.UtcNow.UtcDateTime.AddDays(30);

        public string PONumber
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
                return Order.GrandTotal;
            }
        }
    }
}
