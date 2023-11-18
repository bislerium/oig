namespace oig.domain.Entities
{
    public class Product<T>: Entity<T>
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required decimal Price { get; set; }
    }
}
