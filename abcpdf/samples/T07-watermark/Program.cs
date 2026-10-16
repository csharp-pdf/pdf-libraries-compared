// Watermark: text added to every page of an existing PDF, as in the Doc.Read example; here rotated 45 degrees about
// the page centre (Doc.Transform) and semi-transparent (the alpha value of Doc.Color).
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/doc/1-methods/read.htm
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/doc/2-properties/transform.htm
using WebSupergoo.ABCpdf14;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

var output = args.Length > 0 ? args[0] : "output.pdf";
using var doc = new Doc();
doc.Read("invoice.pdf");
doc.FontSize = 72;
doc.Color.String = "255 0 0 a80";   // red, alpha 80 of 255
doc.TextStyle.HPos = 0.5;
doc.TextStyle.VPos = 0.5;
int count = doc.PageCount;
for (int i = 1; i <= count; i++)
{
    doc.PageNumber = i;
    doc.Rect.String = doc.CropBox.String;
    doc.Transform.Reset();
    doc.Transform.Rotate(45, doc.Rect.Left + doc.Rect.Width / 2, doc.Rect.Bottom + doc.Rect.Height / 2);
    doc.AddText("CONFIDENTIAL");
}
doc.Save(output);
