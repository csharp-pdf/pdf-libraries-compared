// PDFsharp: a new document marked as PDF/A with SetPdfA(), tagged through the UAManager's StructureBuilder, as the
// Archiving article shows; the file declares PDF/A-1a. PDFsharp documents this as an early implementation: no PDF/A
// level can be chosen, and an existing PDF cannot be converted, so the sample draws the T2 content (a heading and
// three rows) itself.
// https://docs.pdfsharp.net/PDFsharp/Topics/PDF-Features/Archiving.html
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility;

PdfSharpLicense.SetAgplLicense();   // required since 6.5.0 (or LoadLicense with a commercial key)
GlobalFontSettings.UseWindowsFontsUnderWindows = true;   // Core build on Windows; elsewhere a font resolver (see T01)

var output = args.Length > 0 ? args[0] : "output.pdf";
var document = new PdfDocument();
document.Info.Title = "Quarterly report";
document.SetPdfA();
var uaManager = UAManager.ForDocument(document);   // PDF/A needs a tagged PDF; tagging comes from the UA manager
var sb = uaManager.StructureBuilder;

var heading = new XFont("Arial", 20, XFontStyleEx.Bold);
var font = new XFont("Arial", 12, XFontStyleEx.Regular);
sb.BeginElement(PdfGroupingElementTag.Article);
{
    var page = document.AddPage();
    var gfx = XGraphics.FromPdfPage(page);
    sb.BeginElement(PdfBlockLevelElementTag.Heading1);
    gfx.DrawString("Quarterly report", heading, XBrushes.Black, 50, 80);
    sb.End();
    var y = 120;
    foreach (var (product, units) in new[] { ("Alpha", 120), ("Beta", 80), ("Gamma", 45) })
    {
        sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
        gfx.DrawString($"{product} {units}", font, XBrushes.Black, 50, y);
        sb.End();
        y += 20;
    }
}
sb.End();
document.Save(output);
