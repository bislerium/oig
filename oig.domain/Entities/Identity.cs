namespace oig.domain.Entities
{
    public abstract class Identity<T> : Entity<T>
    {
        public required string Name { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }

        public required string Email { get; set; }
    }
}
