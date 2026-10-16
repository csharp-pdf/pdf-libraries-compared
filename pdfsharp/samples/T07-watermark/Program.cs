// PDFsharp: the "Watermark" sample - an XGraphics on each existing page (XGraphicsPdfPageOptions.Append draws
// above the content), rotated about the page centre, with a semi-transparent brush.
// https://www.pdfsharp.net/wiki/Watermark-sample.ashx (PDFsharp samples; the 1.5 sample pages are reachable from there)
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

PdfSharpLicense.SetAgplLicense();   // required since 6.5.0 (or LoadLicense with a commercial key)
GlobalFontSettings.UseWindowsFontsUnderWindows = true;   // Core build on Windows; elsewhere a font resolver (see T01)

var output = args.Length > 0 ? args[0] : "output.pdf";
var document = PdfReader.Open("invoice.pdf", PdfDocumentOpenMode.Modify);
var font = new XFont("Arial", 72, XFontStyleEx.Bold);
var brush = new XSolidBrush(XColor.FromArgb(80, 200, 0, 0));   // alpha 80 of 255
foreach (var page in document.Pages)
{
    var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);
    gfx.TranslateTransform(page.Width.Point / 2, page.Height.Point / 2);
    gfx.RotateTransform(-45);
    gfx.DrawString("CONFIDENTIAL", font, brush, new XPoint(0, 0), XStringFormats.Center);
}
document.Save(output);
