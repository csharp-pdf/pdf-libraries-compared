// Stamp a text on every page of an existing PDF with a template.
// Samples: https://selectpdf.com/demo-universal/PdfStamps
//          https://selectpdf.com/demo-universal/PdfWatermarks
using SelectPdf.Universal;

var output = args.Length > 0 ? args[0] : "output.pdf";

// load the existing pdf document
PdfDocument doc = new PdfDocument("invoice.pdf");

// create a new pdf font
PdfFont font = doc.Fonts.Add(PdfStandardFont.HelveticaBold);
font.Size = 60;

// stamp all pages - a template as large as the page repeats on all pdf pages automatically
var page = doc.Pages[0].ClientRectangle;
PdfTemplate template = doc.Templates.Add(page);
PdfTextElement text = new PdfTextElement(page.Width * 0.1f, page.Height * 0.7f, "CONFIDENTIAL", font);
text.Direction = 45;
text.ForeColor = new PdfColor(200, 0, 0);
text.Transparency = 35;
template.Add(text);

// save and close the pdf document
doc.Save(output);
doc.Close();
