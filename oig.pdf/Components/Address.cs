using oig.domain.Entities;
using oig.domain.Shared;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{
    internal class Address<T> : IComponent where T : Identity<int>
    {
        private readonly string _title;
        private readonly T _identity;

        internal Address(string title, T identity)
        {
            _title = title;
            _identity = identity;
        }

        public void Compose(IContainer container)
        {
            container.Column(column =>
            {
                column.Spacing(2);

                column.Item().BorderBottom(1).PaddingBottom(5).Text(_title).SemiBold();

                foreach (var (_, _, PropertyValue) in PropertyCrawler.ListPropertiesInfo(_identity))
                {                   
                    if (PropertyValue is not null)
                    {
                        column.Item().Text(PropertyValue.ToString());
                    }
                }
            });
        }
    }
}
