namespace oig.domain.Entities
{
    public class Order<T>: Entity<T>
    { 
        public required ISet<LineItem<T>> LineItems { get; set; }

        public decimal SubTotal
        {
            get
            {
                return LineItems.Sum(l => l.LineTotal);
            }
        }

        private int _taxRate;

        public required int TaxRate
        {
            get
            {
                return _taxRate;
            }

            set
            {
                if (value >= 0)
                {
                    _taxRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(TaxRate), "Taxrate must be greater or equal to 0!");
                }
            }
        }

        private int _discountRate;

        public required int DiscountRate
        {
            get
            {
                return _discountRate;
            }

            set
            {
                if (value >= 5 && value <= 80)
                {
                    _discountRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(DiscountRate), "Discountrate must be between 5 and 80 exclusively!");
                }
            }
        }

        public decimal DiscountableAmount
        {
            get
            {
                return SubTotal * DiscountRate;
            }
        }

        public decimal AfterDiscount
        {
            get
            {
                return SubTotal - DiscountableAmount;
            }
        }

        public decimal TaxableAmount
        {
            get
            {
                return AfterDiscount * TaxRate;
            }
        }

        public decimal AfterTax
        {
            get
            {
                return AfterDiscount + TaxableAmount;
            }
        }

        public decimal GrandTotal
        {
            get
            {
                return AfterTax;
            }
        }

        public required Customer<T> OrderedBy { get; set; }

        public DateTimeOffset OrderedDateTimeUTCOffset { get; } = DateTimeOffset.UtcNow.UtcDateTime;

        public required string BillTo { get; set; }

        public string? Comments { get; set; }
    }
}
