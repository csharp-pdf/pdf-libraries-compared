// HTML string to PDF with the ABCChrome146 engine: Doc.AddImageHtml, then AddImageToChain while the content
// continues (ABCpdf's Paged HTML example).
// https://www.websupergoo.com/helppdfnet/source/4-examples/13-pagedhtml.htm
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/doc/1-methods/addimagehtml.htm
using WebSupergoo.ABCpdf14;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

var html = """
    <h1>Quarterly report</h1>
    <table>
      <tr><th>Region</th><th>Revenue</th></tr>
      <tr><td>Alpha</td><td>1,200</td></tr>
      <tr><td>Beta</td><td>950</td></tr>
      <tr><td>Gamma</td><td>1,430</td></tr>
    </table>
    """;

var output = args.Length > 0 ? args[0] : "output.pdf";
using var doc = new Doc();
doc.HtmlOptions.Engine = EngineType.Chrome146;
doc.Page = doc.AddPage();
int id = doc.AddImageHtml(html);
while (doc.Chainable(id))
{
    doc.Page = doc.AddPage();
    id = doc.AddImageToChain(id);
}
doc.Save(output);
