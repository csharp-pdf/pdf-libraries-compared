// ASP.NET Core minimal API that returns the T2 document, converted with the free HtmlToPdf add-on.
// https://bitmiracle.com/pdf-library/html-pdf/convert
using BitMiracle.Docotic.Pdf.HtmlToPdf;

// Bit Miracle recommends adding the licence in Program.cs of an ASP.NET Core app.
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

var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/report", async () =>
{
    using var converter = await HtmlConverter.CreateAsync(engineOptions);
    using var pdf = await converter.CreatePdfFromStringAsync(html);
    using var stream = new MemoryStream();
    pdf.Save(stream);
    return Results.File(stream.ToArray(), "application/pdf", "report.pdf");
});

app.Run();
