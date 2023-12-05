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
            container.Column(column =>
            {
                column.Spacing(2);
                column.Item().AddSubTotal(_order.SubTotal);
                column.Item().AddDiscount(_order.DiscountRate, _order.DiscountableAmount);
                column.Item().AddTax(_order.TaxRate, _order.TaxableAmount);
                column.Item().AddGrandTotal(_order.GrandTotal);
            });

        }
    }
}
