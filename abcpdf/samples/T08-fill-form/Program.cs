// Fill a PDF form: Doc.Form[name].Value; a check box is set to its on-state from Field.Options.
// https://www.websupergoo.com/helppdfnet/source/6-abcpdf.objects/field/2-properties/value.htm
// https://www.websupergoo.com/helppdfnet/source/4-examples/15-eform1.htm
using WebSupergoo.ABCpdf14;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

var output = args.Length > 0 ? args[0] : "output.pdf";
using var doc = new Doc();
doc.Read("order-form.pdf");
doc.Form["name"].Value = "Jane Doe";
doc.Form["email"].Value = "jane@example.com";
doc.Form["plan"].Value = "Pro";
var news = doc.Form["news"];
news.Value = news.Options[0];   // the check box's on-state
doc.Save(output);
