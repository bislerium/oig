using Bogus;
using oig.domain.Entities;

namespace oig.domain.source.faker.Entities
{
    public static class LineItemFaker
    {
        private static readonly Faker<LineItem> _lineItemFaker;

        public static Product Product { get; set; }
        public static int MinQuantity { get; set; }
        public static int MaxQuantity { get; set; }

        static LineItemFaker()
        {
            MinQuantity = 1;
            MaxQuantity = 10_000;
            Product = ProductFaker.Generate();

            _lineItemFaker = new Faker<LineItem>(Config.Locale)
                .RuleFor(x => x.Id, y => y.Random.AlphaNumeric(10))
                .RuleFor(x => x.Product, y => Product)
                .RuleFor(x => x.Quantity, y => y.Random.Int(MinQuantity, MaxQuantity))
                .FinishWith((x, y) => x.ToString())
                .UseSeed(Config.LineItemFakerSeedValue);
        }

        public static LineItem Generate()
        {
            return _lineItemFaker.Generate();
        }

        public static IEnumerable<LineItem> GenerateMany(int min = 5, int max = 40)
        {
            return _lineItemFaker.GenerateBetween(min, max);
        }
    }
}
