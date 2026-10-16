// Digital signature: PdfSigningOptions with the PKCS #12 data, then SignAndSave (the SignDocument sample).
// https://bitmiracle.com/pdf-library/signatures/sign
// https://github.com/BitMiracle/Docotic.Pdf.Samples/tree/master/Samples/Digital%20signatures/SignDocument
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BitMiracle.Docotic.Pdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

// a self-signed certificate for the sample; in practice, use your own .pfx or .p12 file
using var rsa = RSA.Create(2048);
var request = new CertificateRequest("CN=Sample Signer", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
using var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(1));
const string password = "sample";
using var pfx = new MemoryStream(certificate.Export(X509ContentType.Pfx, password));

var output = args.Length > 0 ? args[0] : "output.pdf";
using var pdf = new PdfDocument("invoice.pdf");
var options = new PdfSigningOptions(pfx, password)
{
    DigestAlgorithm = PdfDigestAlgorithm.Sha256,
    Format = PdfSignatureFormat.Pkcs7Detached,
    Reason = "Approved",
};
pdf.SignAndSave(options, output);
