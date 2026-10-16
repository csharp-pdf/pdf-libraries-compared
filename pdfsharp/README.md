# PDFsharp / MigraDoc

PDFsharp is a .NET library for creating and modifying PDF documents; MigraDoc, built on PDFsharp, lays out
documents from its own document object model (paragraphs, tables, headers and footers) and renders them to PDF
([PDFsharp features](https://docs.pdfsharp.net/PDFsharp/Overview/Features.html),
[nuget.org](https://www.nuget.org/packages/PDFsharp/6.5.0)).

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | empira Software GmbH (PDFsharp Team) | [Licence page](https://docs.pdfsharp.net/General/License/License.html), [nuget.org](https://www.nuget.org/packages/PDFsharp/6.5.0) | verified 2026-10-16 |
| Licence | Dual licence: AGPL-3.0 or commercial, since 6.5.0 (6.2.4 and earlier: MIT) | [Licence page](https://docs.pdfsharp.net/General/License/License.html), [nuget.org licence (6.5.0: AGPL-3.0-only)](https://www.nuget.org/packages/PDFsharp/6.5.0/license), [6.2.4: MIT](https://www.nuget.org/packages/PDFsharp/6.2.4) | verified 2026-10-16 |
| Price (entry) | EUR 750 (excl. VAT, business customers), perpetual, no subscription; unlimited developers, projects, servers and deployments; includes updates for the 6.5.x and 7.0.x lines | [Pricing](https://www.pdfsharp.com/Pricing) | verified 2026-10-16 |
| Free tier / trial limits | AGPL licence is free: "Use in closed-source projects prohibited", your project must be AGPL-licensed too. No trial is mentioned; the AGPL build has no watermark or page limit in the samples here | [Pricing](https://www.pdfsharp.com/Pricing) | verified 2026-10-16 |
| NuGet package(s) | `PDFsharp` (Core build), `PDFsharp-MigraDoc` (depends on `PDFsharp`); Windows-only `-GDI` and `-WPF` flavours | [NuGet packages](https://docs.pdfsharp.net/General/Overview/NuGet-Packages.html) | verified 2026-10-16 |
| Latest version | 6.5.0 (7.0.0-preview-2 also published) | [PDFsharp](https://www.nuget.org/packages/PDFsharp/6.5.0), [PDFsharp-MigraDoc](https://www.nuget.org/packages/PDFsharp-MigraDoc/6.5.0) | verified 2026-10-16 |
| Target frameworks | .NET 8, .NET 9, .NET 10, .NET Standard 2.0 | [nuget.org "Frameworks" tab](https://www.nuget.org/packages/PDFsharp/6.5.0#supportedframeworks-body-tab) | verified 2026-10-16 |
| Operating systems | Core build: any OS supported by .NET (fonts must come from a font resolver); GDI and WPF builds: Windows only | [General FAQ](https://docs.pdfsharp.net/General/Overview/FAQ.html), [NuGet packages](https://docs.pdfsharp.net/General/Overview/NuGet-Packages.html) | verified 2026-10-16 |
| Rendering engine (HTML to PDF) | None (no HTML conversion) | [PDFsharp FAQ](https://docs.pdfsharp.net/PDFsharp/Overview/FAQ.html) | verified 2026-10-16 |
| Native dependencies | None (written in C#; NuGet dependencies are Microsoft.Extensions.Logging.Abstractions and System.Security.Cryptography.Pkcs) | [General FAQ](https://docs.pdfsharp.net/General/Overview/FAQ.html), [nuget.org "Dependencies" tab](https://www.nuget.org/packages/PDFsharp/6.5.0#dependencies-body-tab) | verified 2026-10-16 |
| Latest release date | 2026-10-14 (6.5.0 on nuget.org) | [nuget.org versions](https://www.nuget.org/packages/PDFsharp#versions-body-tab) | verified 2026-10-16 |

## Install

```bash
dotnet add package PDFsharp --version 6.5.0
dotnet add package PDFsharp-MigraDoc --version 6.5.0   # document layout (T4, T5)
```

## Supported tasks

| # | Task | Status | Sample |
|---|---|---|---|
| T1 | Hello world PDF | supported | [T01-hello-world](samples/T01-hello-world/Program.cs) |
| T2 | HTML string to PDF | not supported: "No, not 'out of the box', and we do not plan to write such a converter in the near future" ([PDFsharp FAQ](https://docs.pdfsharp.net/PDFsharp/Overview/FAQ.html)) | — |
| T3 | URL to PDF | not supported (no HTML conversion, [PDFsharp FAQ](https://docs.pdfsharp.net/PDFsharp/Overview/FAQ.html)) | — |
| T4 | Page size, margins and orientation | supported (MigraDoc) | [T04-page-setup](samples/T04-page-setup/Program.cs) |
| T5 | Header and footer with page numbers | supported (MigraDoc) | [T05-header-footer](samples/T05-header-footer/Program.cs) |
| T6 | Merge PDFs | supported | [T06-merge](samples/T06-merge/Program.cs) |
| T7 | Watermark / stamp | supported | [T07-watermark](samples/T07-watermark/Program.cs) |
| T8 | Fill a PDF form | supported (AcroForm support is documented as limited; see Gotchas) | [T08-fill-form](samples/T08-fill-form/Program.cs) |
| T9 | Extract text | not supported: "There are no high-level functions that return words, paragraphs, or whole pages" ([PDFsharp FAQ](https://docs.pdfsharp.net/PDFsharp/Overview/FAQ.html)) | — |
| T10 | PDF to image | not supported: PDFsharp "cannot render PDF files"; its samples invoke GhostScript to create images ([PDFsharp FAQ](https://docs.pdfsharp.net/PDFsharp/Overview/FAQ.html)) | — |
| T11 | Digital signature | supported | [T11-digital-signature](samples/T11-digital-signature/Program.cs) |
| T12 | PDF/A output | supported, PDF/A-1a only for new documents (`SetPdfA()` takes no level; existing PDFs cannot be converted) | [T12-pdfa](samples/T12-pdfa/Program.cs) |
| T13 | ASP.NET Core endpoint | supported (returns the T1 document) | [T13-aspnet-core](samples/T13-aspnet-core/Program.cs) |
| T14 | Linux / Docker deployment | supported (builds T1) | [docker/Dockerfile](docker/Dockerfile) |

## Benchmark results

<!-- benchmark-results: generated, do not edit -->

From the [2026-10-15 run](../benchmarks/2026-10-15.md) (Windows and Linux on the same machine; method and raw data are linked there). Each value is this library's own result; compare it with the other libraries on the results page.

|  | Result |
|---|---|
| Working with existing PDFs and Word files (Windows) | all checks pass: merge, split, watermark, signature; some checks fail: form filling (7/8 checks); not supported: text extraction, search, PDF to image, Word to PDF, redaction, ZUGFeRD/Factur-X |
| Docker, minimal image | runs, 77 MB |

## Gotchas

- **The code must select a licence (6.5.0 and later).** "Beginning with version 6.5.0, your code must select the
  type of license to be used": `PdfSharpLicense.SetAgplLicense()` for the free AGPL licence or
  `PdfSharpLicense.LoadLicense(...)` for a commercial key; without it PDFsharp throws exceptions
  ([History, 6.5.0](https://docs.pdfsharp.net/General/History.html#ps-6-5-0),
  [Load a licence](https://docs.pdfsharp.net/General/License/License-loading.html)). Every sample here calls
  `SetAgplLicense()`.
- **Licence change.** Versions up to 6.2.4 were MIT; 6.5.0 is AGPL-3.0 or commercial, and the AGPL licence
  prohibits use in closed-source projects ([Pricing](https://www.pdfsharp.com/Pricing),
  [nuget.org 6.2.4](https://www.nuget.org/packages/PDFsharp/6.2.4)).
- **Fonts in the Core build.** The Core build's platform font resolver "throws an exception by default".
  `GlobalFontSettings.UseWindowsFontsUnderWindows = true` reads the Windows fonts folder and is meant for development;
  on Linux, macOS and in containers you must set a custom `IFontResolver`
  ([Font resolving](https://docs.pdfsharp.net/PDFsharp/Topics/Fonts/Font-Resolving.html)). The T1 sample and its
  Docker image show a one-file resolver. Opening a form with text fields also creates fonts, so T8 needs one too.
- **PDF/A is an early implementation.** "PDF/A support is under construction"; `SetPdfA()` sets no specific level,
  existing documents cannot be converted, and a `UAManager` must be created for tagging
  ([Archiving - PDF/A](https://docs.pdfsharp.net/PDFsharp/Topics/PDF-Features/Archiving.html)). The file written by
  6.5.0 declares PDF/A-1a and passes veraPDF at that level ([T12 sample](samples/T12-pdfa/expect.json)).
- **AcroForms: limited support.** ([PDFsharp FAQ](https://docs.pdfsharp.net/PDFsharp/Overview/FAQ.html)) In the T8
  sample the stored values are correct, but the combo box keeps showing its old appearance ("Free") after
  `Value` is set to "Pro".
- **Signatures need PdfSharp.Cryptography.** `PdfSharpDefaultSigner` lives in the separate `PdfSharp.Cryptography`
  assembly (shipped in the `PDFsharp` package) so the main assembly does not depend on
  System.Security.Cryptography.Pkcs; timestamps are not supported on the .NET Framework build
  ([Digital signatures](https://docs.pdfsharp.net/PDFsharp/Topics/PDF-Features/Signatures.html)).
- **No HTML, text extraction or rendering.** See the not supported rows above; the FAQ points to the third-party
  "HTML Renderer for PDF using PdfSharp" for HTML ([PDFsharp FAQ](https://docs.pdfsharp.net/PDFsharp/Overview/FAQ.html)).

## Links

- Official site: https://www.pdfsharp.com/
- Documentation: https://docs.pdfsharp.net/
- Samples: https://github.com/empira/PDFsharp.Samples
- NuGet: https://www.nuget.org/packages/PDFsharp, https://www.nuget.org/packages/PDFsharp-MigraDoc
- Source repository: https://github.com/empira/PDFsharp
