// Page size, orientation and margins: Doc.MediaBox sets the page size, and Doc.Rect, inset from the page edges, is
// the area the HTML is drawn into.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/doc/2-properties/mediabox.htm
// https://www.websupergoo.com/helppdfnet/source/4-examples/13-pagedhtml.htm
using WebSupergoo.ABCpdf14;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

const double mm = 72 / 25.4;   // ABCpdf measures in points

var output = args.Length > 0 ? args[0] : "output.pdf";
using var doc = new Doc();
doc.MediaBox.String = "0 0 842 595";   // A4 (595 x 842 pt) in landscape orientation
doc.Rect.String = doc.MediaBox.String;
doc.Rect.Inset(20 * mm, 20 * mm);      // 20 mm margins on every side
doc.HtmlOptions.Engine = EngineType.Chrome146;
doc.Page = doc.AddPage();
doc.AddImageHtml("<h1>Hello world</h1>");
doc.Save(output);
