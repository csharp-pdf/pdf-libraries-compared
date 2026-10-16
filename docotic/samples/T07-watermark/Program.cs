// Watermark: an XObject with the text, drawn in the centre of every page (Bit Miracle's "Watermarks & backgrounds"
// code, which uses this text).
// https://bitmiracle.com/pdf-library/edit/#watermarks
using BitMiracle.Docotic.Pdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var output = args.Length > 0 ? args[0] : "output.pdf";
using var pdf = new PdfDocument("invoice.pdf");
var watermark = pdf.CreateXObject();
watermark.DrawOnBackground = true;
var canvas = watermark.Canvas;
canvas.FontSize = 72;
canvas.Brush.Color = new PdfRgbColor(222, 35, 35);
canvas.Brush.Opacity = 45;
canvas.Pen.Color = canvas.Brush.Color;
canvas.Pen.Opacity = canvas.Brush.Opacity;
canvas.Pen.Width = 5;
var padding = 10;
var text = "CONFIDENTIAL";
canvas.DrawString(padding, padding, text);
var textSize = canvas.MeasureText(text);
var watermarkRect = new PdfRectangle(padding, padding, textSize.Width, textSize.Height);
canvas.DrawRoundedRectangle(watermarkRect, new PdfSize(padding, padding));
foreach (var page in pdf.Pages)
{
    page.Canvas.DrawXObject(watermark,
        (page.Width - watermarkRect.Width) / 2,
        (page.Height - watermarkRect.Height) / 2);
}
pdf.Save(output);
