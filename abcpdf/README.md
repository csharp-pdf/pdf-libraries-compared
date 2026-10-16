# ABCpdf

ABCpdf is a commercial .NET component from WebSupergoo for PDF creation and manipulation, with HTML to PDF
conversion through its ABCChrome engine (a Chromium build) and other selectable HTML engines
([NuGet description](https://www.nuget.org/packages/ABCpdf/14.0.6),
[Engine property](https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xhtmloptions/2-properties/engine.htm)).

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | WebSupergoo | [nuget.org](https://www.nuget.org/packages/ABCpdf/14.0.6), [websupergoo.com](https://www.websupergoo.com/abcpdf-1.htm) | 2026-10-16 |
| Licence | Commercial (WebSupergoo licence; the NuGet package requires licence acceptance); licensed per computer or per web site domain, perpetual for the major version (a v14 key is also valid for versions 8 to 13) | [Licence](https://www.websupergoo.com/license.htm), [Purchase](https://www.websupergoo.com/purchase_abcpdf.htm), [nuget.org](https://www.nuget.org/packages/ABCpdf/14.0.6) | 2026-10-16 |
| Price (entry) | USD 329, Standard single computer (32-bit processes only); USD 495, Professional single computer (needed for 64-bit, display and rendering) | [Purchase](https://www.websupergoo.com/purchase_abcpdf.htm) | 2026-10-16 |
| Free tier / trial limits | 30-day trial, during which ABCpdf runs as the unrestricted Professional edition. On Windows the trial is installed automatically on first use (needs registry write access); Linux has no trial and needs a key. No free tier. | [nuget.org](https://www.nuget.org/packages/ABCpdf/14.0.6), [Installation](https://www.websupergoo.com/helppdfnet/source/3-concepts/6-installation.htm), [Platforms](https://www.websupergoo.com/helppdfnet/source/2-getting_started/6-platforms.htm) | 2026-10-16 |
| NuGet package(s) | `ABCpdf` (library for Windows and Linux, plus the ABCChrome146 engine for Windows); `ABCpdf.ABCChrome146.Linux` (the ABCChrome146 engine for Linux) | [ABCpdf](https://www.nuget.org/packages/ABCpdf/14.0.6), [ABCpdf.ABCChrome146.Linux](https://www.nuget.org/packages/ABCpdf.ABCChrome146.Linux/14.0.6), [Platforms](https://www.websupergoo.com/helppdfnet/source/2-getting_started/6-platforms.htm) | 2026-10-16 |
| Latest version | 14.0.6 | [nuget.org](https://www.nuget.org/packages/ABCpdf/) | 2026-10-16 |
| Target frameworks | .NET Framework 4.0, net8.0, net9.0, net10.0 (and their `-windows10.0.10240` variants) | [nuget.org Frameworks](https://www.nuget.org/packages/ABCpdf/14.0.6#supportedframeworks-body-tab) | 2026-10-16 |
| Operating systems | Windows (ABCChrome146: Windows 10 / Server 2016 or later, x64); Linux x64 with .NET 6 or later: Ubuntu 22.04, 24.04 and 26.04, WSL 2; Debian and Fedora not officially supported | [Platforms](https://www.websupergoo.com/helppdfnet/source/2-getting_started/6-platforms.htm), [Engine property](https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xhtmloptions/2-properties/engine.htm) | 2026-10-16 |
| Rendering engine (HTML to PDF) | ABCChrome146 (Chromium; the default `HtmlOptions.Engine`); also Chrome123, older ABCChrome versions, ABCGecko, ABCWebKit and MSHTML, some as separate packages | [Engine property](https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xhtmloptions/2-properties/engine.htm), [HTML / CSS rendering](https://www.websupergoo.com/helppdfnet/source/3-concepts/g-htmlrender.htm) | 2026-10-16 |
| Native dependencies | Native ABCpdf libraries and the ABCChrome146 engine ship in the packages; on Linux the ABCChrome engine needs OS packages (`libasound2t64 libnss3 libcurl4t64` on Ubuntu 24 to 26, a longer list on Ubuntu 22 and Debian 12.7) | [Platforms](https://www.websupergoo.com/helppdfnet/source/2-getting_started/6-platforms.htm) | 2026-10-16 |
| Latest release date | 2026-09-24 | [nuget.org](https://www.nuget.org/packages/ABCpdf/14.0.6) | 2026-10-16 |

## Install

```bash
dotnet add package ABCpdf
dotnet add package ABCpdf.ABCChrome146.Linux   # Linux only: the HTML engine
```

The samples reference `ABCpdf.ABCChrome146.Linux` only when built on Linux, and install the licence key from the
`ABCPDF_LICENSE_KEY` environment variable when it is set (`XSettings.InstallLicense`). On Windows they run on the
trial without a key.

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
| HTML to PDF, median per page (Windows) | 176–2,244 ms over 18 pages; geometric mean 389 ms |
| Cold start (Windows) | 2,044 ms |
| Throughput, conversions/min, 1 / 8 at once (Windows) | 160 / 747 (sync); 159 / 751 (async) |
| Memory over 1,000 conversions (Windows) | 331 → 444 MB, 0 failures |
| HTML to PDF, median per page (Linux) | 107–2,196 ms over 18 pages; geometric mean 175 ms |
| Cold start (Linux) | 826 ms |
| Throughput, conversions/min, 1 / 8 at once (Linux) | 379 / 1,913 (sync); 356 / 1,920 (async) |
| Memory over 1,000 conversions (Linux) | 425 → 488 MB, 0 failures |
| Content checks (Windows) | 43 / 48; failed: html-header-footer (imageEveryPage), isolation-read (text), lazy-images (images), trivial (text) |
| Fidelity vs Chrome, mean SSIM (Windows) | 0.927 |
| PDF/A, PDF/UA, PDF/X levels produced / valid (of 17) | 7 / 2 |
| Working with existing PDFs and Word files (Windows) | all checks pass: PDF to image, merge, split, watermark, signature, form filling; some checks fail: text extraction (lowest F1 0.17), search (9/10 checks); not supported: Word to PDF, redaction, ZUGFeRD/Factur-X |
| Docker, minimal image | does not run, 235 MB |
| Docker, documented image | runs, 312 MB |

## Gotchas

- **Linux needs a licence key.** "There are no trial licenses created on Linux", so a key must be installed in code
  with `XSettings.InstallLicense` at start-up; a trial key can be copied from the PDFSettings application of the
  Windows installer. The Docker image therefore needs `ABCPDF_LICENSE_KEY`.
  ([Platforms](https://www.websupergoo.com/helppdfnet/source/2-getting_started/6-platforms.htm),
  [InstallLicense](https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xsettings/1-methods/installlicense.htm))
- **The Windows trial lives in the registry.** Most ABCpdf calls install a trial licence when none is installed;
  this needs write access to the registry.
  ([Installation](https://www.websupergoo.com/helppdfnet/source/3-concepts/6-installation.htm))
- **Edition matters.** The Standard licence covers 32-bit processes only; 64-bit, display and rendering (T10) need
  Professional, and `PdfConformityOperation` (T12) is Professional only.
  ([Purchase](https://www.websupergoo.com/purchase_abcpdf.htm),
  [PdfConformityOperation](https://www.websupergoo.com/helppdfnet/source/8-abcpdf.operations/7-pdfconformityoperation/default.htm))
- **Containers are licensed per instance.** Each Docker instance that uses ABCpdf needs a licence; when the number of
  instances is not known (for example with Kubernetes), an Enterprise licence is needed.
  ([Licence, scenario 5](https://www.websupergoo.com/license.htm))
- **Linux engine package and OS packages.** Without `ABCpdf.ABCChrome146.Linux` HTML conversion fails with "Unable to
  find ABCChrome146". The documented package lists assume a full distribution: in the `mcr.microsoft.com/dotnet`
  Ubuntu 24.04 (noble) image the three Ubuntu 24 packages were not enough (ABCChrome146 failed to load
  `libX11.so.6`); the Debian 12.7 list, used in [docker/Dockerfile](docker/Dockerfile) on the default Debian 12
  image, works. ABCpdf also writes temporary files to `/tmp/ABCpdf`, and Linux usually has fewer fonts than Windows.
  ([Platforms](https://www.websupergoo.com/helppdfnet/source/2-getting_started/6-platforms.htm))
- **Paged HTML.** `AddImageUrl` / `AddImageHtml` draw only the first page; the following pages are added with
  `AddImageToChain` while `Chainable` returns true. Relative links in an HTML string need `HtmlOptions.BaseURI` or
  a `<base>` element, and ABCChrome does not accept `file:///` references in HTML strings.
  ([Paged HTML example](https://www.websupergoo.com/helppdfnet/source/4-examples/13-pagedhtml.htm),
  [AddImageHtml](https://www.websupergoo.com/helppdfnet/source/5-abcpdf/doc/1-methods/addimagehtml.htm))
- **Pages that keep drawing after load** (charts, AJAX content) need `HtmlOptions.RepaintDelay`; the default is 0.
  ([RepaintDelay](https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xhtmloptions/2-properties/repaintdelay.htm))
- **PDF/A levels.** `PdfConformityOperation.Conformance` documents PDF/A-1a, 1b, 2a, 2b and 2u.
  ([Conformance](https://www.websupergoo.com/helppdfnet/source/8-abcpdf.operations/7-pdfconformityoperation/2-properties/conformance.htm))
- **Word files** are not read by ABCpdf itself: DOC/DOCX import goes through WordGlue .NET (a separate WebSupergoo
  product), Microsoft Office or OpenOffice.
  ([ReadModule](https://www.websupergoo.com/helppdfnet/source/5-abcpdf/xreadoptions/2-properties/1-readmodule.htm))

## Links

- Official site: https://www.websupergoo.com/abcpdf-1.htm
- Documentation: https://www.websupergoo.com/helppdfnet/
- NuGet: https://www.nuget.org/packages/ABCpdf/ and https://www.nuget.org/packages/ABCpdf.ABCChrome146.Linux/
- Source repository: not open source
