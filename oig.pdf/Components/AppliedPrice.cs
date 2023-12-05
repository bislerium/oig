using oig.domain.Entities;
using oig.pdf.Extensions;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{
    internal class AppliedPrice : IComponent
    {
        private readonly Order _order;

        public AppliedPrice(Order order)
        {
            _order = order;
        }

        public void Compose(IContainer container)
        {
            container.PaddingLeft(120).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.AddSubTotalRow(_order.SubTotal);
                table.AddDiscountRow(_order.DiscountRate, _order.DiscountableAmount);
                table.AddTaxRow(_order.TaxRate, _order.TaxableAmount);
                table.AddGrandTotalRow(_order.GrandTotal);
            });
        }
    }
}
