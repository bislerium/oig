namespace oig.domain.Entities
{
    public class Order<T>: Entity<T>
    { 
        public required ISet<LineItem<T>> LineItems { get; set; }

        public decimal OrderTotal
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
                return OrderTotal * DiscountRate;
            }
        }

        public decimal AfterDiscountPrice
        {
            get
            {
                return OrderTotal - DiscountableAmount;
            }
        }

        public decimal TaxableAmount
        {
            get
            {
                return AfterDiscountPrice * TaxRate;
            }
        }

        public decimal AfterTaxPrice
        {
            get
            {
                return AfterDiscountPrice + TaxableAmount;
            }
        }

        public decimal GrandTotalPrice
        {
            get
            {
                return AfterTaxPrice;
            }
        }

        public required Customer OrderedBy { get; set; }

        public DateTimeOffset OrderedDateTimeUTCOffset { get; } = DateTimeOffset.UtcNow.UtcDateTime;

        public required string BillTo { get; set; }
    }
}
