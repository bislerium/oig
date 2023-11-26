namespace oig.domain.Entities
{
    public class Company<T>: Identity<T>
    {
        public required string Slogan { get; set; }

        public required string Website { get; set; }
    }
}
