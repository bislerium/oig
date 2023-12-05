using oig.domain.Attributes;

namespace oig.domain.Entities
{
    public abstract class Entity<T>
    {
        [SkipProperty]
        public required T Id { get; set; }
    }
}
