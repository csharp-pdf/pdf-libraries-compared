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
- [Benchmark results](#benchmark-results)
- [Contributing](#contributing)
- [License](#license)

## How libraries are compared

1. **Same tasks for everyone.** Each library gets one sample per task in
   [the standard task set](#the-standard-task-set). A task a library cannot do is
   marked *not supported*, with a link to the source that says so — never left blank.
2. **Samples are real.** Every sample is a compilable console project. Each one is
   built and run, and its output is checked (the PDF opens, has the expected page count,
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

Every library page links one sample per task; how samples are written and checked (including the checker,
[`tools/check_samples.py`](tools/check_samples.py)) is in [`_template/SAMPLES.md`](_template/SAMPLES.md).

## Libraries

| Library | Type |
|---|---|
| [ABCpdf](abcpdf/) | HTML to PDF + PDF library |
| [Docotic.Pdf](docotic/) (with the HtmlToPdf add-on) | PDF library + HTML add-on |
| [IronPDF](ironpdf/) | HTML to PDF + PDF library |
| [iText](itext/) (with pdfHTML) | PDF library + HTML add-on |
| [PDFsharp / MigraDoc](pdfsharp/) | PDF library / document layout |
| [Playwright for .NET](playwright/) | Headless browser automation |
| [PuppeteerSharp](puppeteersharp/) | Headless browser automation |
| [QuestPDF](questpdf/) | Code-first PDF generation |
| [SelectPdf](selectpdf/) | HTML to PDF + PDF library, REST API |
| [wkhtmltopdf](wkhtmltopdf/) (Haukcode.WkHtmlToPdfDotNet, a DinkToPdf fork) | HTML to PDF (wkhtmltopdf wrapper) |

Don't see the library you use? [Request it](https://github.com/csharp-pdf/pdf-libraries-compared/issues/new?template=add-library.yml).

## Benchmark results

- [2026-10-15](benchmarks/2026-10-15.md) — all ten libraries above at their latest versions, on Windows and on
  Linux: HTML to PDF speed, cold start, throughput, memory and stability, output correctness and fidelity, PDF/A and
  PDF/UA output validated with veraPDF, PDF/X, working with existing PDFs and Word files, errors and timeouts,
  and Docker deployment.

Each page is generated from the raw data in
[csharp-pdf/pdf-benchmarks](https://github.com/csharp-pdf/pdf-benchmarks); the harness and fixtures are there, so
any result can be re-run.

## Contributing

Corrections, new samples and library requests are welcome — see
[CONTRIBUTING.md](CONTRIBUTING.md). Vendors are explicitly invited to fix how
their own library is configured or described.

## License

- Text and tutorials: [CC BY 4.0](LICENSE-CONTENT)
- Code samples: [MIT](LICENSE)

Product names are trademarks of their respective owners and are used only to
identify the products compared.
