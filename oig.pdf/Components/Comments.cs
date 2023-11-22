using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{
    internal class Comments : IComponent
    {
        private readonly string _components;

        public Comments(string components)
        {
            _components = components;
        }

        public void Compose(IContainer container)
        {
            container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Comments").FontSize(14);
                column.Item().Text(_components);
            });
        }
    }
}
