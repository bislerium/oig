namespace oig.domain.Entities
{
    public class Customer<T>: Entity<T>
    {
        public required string Name { get; set; }

        public required string Email { get; set; }
    }
}
