using oig.domain.Constants;

namespace oig.domain.Entities
{
    [ToString]
    public class Order: Entity<string>
    { 
        public required ISet<LineItem> LineItems { get; set; }

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
                if (value is >= RateRules.MIN_TAX_RATE and <= RateRules.MAX_TAX_RATE)
                {
                    _taxRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(TaxRate), $"Tax rate must be exclusively between {RateRules.MIN_TAX_RATE} and {RateRules.MAX_TAX_RATE}!");
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
                if (value is >= RateRules.MIN_DISCOUNT_RATE and <= RateRules.MAX_DISCOUNT_RATE)
                {
                    _discountRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(DiscountRate), $"Discount rate must be exclusively between {RateRules.MIN_DISCOUNT_RATE} and {RateRules.MAX_DISCOUNT_RATE}!");
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

        public required Customer OrderedBy { get; set; }

        public required Company OrderedFrom { get; set; }

        public DateTimeOffset OrderedDateTimeUTCOffset { get; } = DateTimeOffset.UtcNow.UtcDateTime;

        public string? Comments { get; set; }
    }
}
