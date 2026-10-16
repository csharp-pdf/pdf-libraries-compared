# wkhtmltopdf (Haukcode.WkHtmlToPdfDotNet)

wkhtmltopdf is a command-line tool and C library (`libwkhtmltox`) that renders HTML to PDF with Qt WebKit.
Haukcode.WkHtmlToPdfDotNet is a .NET P/Invoke wrapper for that library, forked from DinkToPdf, that ships the native
binaries inside the NuGet package. It converts HTML and URLs to PDF; it does not read or edit existing PDFs.

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | Wrapper: HakanL (authors on NuGet: rdvojmoc, HakanL, georgechond94), a fork of DinkToPdf. Native library: the wkhtmltopdf project, whose GitHub repository is archived (read-only). | [nuget.org](https://www.nuget.org/packages/Haukcode.WkHtmlToPdfDotNet/1.5.95), [wrapper repository](https://github.com/HakanL/WkHtmlToPdf-DotNet), [wkhtmltopdf repository](https://github.com/wkhtmltopdf/wkhtmltopdf) | verified 2026-10-16 |
| Licence | LGPL-3.0-or-later (wrapper); LGPL-3.0 (wkhtmltopdf) | [nuget.org](https://www.nuget.org/packages/Haukcode.WkHtmlToPdfDotNet/1.5.95), [wkhtmltopdf repository](https://github.com/wkhtmltopdf/wkhtmltopdf) | verified 2026-10-16 |
| Price (entry) | free | [nuget.org (LGPL licence)](https://www.nuget.org/packages/Haukcode.WkHtmlToPdfDotNet/1.5.95) | verified 2026-10-16 |
| Free tier / trial limits | none (open source) | [nuget.org](https://www.nuget.org/packages/Haukcode.WkHtmlToPdfDotNet/1.5.95) | verified 2026-10-16 |
| NuGet package(s) | `Haukcode.WkHtmlToPdfDotNet` | [nuget.org](https://www.nuget.org/packages/Haukcode.WkHtmlToPdfDotNet) | verified 2026-10-16 |
| Latest version | 1.5.95 (latest stable; a pre-release 1.5.96-PR-master-1ec01246 was published 2025-01-15) | [nuget.org, versions](https://www.nuget.org/packages/Haukcode.WkHtmlToPdfDotNet#versions-body-tab) | verified 2026-10-16 |
| Target frameworks | net461, netstandard2.0 | [nuget.org, Frameworks](https://www.nuget.org/packages/Haukcode.WkHtmlToPdfDotNet/1.5.95#supportedframeworks-body-tab) | verified 2026-10-16 |
| Operating systems | Native binaries in the package for win-x64, win-x86, linux-x64, linux-x86, linux-arm64, osx-x64; the README says it "has been successfully tested on Windows, Linux, MacOSX and docker" | [package (.nupkg)](https://www.nuget.org/api/v2/package/Haukcode.WkHtmlToPdfDotNet/1.5.95), [README](https://github.com/HakanL/WkHtmlToPdf-DotNet#readme) | verified 2026-10-16 |
| Rendering engine (HTML to PDF) | Qt WebKit. The project's status page: the WebKit in Qt 4 "hasn't been updated since 2012", and QtWebKit was "deprecated in 2015 and removed in 2016". | [wkhtmltopdf status](https://wkhtmltopdf.org/status.html) | verified 2026-10-16 |
| Native dependencies | `libwkhtmltox` ships in the package; `PdfTools.GetLibraryVersion()` reports 0.12.6 (win-x64). On Linux the library needs system libraries: the package's load error names "libjpeg62, etc". | [package (.nupkg)](https://www.nuget.org/api/v2/package/Haukcode.WkHtmlToPdfDotNet/1.5.95), [ModuleFactory.cs](https://github.com/HakanL/WkHtmlToPdf-DotNet/blob/master/src/WkHtmlToPdf-DotNet/ModuleFactory.cs) | verified 2026-10-16 |
| Latest release date | Wrapper 1.5.95: 2024-10-22. wkhtmltopdf 0.12.6: 2020-06-10 (last release). | [nuget.org](https://www.nuget.org/packages/Haukcode.WkHtmlToPdfDotNet/1.5.95), [wkhtmltopdf releases](https://github.com/wkhtmltopdf/wkhtmltopdf/releases) | verified 2026-10-16 |

## Install

```bash
dotnet add package Haukcode.WkHtmlToPdfDotNet
```

## Supported tasks

| # | Task | Status | Sample |
|---|---|---|---|
| T1 | Hello world PDF | **supported** | [T01-hello-world](samples/T01-hello-world) |
| T2 | HTML string to PDF | **supported** | [T02-html-string](samples/T02-html-string) |
| T3 | URL to PDF | **supported** | [T03-url](samples/T03-url) |
| T4 | Page size, margins and orientation | **supported** | [T04-page-setup](samples/T04-page-setup) |
| T5 | Header and footer with page numbers | **supported** (text header/footer with `[page]` and `[topage]`) | [T05-header-footer](samples/T05-header-footer) |
| T6 | Merge PDFs | **not supported** | wkhtmltopdf takes web pages as input objects and writes one PDF ([manual](https://wkhtmltopdf.org/usage/wkhtmltopdf.txt)); the wrapper's only operation is `Convert(IDocument)` ([IConverter.cs](https://github.com/HakanL/WkHtmlToPdf-DotNet/blob/master/src/WkHtmlToPdf-DotNet/Contracts/IConverter.cs)) |
| T7 | Watermark / stamp | **not supported** | as T6: it cannot open an existing PDF |
| T8 | Fill a PDF form | **not supported** | as T6 |
| T9 | Extract text | **not supported** | as T6 |
| T10 | PDF to image | **not supported** | as T6 |
| T11 | Digital signature | **not supported** | as T6; the [manual](https://wkhtmltopdf.org/usage/wkhtmltopdf.txt) has no signing option |
| T12 | PDF/A output | **not supported** | the [manual](https://wkhtmltopdf.org/usage/wkhtmltopdf.txt) has no PDF/A option |
| T13 | ASP.NET Core endpoint | **supported** (`SynchronizedConverter` singleton) | [T13-aspnet-core](samples/T13-aspnet-core) |
| T14 | Linux / Docker deployment | **not supported** as documented | The README's Docker recipe installs a wkhtmltox 0.12.5 package built for Debian 9 ("stretch") and `libssl1.1`; on `mcr.microsoft.com/dotnet/runtime:8.0` (Debian 12) the install stops with "Dependency is not satisfiable: libssl1.1" ([README, Docker](https://github.com/HakanL/WkHtmlToPdf-DotNet#docker), [Dockerfile used](https://github.com/csharp-pdf/pdf-benchmarks/blob/main/deployment/wkhtmltopdf/documented.Dockerfile), [deployment results](../benchmarks/2026-10-15.md#deployment)) |

Status values: **supported** (link the sample), **not supported** (link the
source that says so), **add-on** (name the extra package or product).

## Benchmark results

<!-- benchmark-results: generated, do not edit -->

From the [2026-10-15 run](../benchmarks/2026-10-15.md) (Windows and Linux on the same machine; method and raw data are linked there). Each value is this library's own result; compare it with the other libraries on the results page.

|  | Result |
|---|---|
| HTML to PDF, median per page (Windows) | 255–3,375 ms over 18 pages; geometric mean 421 ms |
| Cold start (Windows) | 356 ms |
| Throughput, conversions/min, 1 / 8 at once (Windows) | 209 / 201 (sync); 204 / 198 (async) |
| Memory over 1,000 conversions (Windows) | 84 → 529 MB, 0 failures |
| HTML to PDF, median per page (Linux) | 211–2,723 ms over 18 pages; geometric mean 324 ms |
| Cold start (Linux) | 321 ms |
| Throughput, conversions/min, 1 / 8 at once (Linux) | 255 / 252 (sync); 252 / 248 (async) |
| Memory over 1,000 conversions (Linux) | 195 → 609 MB, 0 failures |
| Content checks (Windows) | 30 / 42; failed: cjk (text), forms (formFields), isolation-read (text), isolation-write (text), js-chart (text), paged-media (pages), scripts (text), web-fonts (fontsEmbedded), wide-content (text) |
| Fidelity vs Chrome, mean SSIM (Windows) | 0.809 |
| Working with existing PDFs and Word files (Windows) | not supported: text extraction, search, PDF to image, Word to PDF, redaction, merge, split, watermark, signature, form filling, ZUGFeRD/Factur-X |
| Docker, minimal image | does not run, 124 MB |
| Docker, documented image | image does not build |

## Gotchas

- **Untrusted HTML.** The wkhtmltopdf status page and the wrapper README both say: "Do not use wkhtmltopdf with any
  untrusted HTML", because unsanitised HTML/JS "can lead to complete takeover of the server it is running on"
  ([status](https://wkhtmltopdf.org/status.html), [README](https://github.com/HakanL/WkHtmlToPdf-DotNet#recommendations)).
- **Upstream is no longer developed.** The wkhtmltopdf repository is archived on GitHub, the last release is 0.12.6
  (2020-06-10), and the engine is Qt WebKit, which the project describes as deprecated in 2015
  ([repository](https://github.com/wkhtmltopdf/wkhtmltopdf), [status](https://wkhtmltopdf.org/status.html)).
  Modern CSS and JavaScript that the old engine predates may not render; see the fidelity results in the
  [2026-10-15 benchmark](../benchmarks/2026-10-15.md).
- **Not thread-safe.** Use `BasicConverter` in single-threaded programs and `SynchronizedConverter` in multi-threaded
  applications and web servers; the converter "must be registered as singleton". `SynchronizedConverter` queues every
  conversion onto one thread, so conversions in one process run one at a time
  ([README](https://github.com/HakanL/WkHtmlToPdf-DotNet#synchronized-converter),
  [SynchronizedConverter.cs](https://github.com/HakanL/WkHtmlToPdf-DotNet/blob/master/src/WkHtmlToPdf-DotNet/SynchronizedConverter.cs)).
- **Linux needs system libraries.** The bundled `libwkhtmltox.so` does not load on a bare
  `mcr.microsoft.com/dotnet/runtime:8.0` image; the package throws `NotSupportedException` ("missing native
  dependencies (libjpeg62, etc)")
  ([ModuleFactory.cs](https://github.com/HakanL/WkHtmlToPdf-DotNet/blob/master/src/WkHtmlToPdf-DotNet/ModuleFactory.cs),
  [deployment results](../benchmarks/2026-10-15.md#deployment)). The README's Docker recipe targets Debian 9 packages
  and does not build on current .NET images (see T14); for other distributions it points to the archived
  [wkhtmltopdf packaging releases](https://github.com/wkhtmltopdf/packaging/releases).
- **Header and footer variables.** Text headers and footers use wkhtmltopdf's substitution variables such as
  `[page]` and `[topage]` ("Footers And Headers" in the [manual](https://wkhtmltopdf.org/usage/wkhtmltopdf.txt)).
  HTML headers and footers are separate HTML documents passed by URL or file path (`HeaderSettings.HtmlUrl`).
- **No exception on a failed conversion.** `Convert` returns an empty byte array when wkhtmltopdf reports failure;
  the details come through the converter's `Error` event
  ([BasicConverter.cs](https://github.com/HakanL/WkHtmlToPdf-DotNet/blob/master/src/WkHtmlToPdf-DotNet/BasicConverter.cs),
  [IConverter.cs](https://github.com/HakanL/WkHtmlToPdf-DotNet/blob/master/src/WkHtmlToPdf-DotNet/Contracts/IConverter.cs)).
- **DinkToPdf.** The original `DinkToPdf` package (last release 1.0.8, 2017-04-18) does not bundle the native
  library; its README says to copy it into the project ([DinkToPdf](https://github.com/rdvojmoc/DinkToPdf#readme)).
  This fork's main changes are the bundled natives and the new name (namespace `WkHtmlToPdfDotNet`)
  ([README, Fork](https://github.com/HakanL/WkHtmlToPdf-DotNet#fork), [DinkToPdf on nuget.org](https://www.nuget.org/packages/DinkToPdf)).

## Links

- Official site: <https://wkhtmltopdf.org/>
- Documentation: <https://github.com/HakanL/WkHtmlToPdf-DotNet#readme> (wrapper), <https://wkhtmltopdf.org/usage/wkhtmltopdf.txt> (wkhtmltopdf manual)
- NuGet: <https://www.nuget.org/packages/Haukcode.WkHtmlToPdfDotNet>
- Source repository: <https://github.com/HakanL/WkHtmlToPdf-DotNet> (wrapper), <https://github.com/wkhtmltopdf/wkhtmltopdf> (wkhtmltopdf, archived)
- Migration guide to SelectPdf (written by SelectPdf): https://github.com/selectpdf/migrate-to-selectpdf/tree/main/from-wkhtmltopdf
