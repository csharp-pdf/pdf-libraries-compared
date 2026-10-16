// Merge PDFs: Doc.Read, then Doc.Append.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/doc/1-methods/append.htm
using WebSupergoo.ABCpdf14;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

var output = args.Length > 0 ? args[0] : "output.pdf";
using var doc = new Doc();
doc.Read("invoice.pdf");
using var other = new Doc();
other.Read("accessible.pdf");
doc.Append(other);
doc.Save(output);
