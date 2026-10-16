// PDFsharp: the AcroForm fields of an opened document, set through their field classes (PdfTextField.Text,
// PdfComboBoxField.Value, PdfCheckBoxField.Checked). PDFsharp documents its AcroForm support as "limited".
// https://docs.pdfsharp.net/PDFsharp/Overview/FAQ.html (Does PDFsharp support AcroForms?)
using PdfSharp;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.IO;

PdfSharpLicense.SetAgplLicense();   // required since 6.5.0 (or LoadLicense with a commercial key)
// Text fields create fonts for their appearance, so the Core build needs fonts here too (see T01).
GlobalFontSettings.UseWindowsFontsUnderWindows = true;

var output = args.Length > 0 ? args[0] : "output.pdf";
var document = PdfReader.Open("order-form.pdf", PdfDocumentOpenMode.Modify);
var fields = document.AcroForm.Fields;
((PdfTextField)fields["name"]).Text = "Jane Doe";
((PdfTextField)fields["email"]).Text = "jane@example.com";
((PdfComboBoxField)fields["plan"]).Value = new PdfString("Pro");
((PdfCheckBoxField)fields["news"]).Checked = true;
document.Save(output);
