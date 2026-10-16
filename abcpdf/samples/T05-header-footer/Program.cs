// Header and footer with page numbers, as in ABCpdf's Headers and Footers example: add the content first, then go
// through the pages and add the header and the "Page N of M" footer to each one.
// https://www.websupergoo.com/helppdfnet/source/4-examples/06-headers.htm
// https://www.websupergoo.com/helppdfnet/source/4-examples/13-pagedhtml.htm
using WebSupergoo.ABCpdf14;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

var html = """
    <h1>Section 1</h1>
    <h1 style="page-break-before: always">Section 2</h1>
    <h1 style="page-break-before: always">Section 3</h1>
    """;

var output = args.Length > 0 ? args[0] : "output.pdf";
using var doc = new Doc();
doc.MediaBox.String = "A4";
doc.Rect.String = doc.MediaBox.String;
doc.Rect.Inset(36, 72);   // room above and below the content for the header and the footer
doc.HtmlOptions.Engine = EngineType.Chrome146;
doc.Page = doc.AddPage();
int id = doc.AddImageHtml(html);
while (doc.Chainable(id))
{
    doc.Page = doc.AddPage();
    id = doc.AddImageToChain(id);
}

int count = doc.PageCount;
doc.FontSize = 12;
doc.TextStyle.HPos = 0.5;   // centred
doc.TextStyle.VPos = 0.5;
for (int i = 1; i <= count; i++)
{
    doc.PageNumber = i;
    doc.Rect.String = "36 780 559 822";   // header band
    doc.AddText("Quarterly report");
    doc.Rect.String = "36 20 559 62";     // footer band
    doc.AddText($"Page {i} of {count}");
}
doc.Save(output);
