using oig.domain.Constants;
using oig.domain.Entities;
using oig.domain.Shared;
using oig.pdf.Extensions;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{
    internal class Header : IComponent
    {
        private readonly Invoice _invoice;

        public Header(Invoice invoice)
        {
            _invoice = invoice;
        }

        public void Compose(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(14).SemiBold().FontColor(Colors.DeepPurple.Medium);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"Invoice #{_invoice.Id}").Style(titleStyle);

                    column.Item().Text(text =>
                    {
                        text.Span("Issue date: ").SemiBold();
                        text.Span($"{_invoice.GetLocalInvoiceIssueDateTimeUTCOffset():g}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Due date: ").SemiBold();
                        text.Span($"{_invoice.GetLocalInvoiceDueDateTimeUTCOffset():d}");
                    });
                });

                string logoPath = Path.Combine(Directory.GetParent(typeof(RateRules).Assembly.Location)!.FullName, "images", "logo.svg");
                row.ConstantItem(100).Height(50).Svg(logoPath);
            });
        }
    }
}
