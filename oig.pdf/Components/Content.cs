using oig.domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{
    internal class Content : IComponent
    {
        private readonly Order<int> _order;

        public Content(Order<int> order)
        {
            _order = order;
        }

        public void Compose(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);

                column.Item().Component(new Table(_order.LineItems));

                column.Item().Component(new AppliedPrice(_order));

                if (!string.IsNullOrWhiteSpace(_order.Comments))
                    column.Item().PaddingTop(25).Component(new Comments(_order.Comments));
            });
        }
    }
}
