// QuestPDF Document Settings, PDFA_Conformance: https://www.questpdf.com/concepts/document-settings.html
// QuestPDF writes PDF/A for documents it builds; it does not convert an existing PDF to PDF/A,
// so this sample builds the T2 content (a heading and a 3-row table) as PDF/A-2b.
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

// Set the licence type that applies to you (https://www.questpdf.com/license/configuration.html).
QuestPDF.Settings.License = LicenseType.Community;

var output = args.Length > 0 ? args[0] : "output.pdf";
var rows = new[] { ("Alpha", "120"), ("Beta", "340"), ("Gamma", "560") };

Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.Content().Column(column =>
        {
            column.Spacing(10);
            column.Item().Text("Quarterly report").FontSize(24).Bold();
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });
                table.Header(header =>
                {
                    header.Cell().BorderBottom(1).Padding(4).Text("Product").Bold();
                    header.Cell().BorderBottom(1).Padding(4).AlignRight().Text("Units").Bold();
                });
                foreach (var (name, units) in rows)
                {
                    table.Cell().BorderBottom(0.5f).Padding(4).Text(name);
                    table.Cell().BorderBottom(0.5f).Padding(4).AlignRight().Text(units);
                }
            });
        });
    });
})
.WithMetadata(new DocumentMetadata { Title = "Quarterly report", Language = "en-US" })
.WithSettings(new DocumentSettings { PDFA_Conformance = PDFA_Conformance.PDFA_2B })
.GeneratePdf(output);
