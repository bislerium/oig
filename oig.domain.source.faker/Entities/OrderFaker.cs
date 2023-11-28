using Bogus;
using oig.domain.Constants;
using oig.domain.Entities;

namespace oig.domain.source.faker.Entities
{
    public static class OrderFaker
    {
        private static readonly Faker<Order> _orderFaker;

        public static Customer OrderedBy { get; set; }
        public static Company OrderedFrom { get; set; }
        public static ISet<LineItem> LineItems { get; set; }

        static OrderFaker()
        {
            OrderedBy = CustomerFaker.Generate();
            OrderedFrom = CompanyFaker.Generate();
            LineItems = new HashSet<LineItem>(LineItemFaker.GenerateMany());

            _orderFaker = new Faker<Order>(Config.Locale)
                .RuleFor(x => x.Id, y => y.Random.AlphaNumeric(10))
                .RuleFor(x => x.TaxRate, y => y.Random.Int(RateRules.MIN_TAX_RATE, RateRules.MAX_TAX_RATE))
                .RuleFor(x => x.DiscountRate, y => y.Random.Int(RateRules.MIN_DISCOUNT_RATE, RateRules.MAX_DISCOUNT_RATE))
                .RuleFor(x => x.OrderedBy, y => OrderedBy)
                .RuleFor(x => x.OrderedFrom, y => OrderedFrom)
                .RuleFor(x => x.Comments, y => y.Lorem.Sentences(3))
                .RuleFor(x => x.LineItems, y => LineItems)
                .FinishWith((x, y) => x.ToString())
                .UseSeed(Config.OrderFakerSeedValue);
        }

        public static Order Generate()
        {
            return _orderFaker.Generate();
        }

        public static IEnumerable<Order> GenerateMany(int min = 5, int max = 100)
        {
            return _orderFaker.GenerateBetween(min, max);
        }
    }
}
