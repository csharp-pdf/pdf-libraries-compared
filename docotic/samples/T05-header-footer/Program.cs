// Header and footer templates: HtmlConversionOptions.Page.HeaderTemplate / FooterTemplate, with the pageNumber and
// totalPages variables, inline styles and explicit top and bottom margins, as Bit Miracle recommends.
// https://bitmiracle.com/pdf-library/html-pdf/convert#header-footer
using BitMiracle.Docotic.Pdf.HtmlToPdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var html = """
    <h1>Section 1</h1>
    <h1 style="page-break-before: always">Section 2</h1>
    <h1 style="page-break-before: always">Section 3</h1>
    """;

var options = new HtmlConversionOptions();
options.Page.HeaderTemplate =
    "<div style=\"font-size: 10px; width: 100%; text-align: center\">Quarterly report</div>";
options.Page.MarginTop = 50;
options.Page.FooterTemplate =
    "<div style=\"font-size: 10px; width: 100%; text-align: center\">" +
    "Page <span class=\"pageNumber\"></span> of <span class=\"totalPages\"></span></div>";
options.Page.MarginBottom = 50;

var output = args.Length > 0 ? args[0] : "output.pdf";
using var converter = await HtmlConverter.CreateAsync();
using var pdf = await converter.CreatePdfFromStringAsync(html, options);
pdf.Save(output);
