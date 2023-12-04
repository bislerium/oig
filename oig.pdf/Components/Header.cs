using oig.domain.Entities;
using oig.domain.Shared;
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
                        text.Span($"{_invoice.GetLocalInvoiceIssueDateTimeUTCOffset():G}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Due date: ").SemiBold();
                        text.Span($"{_invoice.GetLocalInvoiceDueDateTimeUTCOffset():G}");
                    });
                });

                row.ConstantItem(100).Height(50).Placeholder();
            });
        }
    }
}
