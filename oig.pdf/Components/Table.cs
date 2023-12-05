using oig.domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{

    public struct OrdersTableState
    {
        public int ShownItemsCount { get; set; }
    }

    /*public class Table : IDynamicComponent<OrdersTableState>
    {
        private ICollection<LineItem> Items { get; }
        public OrdersTableState State { get; set; }

        public Table(ICollection<LineItem> items)
        {
            Items = items;

            State = new OrdersTableState
            {
                ShownItemsCount = 0
            };
        }

        public DynamicComponentComposeResult Compose(DynamicContext context)
        {
            var header = ComposeHeader(context);
            var sampleFooter = ComposeFooter(context, Enumerable.Empty<LineItem>());
            var decorationHeight = header.Size.Height + sampleFooter.Size.Height;

            var rows = GetItemsForPage(context, decorationHeight).ToList();
            var footer = ComposeFooter(context, rows.Select(x => x.Item));

            var content = context.CreateElement(container =>
            {
                container.MinimalBox().Decoration(decoration =>
                {
                    decoration.Before().Element(header);

                    decoration.Content().Column(column =>
                    {
                        foreach (var row in rows)
                            column.Item().Element(row.Element);
                    });

                    decoration.After().Element(footer);
                });
            });

            State = new OrdersTableState
            {
                ShownItemsCount = State.ShownItemsCount + rows.Count
            };

            return new DynamicComponentComposeResult
            {
                Content = content,
                HasMoreContent = State.ShownItemsCount < Items.Count
            };
        }

        private IDynamicElement ComposeHeader(DynamicContext context)
        {
            return context.CreateElement(element =>
            {
                element
                    .Width(context.AvailableSize.Width)
                    .BorderBottom(1)
                    .BorderColor(Colors.Grey.Darken2)
                    .Padding(5)
                    .DefaultTextStyle(TextStyle.Default.SemiBold())
                    .Row(row =>
                    {
                        row.ConstantItem(30).Text("#");
                        row.RelativeItem().Text("Item name");
                        row.ConstantItem(50).AlignRight().Text("Count");
                        row.ConstantItem(50).AlignRight().Text("Price");
                        row.ConstantItem(50).AlignRight().Text("Total");
                    });
            });
        }

        private IDynamicElement ComposeFooter(DynamicContext context, IEnumerable<LineItem> items)
        {
            var total = items.Sum(x => x.LineTotal);

            return context.CreateElement(element =>
            {
                element
                    .Width(context.AvailableSize.Width)
                    .Padding(5)
                    .AlignRight()
                    .DefaultTextStyle(TextStyle.Default.FontSize(14).SemiBold())
                    .Text($"Subtotal: {total}$");
            });
        }

        private IEnumerable<(LineItem Item, IDynamicElement Element)> GetItemsForPage(DynamicContext context, float decorationHeight)
        {
            var totalHeight = decorationHeight;

            foreach (var index in Enumerable.Range(State.ShownItemsCount, Items.Count - State.ShownItemsCount))
            {
                var item = Items.ElementAt(index);

                var element = context.CreateElement(content =>
                {
                    content
                        .Width(context.AvailableSize.Width)
                        .BorderBottom(1)
                        .BorderColor(Colors.Grey.Lighten2)
                        .Padding(5)
                        .Row(row =>
                        {
                            row.ConstantItem(30).Text(index + 1);
                            row.RelativeItem().Text(item.Product.Name);
                            row.ConstantItem(50).AlignRight().Text(item.Quantity);
                            row.ConstantItem(50).AlignRight().Text($"{item.Product.Price}$");
                            row.ConstantItem(50).AlignRight().Text($"{item.LineTotal}$");
                        });
                });

                var elementHeight = element.Size.Height;

                if (totalHeight + elementHeight > context.AvailableSize.Height)
                    break;

                totalHeight += elementHeight;
                yield return (item, element);
            }
        }
    }*/


    internal class Table : IComponent
    {
        private readonly ISet<LineItem> _lineItems;

        public Table(ISet<LineItem> lineItems)
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
                    columns.ConstantColumn(20);
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
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Product.Price.CurrencySymbol}{item.Product.Price.Value}");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity.ToString());
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Product.Price.CurrencySymbol}{item.LineTotal}");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }
    }

}
