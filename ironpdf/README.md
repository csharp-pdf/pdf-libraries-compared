# IronPDF

IronPDF is a commercial .NET library from Iron Software that creates, edits and extracts PDF content, with HTML to
PDF conversion through a Chrome-based rendering engine
([NuGet description](https://www.nuget.org/packages/IronPdf/2026.10.3)).

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | Iron Software | [nuget.org](https://www.nuget.org/packages/IronPdf/2026.10.3), [ironpdf.com](https://ironpdf.com/) | 2026-10-16 |
| Licence | Commercial; perpetual licences (one-time purchase) with 1 year of support and updates included | [Licensing](https://ironpdf.com/licensing/) | 2026-10-16 |
| Price (entry) | USD 999, Lite: 1 developer, 1 location, 1 project, 1 year of support and updates | [Licensing](https://ironpdf.com/licensing/) | 2026-10-16 |
| Free tier / trial limits | 30-day trial key, sent by email, no credit card; the vendor states trial output carries no watermark. No free tier: a key is needed to save documents (see Gotchas). | [Licence keys](https://ironpdf.com/get-started/license-keys/), [Licensing](https://ironpdf.com/licensing/) | 2026-10-16 |
| NuGet package(s) | `IronPdf` (Windows; pulls in `IronPdf.Native.Chrome.Windows`), `IronPdf.Linux` (Linux and Docker; pulls in `IronPdf.Native.Chrome.Linux`); both depend on `IronPdf.Slim` | [IronPdf](https://www.nuget.org/packages/IronPdf/2026.10.3), [IronPdf.Linux](https://www.nuget.org/packages/IronPdf.Linux/2026.10.3), [Docker guide](https://ironpdf.com/get-started/ironpdf-docker/) | 2026-10-16 |
| Latest version | 2026.10.3 | [nuget.org](https://www.nuget.org/packages/IronPdf/) | 2026-10-16 |
| Target frameworks | netstandard2.0 (`IronPdf.Slim` also ships a .NET Framework 4.6.2 build); the README lists .NET 5 to .NET 10, .NET Core 2.x/3.x and .NET Framework 4.6.2+ | [nuget.org Frameworks](https://www.nuget.org/packages/IronPdf/2026.10.3#supportedframeworks-body-tab), [IronPdf.Slim](https://www.nuget.org/packages/IronPdf.Slim/2026.10.3#supportedframeworks-body-tab) | 2026-10-16 |
| Operating systems | Windows, macOS, Linux (Debian, CentOS, Ubuntu); Docker, Azure, AWS | [nuget.org README](https://www.nuget.org/packages/IronPdf/2026.10.3) | 2026-10-16 |
| Rendering engine (HTML to PDF) | Chrome-based (`ChromePdfRenderer`). 2026.10.3: Chromium 109.0.5414.120 (CEF 109.1.18, the version of `libcef` in `IronPdf.Native.Chrome.Windows` and `.Linux` 2026.10.6); Chromium 109 reached stable on 2023-01-10 | [nuget.org README](https://www.nuget.org/packages/IronPdf/2026.10.3), [Chromium 109 schedule](https://chromiumdash.appspot.com/fetch_milestone_schedule?mstone=109) | 2026-10-16 |
| Native dependencies | The `IronPdf.Native.Chrome.*` and `IronSoftware.Native.PdfModel*` packages; on Linux also the OS packages listed in the Docker guide (or installed at run time by `Installation.LinuxAndDockerDependenciesAutoConfig`) | [nuget.org](https://www.nuget.org/packages/IronPdf/2026.10.3), [Docker guide](https://ironpdf.com/get-started/ironpdf-docker/) | 2026-10-16 |
| Latest release date | 2026-10-12 | [nuget.org](https://www.nuget.org/packages/IronPdf/2026.10.3) | 2026-10-16 |

## Install

```bash
dotnet add package IronPdf          # Windows
dotnet add package IronPdf.Linux    # Linux and Docker
```

The samples reference `IronPdf` when built on Windows and `IronPdf.Linux` when built on Linux, and read the licence
key from the `IRONPDF_LICENSE_KEY` environment variable.

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
| HTML to PDF, median per page (Windows) | 85–1,708 ms over 18 pages; geometric mean 186 ms |
| Cold start (Windows) | 657 ms |
| Throughput, conversions/min, 1 / 8 at once (Windows) | 480 / 1,735 (sync); 447 / 1,705 (async) |
| Memory over 1,000 conversions (Windows) | 226 → 630 MB, 0 failures |
| HTML to PDF, median per page (Linux) | 92–1,433 ms over 18 pages; geometric mean 169 ms |
| Cold start (Linux) | 1,090 ms |
| Throughput, conversions/min, 1 / 8 at once (Linux) | 453 / 1,520 (sync); 468 / 1,704 (async) |
| Memory over 1,000 conversions (Linux) | 451 → 1,076 MB, 0 failures |
| Content checks (Windows) | 41 / 48; failed: bookmarks (outline), encryption (algorithm), isolation-read (text), lazy-images (images), wide-content (text) |
| Fidelity vs Chrome, mean SSIM (Windows) | 0.928 |
| PDF/A, PDF/UA, PDF/X levels produced / valid (of 17) | 14 / 5 |
| Working with existing PDFs and Word files (Windows) | all checks pass: text extraction, PDF to image, Word to PDF, redaction, merge, split, watermark, signature, form filling, ZUGFeRD/Factur-X; not supported: search |
| Docker, minimal image | runs as root only, 206 MB |
| Docker, documented image | runs, 239 MB |

## Gotchas

- **A licence key is needed to save output.** The key is set with `License.LicenseKey` (or `IronPdf.LicenseKey`
  in `appsettings.json`) before the first call. Without one, IronPDF 2026.10.3 renders but `SaveAs` throws
  "IronPdf is running in production without a license", with the note "Development use: Free for 7 days"
  (reproduced with [T01-hello-world](samples/T01-hello-world) and no `IRONPDF_LICENSE_KEY`, 2026-10-16). A free
  30-day trial key works. ([Licence keys](https://ironpdf.com/get-started/license-keys/))
- **Licences are counted per developer, location and project** (Lite: 1 / 1 / 1); OEM, SaaS and software
  royalty-free redistribution is an add-on, USD 1,999, offered with every licence (Unlimited included).
  ([Licensing](https://ironpdf.com/licensing/))
- **Linux packages.** IronPDF recommends `IronPdf.Linux` in containers to save disk space and avoid downloading
  assets at start-up. Its Docker guide installs a list of Chromium dependencies with `apt-get` (on Ubuntu 24.04 the
  names carry the `t64` suffix, e.g. `libasound2t64`) and, with them, sets
  `Installation.LinuxAndDockerDependenciesAutoConfig = false`. GPU acceleration "is disabled by default"; the guide
  sets `Installation.ChromeGpuMode = ChromeGpuModes.Disabled` only where it was turned on.
  ([Docker guide](https://ironpdf.com/get-started/ironpdf-docker/))
- **Alpine Linux is not supported directly**; the Docker guide points to the separate
  `ironsoftwareofficial/ironpdfengine` container used from an app with the `IronPdf.Slim` package.
  ([Docker guide](https://ironpdf.com/get-started/ironpdf-docker/))
- **Margins are in millimetres** (`RenderingOptions.MarginTop` and the others); text headers and footers come with
  predefined margins of their own, which the headers guide shows how to change.
  ([Custom margins](https://ironpdf.com/how-to/custom-margins/),
  [Headers and footers](https://ironpdf.com/how-to/headers-and-footers/))
- **Page-number placeholders** in text headers and footers are `{page}` and `{total-pages}`.
  ([Headers and footers](https://ironpdf.com/how-to/headers-and-footers/))
- **Signing with an in-memory certificate.** IronPDF's guide loads an `X509Certificate2` with
  `X509KeyStorageFlags.Exportable`; a certificate made at run time with `CertificateRequest.CreateSelfSigned` and
  re-imported that way failed on Windows with "The requested operation is not supported" when signing (2026-10-16),
  so the T11 sample signs from a `.pfx` file with `new PdfSignature(path, password)`, the guide's other form.
  ([Signing](https://ironpdf.com/how-to/signing/))

## Links

- Official site: https://ironpdf.com/
- Documentation: https://ironpdf.com/docs/
- NuGet: https://www.nuget.org/packages/IronPdf/
- Source repository: not open source
- Migration guide to SelectPdf (written by SelectPdf): https://github.com/selectpdf/migrate-to-selectpdf/tree/main/from-ironpdf
