using Bogus;
using oig.domain.Entities;

namespace oig.domain.source.faker.Entities
{
    public static class LineItemFaker
    {
        private static readonly Faker<LineItem> _lineItemFaker;
        public static int MinQuantity { get; set; }
        public static int MaxQuantity { get; set; }

        static LineItemFaker()
        {
            MinQuantity = 1;
            MaxQuantity = 100;

            _lineItemFaker = new Faker<LineItem>(Config.Locale)         
                .RuleFor(x => x.Product, y => ProductFaker.Generate())
                .RuleFor(x => x.Id, y => y.Random.AlphaNumeric(10).ToUpper())
                .RuleFor(x => x.Quantity, y => y.Random.Int(MinQuantity, MaxQuantity))
                .FinishWith((x, y) => x.ToString())
                .UseSeed(Config.LineItemFakerSeedValue);
        }

        public static LineItem Generate()
        {
            return _lineItemFaker.Generate();
        }

        public static IEnumerable<LineItem> GenerateMany(int count = 20)
        {
            return _lineItemFaker.Generate(count);
        }

        public static IEnumerable<LineItem> GenerateBetween(int min = 5, int max = 40)
        {
            return _lineItemFaker.GenerateBetween(min, max);
        }
    }
}
