using Bogus;
using oig.domain.Constants;
using oig.domain.Entities;

namespace oig.domain.source.faker.Entities
{
    public static class OrderFaker
    {
        private static readonly Faker<Order> _orderFaker;

        public static int LineItemCount { get; set; }

        static OrderFaker()
        {
            LineItemCount = 10;

            _orderFaker = new Faker<Order>(Config.Locale)
                .RuleFor(x => x.Id, y => y.Random.AlphaNumeric(10).ToUpper())
                .RuleFor(x => x.TaxRate, y => y.Random.Int(RateRules.MIN_TAX_RATE, RateRules.MAX_TAX_RATE))
                .RuleFor(x => x.DiscountRate, y => y.Random.Int(RateRules.MIN_DISCOUNT_RATE, RateRules.MAX_DISCOUNT_RATE))
                .RuleFor(x => x.OrderedBy, y => CustomerFaker.Generate())
                .RuleFor(x => x.OrderedFrom, y => CompanyFaker.Generate())
                .RuleFor(x => x.Comments, y => y.Lorem.Sentences(14, " "))
                .RuleFor(x => x.LineItems, y => new HashSet<LineItem>(LineItemFaker.GenerateMany(LineItemCount)))
                .FinishWith((x, y) => x.ToString())
                .UseSeed(Config.OrderFakerSeedValue);
        }

        public static Order Generate()
        {
            return _orderFaker.Generate();
        }
        public static IEnumerable<Order> GenerateMany(int count = 20)
        {
            return _orderFaker.Generate(count);
        }

        public static IEnumerable<Order> GenerateBetween(int min = 5, int max = 100)
        {
            return _orderFaker.GenerateBetween(min, max);
        }
    }
}
