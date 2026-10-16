// MigraDoc (on PDFsharp): a section header and footer; AddPageField and AddNumPagesField give "Page N of M".
// https://docs.pdfsharp.net/MigraDoc/DOM/Contents/HeadersAndFooters.html
// https://docs.pdfsharp.net/MigraDoc/DOM/Contents/Fields.html
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Fonts;

PdfSharpLicense.SetAgplLicense();   // required since 6.5.0 (or LoadLicense with a commercial key)
GlobalFontSettings.UseWindowsFontsUnderWindows = true;   // Core build on Windows; elsewhere a font resolver (see T01)

var output = args.Length > 0 ? args[0] : "output.pdf";
var document = new Document();
var section = document.AddSection();
section.Headers.Primary.AddParagraph("Quarterly report");
var footer = section.Footers.Primary.AddParagraph("Page ");
footer.AddPageField();
footer.AddText(" of ");
footer.AddNumPagesField();

section.AddParagraph("Section one", StyleNames.Heading1);
section.AddPageBreak();
section.AddParagraph("Section two", StyleNames.Heading1);
section.AddPageBreak();
section.AddParagraph("Section three", StyleNames.Heading1);

var renderer = new PdfDocumentRenderer { Document = document };
renderer.RenderDocument();
renderer.PdfDocument.Save(output);
