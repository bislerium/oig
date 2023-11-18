namespace oig.domain.Entities
{
    public abstract class Entity<T>
    {
        public required T Id { get; set; }
    }
}
