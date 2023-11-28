using Bogus;
using oig.domain.Entities;

namespace oig.domain.source.faker.Entities
{
    public static class InvoiceFaker
    {
        private static readonly Faker<Invoice> _invoiceFaker;

        public static Order Order { get; set; }
        public static int MinInvoiceNumber { get; set; }
        public static int MaxInvoiceNumber { get; set; }

        static InvoiceFaker()
        {
            Order = OrderFaker.Generate();
            MinInvoiceNumber = 1_11_11_111;
            MaxInvoiceNumber = 9_99_99_999;

            _invoiceFaker = new Faker<Invoice>(Config.Locale)
                .RuleFor(x => x.Id, y => y.Random.AlphaNumeric(10))
                .RuleFor(x => x.Order, y => Order)
                .RuleFor(x => x.InvoiceNumber, y => y.Random.Int(MinInvoiceNumber, MaxInvoiceNumber))
                .FinishWith((x, y) => x.ToString())
               .UseSeed(Config.InvoiceFakerSeedValue);
        }

        public static Invoice Generate()
        {
            return _invoiceFaker.Generate();
        }

        public static IEnumerable<Invoice> GenerateMany(int min = 5, int max = 20)
        {
            return _invoiceFaker.GenerateBetween(min, max);
        }
    }
}
