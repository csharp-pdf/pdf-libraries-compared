// URL to PDF with the ABCChrome146 engine: Doc.AddImageUrl, then AddImageToChain while the page continues
// (ABCpdf's Paged HTML example).
// https://www.websupergoo.com/helppdfnet/source/4-examples/13-pagedhtml.htm
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/doc/1-methods/addimageurl.htm
using WebSupergoo.ABCpdf14;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

var output = args.Length > 0 ? args[0] : "output.pdf";
using var doc = new Doc();
doc.HtmlOptions.Engine = EngineType.Chrome146;
doc.Page = doc.AddPage();
int id = doc.AddImageUrl("https://example.com/");
while (doc.Chainable(id))
{
    doc.Page = doc.AddPage();
    id = doc.AddImageToChain(id);
}
doc.Save(output);
