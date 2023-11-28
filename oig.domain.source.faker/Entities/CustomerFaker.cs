using Bogus;
using oig.domain.Entities;

namespace oig.domain.source.faker.Entities
{
    public static class CustomerFaker
    {
        private static readonly Faker<Customer> _customerFaker;

        static CustomerFaker()
        {
            _customerFaker = new Faker<Customer>(Config.Locale)
               .RuleFor(x => x.Id, y => y.Random.AlphaNumeric(10))
               .RuleFor(x => x.Name, y => y.Person.FullName)
               .RuleFor(x => x.Address, y => y.Address.FullAddress())
               .RuleFor(x => x.Email, (y, z) => y.Internet.Email(z.Name))
               .RuleFor(x => x.Phone, y => y.Phone.PhoneNumber())
               .FinishWith((x, y) => x.ToString())
               .UseSeed(Config.CustomerFakerSeedValue);
        }

        public static Customer Generate()
        {
            return _customerFaker.Generate();
        }

        public static IEnumerable<Customer> GenerateMany(int min = 5, int max = 50)
        {
            return _customerFaker.GenerateBetween(min, max);
        }
    }
}
