using oig.domain.Entities;
using oig.pdf.Extensions;
using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{
    internal class AppliedPrice : IComponent
    {
        private readonly Order<int> _order;

        public AppliedPrice(Order<int> order)
        {
            _order = order;
        }

        public void Compose(IContainer container)
        {
            container.AddSubTotal(_order.SubTotal);
            container.AddDiscount(_order.DiscountRate, _order.DiscountableAmount);
            container.AddTax(_order.TaxRate, _order.TaxableAmount);
            container.AddGrandTotal(_order.GrandTotal);
        }
    }
}
