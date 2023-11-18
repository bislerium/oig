namespace oig.domain.Entities
{
    public class Company<T>: Entity<T>
    {
        public required string Name { get; set; }

        public required string Slogan { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required string Website { get; set; }

        public required string Address { get; set; }
    }
}
