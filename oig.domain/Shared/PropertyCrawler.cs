using oig.domain.Attributes;
using System.Reflection;

namespace oig.domain.Shared
{
    public static class PropertyCrawler
    {
        public static IEnumerable<(string PropertyName, Type PropertyType, Object? PropertyValue)> ListPropertiesInfo<T>(T instance) where T : notnull
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (Attribute.IsDefined(property, typeof(SkipPropertyAttribute)))
                    continue;
                yield return (property.Name, property.PropertyType, property.GetValue(instance));
            }
        }
    }
}
