// Hello world with the core API: draw the text on the first page's canvas.
// https://bitmiracle.com/pdf-library/create/core-api
using BitMiracle.Docotic.Pdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var output = args.Length > 0 ? args[0] : "output.pdf";
using var pdf = new PdfDocument();
var page = pdf.Pages[0];
page.Canvas.DrawString(50, 50, "Hello world");
pdf.Save(output);
