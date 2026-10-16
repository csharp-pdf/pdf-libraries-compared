// Digital signature: XForm.AddSignature (an empty rectangle makes an invisible field), then Signature.Sign with the
// PKCS #12 data of the certificate (SHA-256 is the default digest).
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xform/1-methods/addsignature.htm
// https://www.websupergoo.com/helppdfnet/source/6-abcpdf.objects/signature/1-methods/sign.htm
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using WebSupergoo.ABCpdf14;

// Windows runs a 30-day trial without a key; Linux needs one.
// https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm
var key = Environment.GetEnvironmentVariable("ABCPDF_LICENSE_KEY");
if (!string.IsNullOrEmpty(key))
    XSettings.InstallLicense(key);

// a self-signed certificate for the sample; in practice, use your own PFX file
using var rsa = RSA.Create(2048);
var request = new CertificateRequest("CN=Sample Signer", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
using var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(1));
const string password = "sample";
byte[] pfx = certificate.Export(X509ContentType.Pfx, password);

var output = args.Length > 0 ? args[0] : "output.pdf";
using var doc = new Doc();
doc.Read("invoice.pdf");
doc.PageNumber = 1;
var signature = doc.Form.AddSignature(new XRect(), "Signature1");
signature.Reason = "Approved";
signature.Sign(pfx, password);
doc.Save(output);
