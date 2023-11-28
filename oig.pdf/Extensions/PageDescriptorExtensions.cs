using oig.domain.Entities;
using oig.pdf.Components;
using QuestPDF.Fluent;

namespace oig.pdf.Extensions
{
    internal static class PageDescriptorExtensions
    {
        public static void AddHeader(this PageDescriptor page)
        {
            page.Header().Component(new Header());
        }

        public static void AddContent(this PageDescriptor page, Order order)
        {
            page.Header().Component(new Content(order));
        }

        public static void AddFooter(this PageDescriptor page)
        {
            page.Footer().AlignCenter().Text(x =>
            {
                x.CurrentPageNumber();
                x.Span(" / ");
                x.TotalPages();
            });
        }
    }
}
