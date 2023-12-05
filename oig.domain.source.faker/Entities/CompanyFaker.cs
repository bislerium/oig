using Bogus;
using oig.domain.Entities;

namespace oig.domain.source.faker.Entities
{
    public static class CompanyFaker
    {
        private static readonly Faker<Company> _companyFaker;

        static CompanyFaker()
        {
            _companyFaker = new Faker<Company>(Config.Locale)
                .RuleFor(x => x.Id, y => y.Random.AlphaNumeric(10).ToUpper())
                .RuleFor(x => x.Id, y => y.Random.AlphaNumeric(10))
                .RuleFor(x => x.Name, y => y.Company.CompanyName())
                .RuleFor(x => x.Address, y => y.Address.FullAddress())
                .RuleFor(x => x.Email, (y, z) => y.Internet.Email(z.Name))
                .RuleFor(x => x.Phone, y => y.Phone.PhoneNumber())
                .RuleFor(x => x.Slogan, y => y.Company.CatchPhrase())
                .RuleFor(x => x.Website, y => y.Internet.DomainName())
                .FinishWith((x, y) => x.ToString())
                .UseSeed(Config.CompanyFakerSeedValue);
        }

        public static Company Generate()
        {
            return _companyFaker.Generate();
        }

        public static IEnumerable<Company> GenerateMany(int count = 20)
        {
            return _companyFaker.Generate(count);
        }

        public static IEnumerable<Company> GenerateMany(int min = 5, int max = 50)
        {
            return _companyFaker.GenerateBetween(min, max);
        }
    }
}
