using oig.domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{
    internal class Table : IComponent
    {
        private readonly ISet<LineItem<int>> _lineItems;

        public Table(ISet<LineItem<int>> lineItems)
        {
            _lineItems = lineItems;
        }

        public void Compose(IContainer container)
        {
            container.Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // step 2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("#");
                    header.Cell().Element(CellStyle).Text("Product");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                    header.Cell().Element(CellStyle).AlignRight().Text("Quantity");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                // step 3
                int count = 0;
                foreach (var item in _lineItems)
                {
                    table.Cell().Element(CellStyle).Text((count++).ToString());
                    table.Cell().Element(CellStyle).Text(item.Product.Name);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Product.Price}$");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity.ToString());
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.LineTotal}$");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }
    }
}
