using QuestPDF.Infrastructure;

namespace oig.pdf.Components
{
    internal class Logo : IComponent
    {
        public readonly string _path;

        public Logo(string path)
        {
            _path = path;
        }

        public void Compose(IContainer container)
        {
            container
        }
    }
}
