// PDFsharp: DigitalSignatureHandler.ForDocument with the built-in PdfSharpDefaultSigner (an X509Certificate2,
// SHA-256); the signature is written when the document is saved. The certificate is a self-signed one created
// here with CertificateRequest and loaded from PKCS#12 bytes, as the DefaultSigner sample loads its .pfx file.
// https://docs.pdfsharp.net/PDFsharp/Topics/PDF-Features/Signatures.html
// https://github.com/empira/PDFsharp.Samples/blob/master/src/samples/src/PDFsharp/src/Pdf.Signatures/DefaultSigner/Program.cs
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using PdfSharp;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Signatures;

PdfSharpLicense.SetAgplLicense();   // required since 6.5.0 (or LoadLicense with a commercial key)

var output = args.Length > 0 ? args[0] : "output.pdf";

using var rsa = RSA.Create(2048);
var request = new CertificateRequest("CN=Sample Signer", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
using var selfSigned = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(1));
using var certificate = new X509Certificate2(selfSigned.Export(X509ContentType.Pfx, "sample"), "sample",
    X509KeyStorageFlags.Exportable);

var document = PdfReader.Open("invoice.pdf", PdfDocumentOpenMode.Modify);
var options = new DigitalSignatureOptions { Reason = "Approved", Location = "Sample" };
DigitalSignatureHandler.ForDocument(document, new PdfSharpDefaultSigner(certificate, PdfMessageDigestType.SHA256), options);
document.Save(output);
