using Bogus;
using oig.domain.Entities;

namespace oig.domain.source.faker.Entities
{
    public static class ProductFaker
    {
        private static readonly Faker<Product> _productFaker;

        public static int MinPrice {  get; set; }
        public static int MaxPrice {  get; set; }

        static ProductFaker()
        {
            MinPrice = 100;
            MaxPrice = 10_000;

            _productFaker = new Faker<Product>(Config.Locale)
                .RuleFor(x => x.Id, y => y.Random.AlphaNumeric(10).ToUpper())
                .RuleFor(x => x.Name, y => y.Commerce.ProductName())
                .RuleFor(x => x.Description, y => y.Commerce.ProductDescription())
                .RuleFor(x => x.Price, y => decimal.Parse(y.Commerce.Price(MinPrice, MaxPrice)))
                .FinishWith((x, y) => x.ToString())
                .UseSeed(Config.ProductFakerSeedValue);
        }

        public static Product Generate()
        {
            return _productFaker.Generate();
        }

        public static IEnumerable<Product> GenerateMany(int count = 20)
        {
            return _productFaker.Generate(count);
        }

        public static IEnumerable<Product> GenerateBetween(int min = 5, int max = 60)
        {
            return _productFaker.GenerateBetween(min, max);
        }
    }
}
