// ASP.NET Core minimal API returning the T1 document (PDFsharp has no HTML conversion), saved to a MemoryStream.
// https://docs.pdfsharp.net/General/Overview/FAQ.html (Save PDF to MemoryStream; PDFsharp on web servers)
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

PdfSharpLicense.SetAgplLicense();   // required since 6.5.0 (or LoadLicense with a commercial key)
GlobalFontSettings.UseWindowsFontsUnderWindows = true;   // Core build on Windows; elsewhere a font resolver (see T01)

var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/report", () =>
{
    var document = new PdfDocument();
    var page = document.AddPage();
    var gfx = XGraphics.FromPdfPage(page);
    gfx.DrawString("Hello world", new XFont("Arial", 20), XBrushes.Black,
        new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);
    var stream = new MemoryStream();
    document.Save(stream, false);
    return Results.File(stream.ToArray(), "application/pdf", "report.pdf");
});

app.Run();
