using oig.domain.Entities;
using oig.pdf.Extensions;
using QuestPDF.Fluent;
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
                page.Margin(50);

                page.AddHeader();
                page.AddContent(_invoice.Order);

                page.AddFooter();
            });
        }
    }
}
