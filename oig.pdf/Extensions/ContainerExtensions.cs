using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace oig.pdf.Extensions
{
    internal static class ContainerExtensions
    {

        internal static void AddSubTotal(this IContainer container, decimal subTotal)
        {
            container.AlignRight().Text($"SUBTOTAL: ${subTotal}");
        }
        internal static void AddDiscount(this IContainer container, int discountRate, decimal discountPrice)
        {
            container.AlignRight().Text($"DISCOUNT -{discountRate}%: -${Truncate(discountPrice, 2)}$");
        }

        internal static void AddTax(this IContainer container, int taxRate, decimal taxPrice)
        {
            container.AlignRight().Text($"TAX {taxRate}%: +${Truncate(taxPrice, 2)}");
        }

        internal static void AddGrandTotal(this IContainer container, decimal grandTotal)
        {
            container
                .AlignRight()
                .Text(text =>
                {
                    text.Span("GRAND TOTAL: ");
                    text.Span($"${Math.Round(grandTotal, MidpointRounding.AwayFromZero)}").Bold();
                });            
        }

        private static decimal Truncate(decimal value, int places)
        {
            int _ = (int) Math.Pow(10, places);
            return Math.Truncate(value * _) / _;
        }
    }
}
