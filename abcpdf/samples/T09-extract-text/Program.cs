// Extract text: Doc.GetText for each page (text in layout order).
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/doc/1-methods/gettext.htm
using WebSupergoo.ABCpdf14;
using WebSupergoo.ABCpdf14.Objects;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

using var doc = new Doc();
doc.Read("invoice.pdf");
for (int i = 1; i <= doc.PageCount; i++)
{
    doc.PageNumber = i;
    Console.WriteLine(doc.GetText(Page.TextType.Text, false));
}
