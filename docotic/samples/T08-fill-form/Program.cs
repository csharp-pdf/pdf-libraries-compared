// Fill a PDF form: go through the controls and set each one by name (the FillForm sample).
// https://bitmiracle.com/pdf-library/pdf-forms
// https://github.com/BitMiracle/Docotic.Pdf.Samples/tree/master/Samples/Forms%20and%20Annotations/FillForm
using BitMiracle.Docotic.Pdf;

// A licence key is required (a free time-limited key is available from Bit Miracle).
// https://bitmiracle.com/pdf-library/trial-restrictions
BitMiracle.Docotic.LicenseManager.AddLicenseData(Environment.GetEnvironmentVariable("DOCOTIC_LICENSE_KEY") ?? "");

var output = args.Length > 0 ? args[0] : "output.pdf";
using var pdf = new PdfDocument("order-form.pdf");
foreach (PdfControl control in pdf.GetControls())
{
    switch (control.Name)
    {
        case "name":
            ((PdfTextBox)control).Text = "Jane Doe";
            break;
        case "email":
            ((PdfTextBox)control).Text = "jane@example.com";
            break;
        case "plan":
            ((PdfComboBox)control).Text = "Pro";
            break;
        case "news":
            ((PdfCheckBox)control).Checked = true;
            break;
    }
}
pdf.Save(output);
