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
            var titleStyle = TextStyle.Default.FontSize(12).SemiBold().FontColor(Colors.DeepPurple.Medium);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"Invoice #{_invoice.Id}").Style(titleStyle);

                    column.Item().Text(text =>
                    {
                        text.Span("Issue Date: ").SemiBold();
                        text.Span($"{_invoice.GetLocalInvoiceIssueDateTimeUTCOffset():g}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Due Date: ").SemiBold();
                        text.Span($"{_invoice.GetLocalInvoiceDueDateTimeUTCOffset():d}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Balance Due: ").SemiBold();
                        text.Span($"{Config.CurrencySymbol}{Math.Round(_invoice.BalanceDue, MidpointRounding.AwayFromZero)}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("PO Number: ").SemiBold();
                        text.Span($"{_invoice.PONumber}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("PO Date: ").SemiBold();
                        text.Span($"{_invoice.GetLocalPODateTimeUTCOffset():g}");
                    });

                });

                string logoPath = Path.Combine(Directory.GetParent(typeof(RateRules).Assembly.Location)!.FullName, "images", "logo.svg");
                row.ConstantItem(100).Height(60).Svg(logoPath);
            });
        }
    }
}
