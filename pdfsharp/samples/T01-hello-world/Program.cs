// PDFsharp: a page drawn with XGraphics.DrawString.
// https://docs.pdfsharp.net/PDFsharp/Topics/Start/First-PDF.html
// Fonts: the Core build resolves no fonts by itself. On Windows the documented switch UseWindowsFontsUnderWindows
// reads the Windows fonts folder (meant for development); on other systems a custom IFontResolver must supply the
// font bytes - here one that returns the TrueType file named by the FONT_FILE environment variable.
// https://docs.pdfsharp.net/PDFsharp/Topics/Fonts/Font-Resolving.html
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

// Since 6.5.0 the code must select a licence: the free AGPL licence, or PdfSharpLicense.LoadLicense(key).
PdfSharpLicense.SetAgplLicense();
if (OperatingSystem.IsWindows())
    GlobalFontSettings.UseWindowsFontsUnderWindows = true;
else
    GlobalFontSettings.FontResolver = new FileFontResolver(Environment.GetEnvironmentVariable("FONT_FILE")
        ?? throw new InvalidOperationException("Set FONT_FILE to the path of a TrueType font file."));

var output = args.Length > 0 ? args[0] : "output.pdf";
var document = new PdfDocument();
var page = document.AddPage();
var gfx = XGraphics.FromPdfPage(page);
gfx.DrawString("Hello world", new XFont("Arial", 20), XBrushes.Black,
    new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);
document.Save(output);

// A custom font resolver (IFontResolver) that maps every typeface to one TrueType file.
sealed class FileFontResolver(string path) : IFontResolver
{
    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic) => new("font");
    public byte[]? GetFont(string faceName) => File.ReadAllBytes(path);
}
