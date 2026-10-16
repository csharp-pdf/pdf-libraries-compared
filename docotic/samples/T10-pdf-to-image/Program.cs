// PDF to image: PdfDrawOptions with the resolution, then PdfPage.Save (the SavePageCustomResolution sample).
// https://bitmiracle.com/pdf-library/pdf-image/convert
// https://github.com/BitMiracle/Docotic.Pdf.Samples/tree/master/Samples/Draw%20and%20print%20PDF/SavePageCustomResolution
using BitMiracle.Docotic.Pdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var output = args.Length > 0 ? args[0] : "page-1.png";
using var pdf = new PdfDocument("invoice.pdf");
PdfDrawOptions options = PdfDrawOptions.Create();   // PNG
options.BackgroundColor = new PdfRgbColor(255, 255, 255);
options.HorizontalResolution = 150;
options.VerticalResolution = 150;
pdf.Pages[0].Save(output, options);
