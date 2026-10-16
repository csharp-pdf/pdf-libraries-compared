// Page size, orientation and margins: HtmlConversionOptions.Page (SetSize, margins in points).
// https://bitmiracle.com/pdf-library/html-pdf/convert#custom-page-settings
using BitMiracle.Docotic.Pdf;
using BitMiracle.Docotic.Pdf.HtmlToPdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var options = new HtmlConversionOptions();
options.Page.SetSize(PdfPaperSize.A4, true);   // true = landscape
const int margin = 57;                           // 20 mm in points (the margins are whole points)
options.Page.MarginLeft = margin;
options.Page.MarginTop = margin;
options.Page.MarginRight = margin;
options.Page.MarginBottom = margin;

var output = args.Length > 0 ? args[0] : "output.pdf";
using var converter = await HtmlConverter.CreateAsync();
using var pdf = await converter.CreatePdfFromStringAsync("<h1>Hello world</h1>", options);
pdf.Save(output);
