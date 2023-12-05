using oig.domain.ValueTypes;

namespace oig.domain.Entities
{
    [ToString]
    public class Product : Entity<string>
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required Price Price { get; set; }
    }
}
