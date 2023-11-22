using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{
    internal class Header : IComponent
    {
        public void Compose(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"Invoice #{{}}").Style(titleStyle);

                    column.Item().Text(text =>
                    {
                        text.Span("Issue date: ").SemiBold();
                        text.Span($"{{}}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Due date: ").SemiBold();
                        text.Span($"{{}}");
                    });
                });

                row.ConstantItem(100).Height(50).Placeholder();
            });
        }
    }
}
