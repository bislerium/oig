using oig.domain.Entities;
using oig.pdf.Components;
using QuestPDF.Fluent;

namespace oig.pdf.Extensions
{
    internal static class PageDescriptorExtensions
    {
        public static void AddHeader(this PageDescriptor page, Invoice invoice)
        {
            page.Header().Component(new Header(invoice));
        }

        public static void AddContent(this PageDescriptor page, Order order)
        {
            page.Content().PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);

                column.Item().Row(row =>
                {
                    row.RelativeItem().Component(new Address<Company>("From", order.OrderedFrom));
                    row.ConstantItem(50);
                    row.RelativeItem().Component(new Address<Customer>("For", order.OrderedBy));
                });

                column.Item().Component(new Table(order.LineItems));


                column.Item().Component(new AppliedPrice(order));

                if (!string.IsNullOrWhiteSpace(order.Comments))
                    column.Item().PaddingTop(25).Component(new Comments(order.Comments));
            });
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
