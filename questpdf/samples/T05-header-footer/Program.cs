// QuestPDF page slots (header, content, footer): https://www.questpdf.com/api-reference/page/slots.html
// Page numbers (CurrentPageNumber, TotalPages): https://www.questpdf.com/api-reference/text/page-numbers.html
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
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);

        // The header and footer are drawn on every page of the page set.
        page.Header().Text("Quarterly report").FontSize(14).SemiBold();

        page.Content().PaddingVertical(1, Unit.Centimetre).Column(column =>
        {
            column.Item().Text("Section 1").FontSize(24).Bold();
            column.Item().PageBreak();
            column.Item().Text("Section 2").FontSize(24).Bold();
            column.Item().PageBreak();
            column.Item().Text("Section 3").FontSize(24).Bold();
        });

        page.Footer().AlignCenter().Text(text =>
        {
            text.Span("Page ");
            text.CurrentPageNumber();
            text.Span(" of ");
            text.TotalPages();
        });
    });
})
.GeneratePdf(output);
