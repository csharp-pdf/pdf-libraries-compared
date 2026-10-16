# SelectPdf

SelectPdf (package SelectPdf.Universal) is a commercial .NET library that creates, edits and reads PDF documents,
with an HTML to PDF converter built on Chromium and a Word to PDF converter
([NuGet description](https://www.nuget.org/packages/SelectPdf.Universal/26.5.0)).

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | SelectPdf (Outside Software SRL, per the package copyright) | [nuget.org](https://www.nuget.org/packages/SelectPdf.Universal/26.5.0) | 2026-10-16 |
| Licence | Commercial, perpetual; [EULA](https://selectpdf.com/eula/) | [Pricing](https://selectpdf.com/pricing/) | 2026-10-16 |
| Price (entry) | USD 499, Single Developer: 1 developer, 1 deployment machine, 1 year of maintenance. One key covers SelectPdf.Universal and the classic Windows library. | [Pricing](https://selectpdf.com/pricing/) | 2026-10-16 |
| Free tier / trial limits | Trial: fully functional, 30 days, a "Demo Version" banner on every page until a licence key is set. Separate free Community Edition (`SelectPdf.HtmlToPdf.Universal`): HTML to PDF only, at most 5 pages per document. | [Licensing](https://selectpdf.com/pdf-library/html/License.htm), [Community Edition](https://selectpdf.com/community-edition/) | 2026-10-16 |
| NuGet package(s) | `SelectPdf.Universal` (managed, AnyCPU) plus one `SelectPdf.Universal.Native.<rid>` engine package (win-x64, win-x86, linux-x64, linux-arm64, osx-arm64); or one per-platform package instead: `SelectPdf.Universal.Windows`, `.Linux`, `.Linux.Arm64`, `.MacOS`. Optional `SelectPdf.Universal.Fonts`. | [Installation](https://selectpdf.com/pdf-library/html/Installation.htm) | 2026-10-16 |
| Latest version | 26.5.0 | [nuget.org](https://www.nuget.org/packages/SelectPdf.Universal/) | 2026-10-16 |
| Target frameworks | netstandard2.0, net8.0, net10.0 (usable from .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5 to .NET 10) | [nuget.org Frameworks](https://www.nuget.org/packages/SelectPdf.Universal/26.5.0#supportedframeworks-body-tab), [Installation](https://selectpdf.com/pdf-library/html/Installation.htm) | 2026-10-16 |
| Operating systems | Windows (x64, x86), Linux (x64, ARM64; glibc 2.30 or later), macOS 13+ on Apple Silicon | [Installation](https://selectpdf.com/pdf-library/html/Installation.htm), [SelectPdf.Universal.Linux](https://www.nuget.org/packages/SelectPdf.Universal.Linux/26.5.0) | 2026-10-16 |
| Rendering engine (HTML to PDF) | Chromium (CEF), shipped in the Native package. 26.5.0: Chromium 154.0.8037.58 (CEF 154.0.28, the version of `libcef` in `SelectPdf.Universal.Native.win-x64` and `.linux-x64`); Chromium 154 reached stable on 2026-09-22 | [Installation](https://selectpdf.com/pdf-library/html/Installation.htm), [Chromium 154 schedule](https://chromiumdash.appspot.com/fetch_milestone_schedule?mstone=154) | 2026-10-16 |
| Native dependencies | The per-platform Native package (Chromium engine and a native PDF tool used for PDF to text and PDF to image). On Linux no OS packages are installed: the Native package bundles the Chromium libraries. | [Installation](https://selectpdf.com/pdf-library/html/Installation.htm), [Deployment with Docker](https://selectpdf.com/pdf-library/html/Deployment-Docker.htm) | 2026-10-16 |
| Latest release date | 2026-10-15 | [nuget.org](https://www.nuget.org/packages/SelectPdf.Universal/26.5.0) | 2026-10-16 |

## Install

```bash
# one platform (Windows x64 here; SelectPdf.Universal.Linux for Linux x64 and Docker)
dotnet add package SelectPdf.Universal.Windows

# or the managed library plus the engine package for the runtime identifier
dotnet add package SelectPdf.Universal
dotnet add package SelectPdf.Universal.Native.win-x64
```

The samples use the second form with the engine package chosen by runtime identifier, as in the
[Publishing for Several Platforms](https://selectpdf.com/pdf-library/html/Installation.htm) section, so that the same
project builds on Windows and, published with `-r linux-x64`, in the Linux container.

## Supported tasks

| # | Task | Status | Sample |
|---|---|---|---|
| T1 | Hello world PDF | supported | [T01-hello-world](samples/T01-hello-world) |
| T2 | HTML string to PDF | supported | [T02-html-string](samples/T02-html-string) |
| T3 | URL to PDF | supported | [T03-url](samples/T03-url) |
| T4 | Page size, margins and orientation | supported | [T04-page-setup](samples/T04-page-setup) |
| T5 | Header and footer with page numbers | supported | [T05-header-footer](samples/T05-header-footer) |
| T6 | Merge PDFs | supported | [T06-merge](samples/T06-merge) |
| T7 | Watermark / stamp | supported | [T07-watermark](samples/T07-watermark) |
| T8 | Fill a PDF form | supported | [T08-fill-form](samples/T08-fill-form) |
| T9 | Extract text | supported | [T09-extract-text](samples/T09-extract-text) |
| T10 | PDF to image | supported | [T10-pdf-to-image](samples/T10-pdf-to-image) |
| T11 | Digital signature | supported | [T11-digital-signature](samples/T11-digital-signature) |
| T12 | PDF/A output | supported (PDF/A-2b) | [T12-pdfa](samples/T12-pdfa) |
| T13 | ASP.NET Core endpoint | supported | [T13-aspnet-core](samples/T13-aspnet-core) |
| T14 | Linux / Docker deployment | supported | [docker](docker) |

## Benchmark results

<!-- benchmark-results: generated, do not edit -->

From the [2026-10-15 run](../benchmarks/2026-10-15.md) (Windows and Linux on the same machine; method and raw data are linked there). Each value is this library's own result; compare it with the other libraries on the results page.

|  | Result |
|---|---|
| HTML to PDF, median per page (Windows) | 110–1,189 ms over 18 pages; geometric mean 212 ms |
| Cold start (Windows) | 714 ms |
| Throughput, conversions/min, 1 / 8 at once (Windows) | 353 / 1,078 (sync); 323 / 1,158 (async) |
| Memory over 1,000 conversions (Windows) | 140 → 156 MB, 0 failures |
| HTML to PDF, median per page (Linux) | 55–1,157 ms over 18 pages; geometric mean 134 ms |
| Cold start (Linux) | 745 ms |
| Throughput, conversions/min, 1 / 8 at once (Linux) | 619 / 2,597 (sync); 603 / 2,639 (async) |
| Memory over 1,000 conversions (Linux) | 369 → 389 MB, 0 failures |
| Content checks (Windows) | 46 / 48; failed: wide-content (text) |
| Fidelity vs Chrome, mean SSIM (Windows) | 0.984 |
| PDF/A, PDF/UA, PDF/X levels produced / valid (of 17) | 17 / 17 |
| Working with existing PDFs and Word files (Windows) | all checks pass: text extraction, search, PDF to image, Word to PDF, redaction, merge, split, watermark, signature, form filling, ZUGFeRD/Factur-X |
| Docker, minimal image | runs, 270 MB |

## Gotchas

- **Trial banner and licence key.** Without a key the library runs as a trial and adds a "Demo Version" banner to
  every page; the key is set in code with `GlobalProperties.LicenseKey` before the first conversion. Keys issued
  for versions before 26 are refused.
  ([Licensing](https://selectpdf.com/pdf-library/html/License.htm),
  [Installation](https://selectpdf.com/pdf-library/html/Installation.htm),
  [SelectPdf.Universal.Linux README](https://www.nuget.org/packages/SelectPdf.Universal.Linux/26.5.0))
- **Licences count deployment machines.** The entry licence covers one developer and one deployment machine;
  the OEM licences cover unlimited machines. ([Pricing](https://selectpdf.com/pricing/))
- **One engine package per build.** Every Native package installs the engine into the same folder, so two of
  them in one build conflict, and a per-platform package (`SelectPdf.Universal.Windows`, `.Linux`) is used
  instead of, not together with, `SelectPdf.Universal` + Native. A project that targets several platforms picks the
  Native package by runtime identifier and is published once per platform; with the samples' project file, a build
  without a runtime identifier gets the win-x64 engine.
  ([Installation](https://selectpdf.com/pdf-library/html/Installation.htm))
- **Linux and Docker.** The official Debian and Ubuntu based `mcr.microsoft.com/dotnet` images work without
  `apt-get`, extra `docker run` flags or `--shm-size`; glibc 2.30 or later is required, so Alpine (musl) images can
  only convert through the separate remote engine container. Base images have no fonts and the built-in fonts cover
  Latin, Greek and Cyrillic only; `SelectPdf.Universal.Fonts` adds Noto fonts for other scripts.
  ([Deployment with Docker](https://selectpdf.com/pdf-library/html/Deployment-Docker.htm),
  [Remote Engine](https://selectpdf.com/pdf-library/html/Remote-Engine.htm),
  [SelectPdf.Universal.Linux on NuGet](https://www.nuget.org/packages/SelectPdf.Universal.Linux/26.5.0))
- **Windows containers** need a Windows Server Core image with the core Windows fonts installed; Nano Server is not
  supported. ([Deployment with Docker](https://selectpdf.com/pdf-library/html/Deployment-Docker.htm))
- **macOS** is supported on Apple Silicon only; on an Intel Mac, HTML to PDF, PDF to text and PDF to image are
  unavailable because there is no osx-x64 engine package.
  ([Installation](https://selectpdf.com/pdf-library/html/Installation.htm))
- **Margins are in points.** `HtmlToPdfOptions.MarginLeft` and the other margins are integers in points (1/72 inch),
  so 20 mm is written as 57.
  ([MarginLeft](https://selectpdf.com/pdf-library/html/P_SelectPdf_Universal_HtmlToPdfOptions_MarginLeft.htm))
- **Page numbers in headers and footers** come from `{page_number}` and `{total_pages}` placeholders in a
  `PdfTextSection`. ([Headers and footers](https://selectpdf.com/pdf-library/html/HtmlToPdfHeadersAndFooters.htm))
- **SelectPdf.Universal is a separate product line** from the earlier Windows-only `Select.Pdf` /
  `Select.Pdf.NetCore` packages, with its own package ids and the `SelectPdf.Universal` namespace; NuGet does not
  treat it as an update of them. ([Installation](https://selectpdf.com/pdf-library/html/Installation.htm))

## Links

- Official site: https://selectpdf.com/pdf-library-cross-platform/
- Documentation: https://selectpdf.com/pdf-library/
- Official samples (online demo with source): https://selectpdf.com/demo-universal/
- NuGet: https://www.nuget.org/packages/SelectPdf.Universal/
- Source repository: not open source
