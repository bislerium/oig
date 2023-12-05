namespace oig.domain.Entities
{
    [ToString]
    public class LineItem: Entity<string>
    {
        public required Product Product { get; set; }

        public required int Quantity { get; set; }

        public decimal LineTotal
        {
            get
            {
                return Quantity * Product.Price.Value;
            }
        }
    }
}
