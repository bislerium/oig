using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace oig.pdf.Extensions
{
    internal static class ContainerExtensions
    {

        internal static void AddSubTotal(this IContainer container, decimal subTotal)
        {
            container.AlignRight().Text($"SUBTOTAL: {subTotal}$").FontSize(14);
        }
        internal static void AddDiscount(this IContainer container, int discountRate, decimal discountPrice)
        {
            container.AlignRight().Text($"DISCOUNT -{discountRate}%: -{discountPrice}$").FontSize(14);
        }

        internal static void AddTax(this IContainer container, int taxRate, decimal taxPrice)
        {
            container.AlignRight().Text($"TAX {taxRate}%: -{taxPrice}$").FontSize(14);
        }

        internal static void AddGrandTotal(this IContainer container, decimal grandTotal)
        {
            container.AlignRight().Text($"GRAND TOTAL: {grandTotal}$").FontSize(14);
        }
    }
}
