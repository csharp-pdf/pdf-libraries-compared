// MigraDoc (on PDFsharp): page format, orientation and margins are set on the section's PageSetup.
// https://docs.pdfsharp.net/MigraDoc/DOM/Formats/PageSetup.html
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Fonts;

PdfSharpLicense.SetAgplLicense();   // required since 6.5.0 (or LoadLicense with a commercial key)
GlobalFontSettings.UseWindowsFontsUnderWindows = true;   // Core build on Windows; elsewhere a font resolver (see T01)

var output = args.Length > 0 ? args[0] : "output.pdf";
var document = new Document();
var section = document.AddSection();
section.PageSetup.PageFormat = PageFormat.A4;
section.PageSetup.Orientation = Orientation.Landscape;
section.PageSetup.TopMargin = Unit.FromMillimeter(20);
section.PageSetup.RightMargin = Unit.FromMillimeter(20);
section.PageSetup.BottomMargin = Unit.FromMillimeter(20);
section.PageSetup.LeftMargin = Unit.FromMillimeter(20);
section.AddParagraph("Hello world");

var renderer = new PdfDocumentRenderer { Document = document };
renderer.RenderDocument();
renderer.PdfDocument.Save(output);
