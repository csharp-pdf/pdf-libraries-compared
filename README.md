# C# and .NET PDF Libraries Compared

Side-by-side pages, compilable samples and tutorials for C# / .NET PDF
libraries — HTML to PDF converters, PDF generation and editing SDKs, and REST
APIs. Every library is put through the **same set of tasks**, and the
performance numbers come from a public harness you can run yourself:
[csharp-pdf/pdf-benchmarks](https://github.com/csharp-pdf/pdf-benchmarks).

> **Disclosure:** this repository is maintained by [SelectPdf](https://selectpdf.com/),
> which makes a .NET PDF library and an HTML to PDF API that are included in these
> comparisons. To keep that honest: every fact links to its source with the date it
> was checked, every number is reproducible, results are published where SelectPdf
> is behind as well as where it leads, and any vendor can
> [request a correction](https://github.com/csharp-pdf/pdf-libraries-compared/issues/new?template=correction.yml).

---

## Contents

- [How libraries are compared](#how-libraries-are-compared)
- [The standard task set](#the-standard-task-set)
- [Libraries](#libraries)
- [Contributing](#contributing)
- [License](#license)

## How libraries are compared

1. **Same tasks for everyone.** Each library gets one sample per task in
   [the standard task set](#the-standard-task-set). A task a library cannot do is
   marked *not supported*, with a link to the source that says so — never left blank.
2. **Samples are real.** Every sample is a compilable console project. CI builds
   and runs it and checks the output (the PDF opens, has the expected page count,
   contains the expected text).
3. **Facts are sourced and dated.** Licence, price, platforms, frameworks and
   versions link to the vendor's own page or the NuGet listing, with the date
   they were last verified.
4. **No star ratings, no overall score.** Measurements are reported per axis
   (speed, memory, fidelity, standards, deployment, cost) so you can weigh what
   matters for your project. The method is in
   [pdf-benchmarks/METHODOLOGY.md](https://github.com/csharp-pdf/pdf-benchmarks/blob/main/METHODOLOGY.md).

## The standard task set

| # | Task |
|---|---|
| T1 | Hello world PDF |
| T2 | HTML string to PDF |
| T3 | URL to PDF |
| T4 | Page size, margins and orientation |
| T5 | Header and footer with page numbers |
| T6 | Merge PDFs |
| T7 | Watermark / stamp |
| T8 | Fill a PDF form |
| T9 | Extract text |
| T10 | PDF to image |
| T11 | Digital signature |
| T12 | PDF/A output (validated with veraPDF) |
| T13 | ASP.NET Core endpoint that returns a PDF |
| T14 | Linux / Docker deployment |

## Libraries

| Library | Type |
|---|---|
| Aspose.PDF | PDF library |
| IronPDF | HTML to PDF + PDF library |
| iText (with pdfHTML) | PDF library + HTML add-on |
| PDFsharp / MigraDoc | PDF library / document layout |
| Playwright for .NET | Headless browser automation |
| PuppeteerSharp | Headless browser automation |
| QuestPDF | Code-first PDF generation |
| SelectPdf | HTML to PDF + PDF library, REST API |
| Spire.PDF | PDF library |
| wkhtmltopdf via DinkToPdf | HTML to PDF (wkhtmltopdf wrapper) |

Don't see the library you use? [Request it](https://github.com/csharp-pdf/pdf-libraries-compared/issues/new?template=add-library.yml).

## Contributing

Corrections, new samples and library requests are welcome — see
[CONTRIBUTING.md](CONTRIBUTING.md). Vendors are explicitly invited to fix how
their own library is configured or described.

## License

- Text and tutorials: [CC BY 4.0](LICENSE-CONTENT)
- Code samples: [MIT](LICENSE)

Product names are trademarks of their respective owners and are used only to
identify the products compared.
