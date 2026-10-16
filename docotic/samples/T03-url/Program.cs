// URL to PDF with the free HtmlToPdf add-on: HtmlConverter.CreatePdfAsync.
// https://bitmiracle.com/pdf-library/html-pdf/convert
using BitMiracle.Docotic.Pdf.HtmlToPdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var output = args.Length > 0 ? args[0] : "output.pdf";
using var converter = await HtmlConverter.CreateAsync();
using var pdf = await converter.CreatePdfAsync(new Uri("https://example.com/"));
pdf.Save(output);
