// Extract text: PdfDocument.GetText (plain text of all pages; the ExtractText sample).
// https://bitmiracle.com/pdf-library/pdf-text/extract
using BitMiracle.Docotic.Pdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

using var pdf = new PdfDocument("invoice.pdf");
Console.WriteLine(pdf.GetText());
