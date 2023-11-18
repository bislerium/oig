namespace oig.domain.Entities
{
    public class LineItem<T>: Entity<T>
    {
        public required Product<T> Product { get; set; }

        public required int Quantity { get; set; }

        public decimal LineTotal
        {
            get
            {
                return Quantity * Product.Price;
            }
        }
    }
}
