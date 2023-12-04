using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Svg.Skia;

namespace oig.pdf.Extensions
{
    public static class SvgExtensions
    {
        public static void Svg(this IContainer container, SKSvg svg)
        {
            container
                .AlignCenter()
                .AlignMiddle()
                .ScaleToFit()
                .Width(svg.Picture.CullRect.Width)
                .Height(svg.Picture.CullRect.Height)
                .Canvas((canvas, space) => canvas.DrawPicture(svg.Picture));
        }

    }
}
