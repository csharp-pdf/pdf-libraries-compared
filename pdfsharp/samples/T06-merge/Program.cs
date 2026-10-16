// PDFsharp: open each source in Import mode and add its pages to a new document (the "Concatenate Documents"
// sample of the PDFsharp samples; the 1.5 sample pages are reachable from the link below).
// https://www.pdfsharp.net/wiki/ConcatenateDocuments-sample.ashx
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

PdfSharpLicense.SetAgplLicense();   // required since 6.5.0 (or LoadLicense with a commercial key)

var output = args.Length > 0 ? args[0] : "output.pdf";
var document = new PdfDocument();
foreach (var file in new[] { "invoice.pdf", "accessible.pdf" })
{
    var source = PdfReader.Open(file, PdfDocumentOpenMode.Import);
    foreach (var page in source.Pages)
        document.AddPage(page);
}
document.Save(output);
