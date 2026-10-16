// QuestPDF page settings (size, orientation, margins): https://www.questpdf.com/api-reference/page/settings.html
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

// Set the licence type that applies to you (https://www.questpdf.com/license/configuration.html).
QuestPDF.Settings.License = LicenseType.Community;

var output = args.Length > 0 ? args[0] : "output.pdf";

Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4.Landscape());
        page.Margin(20, Unit.Millimetre);
        page.Content().Text("Hello world").FontSize(32).Bold();
    });
})
.GeneratePdf(output);
