namespace oig.domain.Entities
{
    [ToString]
    public class Company: Identity
    {
        public required string Slogan { get; set; }

        public required string Website { get; set; }
    }
}
