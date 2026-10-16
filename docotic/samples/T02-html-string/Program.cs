// HTML string to PDF with the free HtmlToPdf add-on: HtmlConverter.CreatePdfFromStringAsync.
// https://bitmiracle.com/pdf-library/html-pdf/convert
using BitMiracle.Docotic.Pdf.HtmlToPdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var html = """
    <h1>Quarterly report</h1>
    <table>
      <tr><th>Region</th><th>Revenue</th></tr>
      <tr><td>Alpha</td><td>1,200</td></tr>
      <tr><td>Beta</td><td>950</td></tr>
      <tr><td>Gamma</td><td>1,430</td></tr>
    </table>
    """;

// Bit Miracle: in containers, run Chromium without its sandbox (HtmlEngineOptions.UseSandbox = false).
// https://bitmiracle.com/pdf-library/html-pdf/convert-in-azure - the official .NET images set DOTNET_RUNNING_IN_CONTAINER.
var engineOptions = new HtmlEngineOptions
{
    UseSandbox = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") != "true",
};

var output = args.Length > 0 ? args[0] : "output.pdf";
using var converter = await HtmlConverter.CreateAsync(engineOptions);
using var pdf = await converter.CreatePdfFromStringAsync(html);
pdf.Save(output);
