// PDF to image, as in ABCpdf's PDF Rendering example: Rendering.DotsPerInch, Rect = CropBox, Rendering.Save.
// https://www.websupergoo.com/helppdfnet/source/4-examples/19-rendering.htm
using WebSupergoo.ABCpdf14;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

var output = args.Length > 0 ? args[0] : "page-1.png";
using var doc = new Doc();
doc.Read("invoice.pdf");
doc.Rendering.DotsPerInch = 150;
doc.PageNumber = 1;
doc.Rect.String = doc.CropBox.String;
doc.Rendering.Save(output);   // the image format follows the file extension
