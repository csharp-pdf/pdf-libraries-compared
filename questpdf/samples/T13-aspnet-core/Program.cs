// QuestPDF integration with ASP.NET: https://www.questpdf.com/examples/aspnet-integration.html
// QuestPDF has no HTML conversion, so the endpoint returns the T1 document.
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

// Set once at startup; use the licence type that applies to you (https://www.questpdf.com/license/configuration.html).
QuestPDF.Settings.License = LicenseType.Community;

var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/report", () =>
{
    var pdf = Document.Create(container =>
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(2, Unit.Centimetre);
            page.Content().Text("Hello world").FontSize(32).Bold();
        });
    })
    .GeneratePdf();

    return Results.File(pdf, "application/pdf", "report.pdf");
});

app.Run();
