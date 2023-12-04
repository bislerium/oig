using oig.domain.Entities;
using oig.pdf.Components;
using oig.pdf.Extensions;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace oig.pdf.Implementation
{
    public class InvoiceDocument : IDocument
    {
        public Invoice _invoice;

        public InvoiceDocument(Invoice invoice)
        {
           _invoice = invoice;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public DocumentSettings GetSettings() => DocumentSettings.Default;


        public void Compose(IDocumentContainer container)
        {

            container
            .Page(page =>
            {
                page.Size(PageSizes.A6);
                page.Margin(1, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(6));

                page.AddHeader(_invoice);
                page.AddContent(_invoice.Order);

                //page.Content().Component(new Table(_invoice.Order.LineItems));
                page.AddFooter();
            });
        }
    }
}
