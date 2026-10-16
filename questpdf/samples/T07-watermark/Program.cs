// QuestPDF Document Operations, overlays: https://www.questpdf.com/concepts/document-operations.html#overlays-and-underlays
// The documented watermark route: a PDF page holding the watermark, laid over every page of the input.
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

// Set the licence type that applies to you (https://www.questpdf.com/license/configuration.html).
QuestPDF.Settings.License = LicenseType.Community;

var output = args.Length > 0 ? args[0] : "output.pdf";

// 1. A one-page A4 PDF with a transparent background and the stamp, made with QuestPDF (invoice.pdf is A4).
Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.PageColor(Colors.Transparent);
        page.Content().AlignCenter().AlignMiddle().Rotate(-45)
            .Text("CONFIDENTIAL").FontSize(72).Bold().FontColor(Colors.Red.Medium);
    });
})
.GeneratePdf("watermark.pdf");

// 2. Overlay it on every page: use stamp page 1, then repeat it for the remaining pages.
DocumentOperation
    .LoadFile("invoice.pdf")
    .OverlayFile(new DocumentOperation.LayerConfiguration
    {
        FilePath = "watermark.pdf",
        TargetPages = "1-z",
        SourcePages = "1",
        RepeatSourcePages = "1",
    })
    .Save(output);
