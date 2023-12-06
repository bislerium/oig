using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace oig.pdf.Extensions
{
    internal static class TableDescriptorExtensions
    {
        static IContainer CellStyle(IContainer container)
        {
            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).AlignRight().PaddingVertical(5);
        }

        internal static void AddSubTotalRow(this TableDescriptor table, decimal subTotal)
        {
            table.Cell().Row(1).Column(1).Element(CellStyle).Text("SUBTOTAL");
            table.Cell().Row(1).Column(2).Element(CellStyle).Text($"{Config.CurrencySymbol}{subTotal}");
        }
        internal static void AddDiscountRow(this TableDescriptor table, int discountRate, decimal discountPrice)
        {
            table.Cell().Row(2).Column(1).Element(CellStyle).Text($"DISCOUNT {discountRate}%");
            table.Cell().Row(2).Column(2).Element(CellStyle).Text($"-{Config.CurrencySymbol}{Truncate(discountPrice, 2)}");
        }

        internal static void AddTaxRow(this TableDescriptor table, int taxRate, decimal taxPrice)
        {
            table.Cell().Row(3).Column(1).Element(CellStyle).Text($"TAX {taxRate}%");
            table.Cell().Row(3).Column(2).Element(CellStyle).Text($"+{Config.CurrencySymbol}{Truncate(taxPrice, 2)}");
        }

        internal static void AddGrandTotalRow(this TableDescriptor table, decimal grandTotal)
        {
            table.Cell().Row(4).Column(1).Element(CellStyle).Text($"GRAND TOTAL");
            table.Cell().Row(4).Column(2).Element(CellStyle).Text($"+{Config.CurrencySymbol}{Math.Round(grandTotal, MidpointRounding.AwayFromZero)}").Bold();
        }

        private static decimal Truncate(decimal value, int places)
        {
            int _ = (int)Math.Pow(10, places);
            return Math.Truncate(value * _) / _;
        }
    }
}
