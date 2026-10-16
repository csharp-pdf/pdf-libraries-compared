// QuestPDF Document Operations, merging documents: https://www.questpdf.com/concepts/document-operations.html#merging-documents
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

// Set the licence type that applies to you (https://www.questpdf.com/license/configuration.html).
QuestPDF.Settings.License = LicenseType.Community;

var output = args.Length > 0 ? args[0] : "output.pdf";

DocumentOperation
    .LoadFile("invoice.pdf")
    .MergeFile("accessible.pdf")
    .Save(output);
