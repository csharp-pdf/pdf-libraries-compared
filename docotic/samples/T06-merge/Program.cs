// Merge PDFs: open the first document and append the second (the MergeDocuments sample).
// https://bitmiracle.com/pdf-library/edit/merge
// https://github.com/BitMiracle/Docotic.Pdf.Samples/tree/master/Samples/General%20operations/MergeDocuments
using BitMiracle.Docotic.Pdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var output = args.Length > 0 ? args[0] : "output.pdf";
using var pdf = new PdfDocument("invoice.pdf");
pdf.Append("accessible.pdf");
pdf.Save(output);
