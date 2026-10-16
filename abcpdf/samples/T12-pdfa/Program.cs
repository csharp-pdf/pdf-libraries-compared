// PDF/A-2b: PdfConformityOperation with Conformance = PdfA2b, as in the PdfConformityOperation Save example.
// The operation needs the Professional licence (the trial runs as the Professional edition).
// https://www.websupergoo.com/helppdfnet/source/8-abcpdf.operations/7-pdfconformityoperation/1-methods/save.htm
// https://www.websupergoo.com/helppdfnet/source/8-abcpdf.operations/7-pdfconformityoperation/2-properties/conformance.htm
using WebSupergoo.ABCpdf14;
using WebSupergoo.ABCpdf14.Operations;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

var output = args.Length > 0 ? args[0] : "output.pdf";
using var doc = new Doc();
doc.Read("invoice.pdf");
using var operation = new PdfConformityOperation();
operation.Conformance = PdfConformance.PdfA2b;
operation.Save(doc, output);
foreach (var error in operation.Errors)   // features that could not be made conformant
    Console.WriteLine(error);
