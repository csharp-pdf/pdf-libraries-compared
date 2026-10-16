// PDF/A-2b with the free Conformance add-on: SaveAsPdfa (the ConvertPdfToPdfA sample).
// https://bitmiracle.com/pdf-library/conformance/pdf-to-pdfa
// https://github.com/BitMiracle/Docotic.Pdf.Samples/tree/master/Samples/PdfA/ConvertPdfToPdfA
using BitMiracle.Docotic.Pdf;
using BitMiracle.Docotic.Pdf.Conformance;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var output = args.Length > 0 ? args[0] : "output.pdf";
using var pdf = new PdfDocument("invoice.pdf");
pdf.SaveAsPdfa(output, PdfaConformanceLevel.Pdfa2B);
