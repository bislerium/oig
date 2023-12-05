using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Svg.Skia;

namespace oig.pdf.Extensions
{
    public static class SvgExtensions
    {
        public static SKSvg SKSvg { get; }

        static SvgExtensions()
        {
            SKSvg = new SKSvg();
        }

        public static void Svg(this IContainer container, string path)
        {
            SKSvg.Load(path);

            container
                .AlignCenter()
                .AlignMiddle()
                .ScaleToFit()
                .Width(SKSvg.Picture!.CullRect.Width)
                .Height(SKSvg.Picture.CullRect.Height)
                .Canvas((canvas, space) => canvas.DrawPicture(SKSvg.Picture));
        }

    }
}
