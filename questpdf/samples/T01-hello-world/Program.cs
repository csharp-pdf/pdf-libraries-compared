// QuestPDF quick start: https://www.questpdf.com/quick-start.html
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

// QuestPDF requires a licence type before the first document (https://www.questpdf.com/license/configuration.html).
// Community applies only to eligible users (https://www.questpdf.com/license/community.html); set the type that applies to you.
QuestPDF.Settings.License = LicenseType.Community;

var output = args.Length > 0 ? args[0] : "output.pdf";

Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.Content().Text("Hello world").FontSize(32).Bold();
    });
})
.GeneratePdf(output);
