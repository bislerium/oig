namespace oig.domain.Entities
{
    public abstract class Identity : Entity<string>
    {
        public required string Name { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }

        public required string Email { get; set; }
    }
}
