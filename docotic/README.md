# Docotic.Pdf

Docotic.Pdf is a commercial C# PDF library from Bit Miracle to create, edit, draw and print PDF files; HTML to PDF
conversion comes from its free HtmlToPdf add-on, which drives Chromium, and PDF/A output from its free Conformance
add-on ([NuGet description](https://www.nuget.org/packages/BitMiracle.Docotic.Pdf/9.9.19928),
[HTML to PDF for .NET](https://bitmiracle.com/pdf-library/html-pdf/)).

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | Bit Miracle | [nuget.org](https://www.nuget.org/packages/BitMiracle.Docotic.Pdf/9.9.19928), [bitmiracle.com](https://bitmiracle.com/pdf-library/) | 2026-10-16 |
| Licence | Commercial; perpetual, royalty-free, unlimited developers, one year of updates and bug fixes; all add-ons included. The HtmlToPdf and Conformance add-ons are free but work only with the core library. | [Licences](https://bitmiracle.com/pdf-library/licenses/), [HTML to PDF for .NET](https://bitmiracle.com/pdf-library/html-pdf/) | 2026-10-16 |
| Price (entry) | USD 995, Application (one desktop or mobile application); USD 1,145, Server (one production server); USD 3,495, Ultimate (unbound: web, serverless, autoscaling, SDKs). Renewal: USD 498, 573 and 1,748. | [Licences](https://bitmiracle.com/pdf-library/licenses/) | 2026-10-16 |
| Free tier / trial limits | No free mode: without a licence key the library does not create or read PDF documents. A free time-limited key (31 days) is available for evaluation only, not for production or distributed software. Free licences for eligible projects. | [Trial restrictions](https://bitmiracle.com/pdf-library/trial-restrictions), [Free licences](https://bitmiracle.com/pdf-library/licenses/free) | 2026-10-16 |
| NuGet package(s) | `BitMiracle.Docotic.Pdf` (core); `BitMiracle.Docotic.Pdf.HtmlToPdf` (HTML to PDF add-on); `BitMiracle.Docotic.Pdf.Conformance` (PDF/A add-on) | [Core](https://www.nuget.org/packages/BitMiracle.Docotic.Pdf/9.9.19928), [HtmlToPdf](https://www.nuget.org/packages/BitMiracle.Docotic.Pdf.HtmlToPdf/9.9.19928), [Conformance](https://www.nuget.org/packages/BitMiracle.Docotic.Pdf.Conformance/9.9.19928) | 2026-10-16 |
| Latest version | 9.9.19928 (stable; later `9.9.2xxxx-dev` builds are pre-releases) | [nuget.org](https://www.nuget.org/packages/BitMiracle.Docotic.Pdf/) | 2026-10-16 |
| Target frameworks | netstandard2.0 (the vendor lists .NET 5 to .NET 10, .NET Core 2.0+ and .NET Framework 4.6.1+) | [nuget.org Frameworks](https://www.nuget.org/packages/BitMiracle.Docotic.Pdf/9.9.19928#supportedframeworks-body-tab), [HTML to PDF for .NET](https://bitmiracle.com/pdf-library/html-pdf/) | 2026-10-16 |
| Operating systems | Licences cover Windows, Linux, macOS, Android and iOS; HTML to PDF on Windows, macOS and Linux, and in Windows and Linux Docker containers | [Licences](https://bitmiracle.com/pdf-library/licenses/), [HTML to PDF for .NET](https://bitmiracle.com/pdf-library/html-pdf/) | 2026-10-16 |
| Rendering engine (HTML to PDF) | Chromium: the add-on uses a compatible Google Chrome build in the `.local-chromium` folder and downloads it there when missing | [HTML to PDF for .NET](https://bitmiracle.com/pdf-library/html-pdf/) | 2026-10-16 |
| Native dependencies | None for the core library and the Conformance add-on (managed netstandard2.0 assemblies); the HtmlToPdf add-on runs the downloaded Chromium, which on Linux needs Chromium's OS libraries (`apt-get -y install chromium` on Debian) | [nuget.org](https://www.nuget.org/packages/BitMiracle.Docotic.Pdf/9.9.19928#dependencies-body-tab), [Convert HTML to PDF in Azure](https://bitmiracle.com/pdf-library/html-pdf/convert-in-azure) | 2026-10-16 |
| Latest release date | 2026-05-15 (9.9.19928) | [nuget.org](https://www.nuget.org/packages/BitMiracle.Docotic.Pdf/9.9.19928) | 2026-10-16 |

## Install

```bash
dotnet add package BitMiracle.Docotic.Pdf
dotnet add package BitMiracle.Docotic.Pdf.HtmlToPdf     # HTML to PDF
dotnet add package BitMiracle.Docotic.Pdf.Conformance   # PDF/A
```

Every sample applies the licence key from the `DOCOTIC_LICENSE_KEY` environment variable with
`LicenseManager.AddLicenseData`; without a key they stop with "A license is required".

## Supported tasks

| # | Task | Status | Sample |
|---|---|---|---|
| T1 | Hello world PDF | supported (core API) | [T01-hello-world](samples/T01-hello-world) |
| T2 | HTML string to PDF | add-on: `BitMiracle.Docotic.Pdf.HtmlToPdf` (free) | [T02-html-string](samples/T02-html-string) |
| T3 | URL to PDF | add-on: `BitMiracle.Docotic.Pdf.HtmlToPdf` (free) | [T03-url](samples/T03-url) |
| T4 | Page size, margins and orientation | add-on: `BitMiracle.Docotic.Pdf.HtmlToPdf` (free) | [T04-page-setup](samples/T04-page-setup) |
| T5 | Header and footer with page numbers | add-on: `BitMiracle.Docotic.Pdf.HtmlToPdf` (free) | [T05-header-footer](samples/T05-header-footer) |
| T6 | Merge PDFs | supported | [T06-merge](samples/T06-merge) |
| T7 | Watermark / stamp | supported | [T07-watermark](samples/T07-watermark) |
| T8 | Fill a PDF form | supported | [T08-fill-form](samples/T08-fill-form) |
| T9 | Extract text | supported | [T09-extract-text](samples/T09-extract-text) |
| T10 | PDF to image | supported | [T10-pdf-to-image](samples/T10-pdf-to-image) |
| T11 | Digital signature | supported | [T11-digital-signature](samples/T11-digital-signature) |
| T12 | PDF/A output | add-on: `BitMiracle.Docotic.Pdf.Conformance` (free), PDF/A-2b | [T12-pdfa](samples/T12-pdfa) |
| T13 | ASP.NET Core endpoint | add-on: `BitMiracle.Docotic.Pdf.HtmlToPdf` (free) | [T13-aspnet-core](samples/T13-aspnet-core) |
| T14 | Linux / Docker deployment | add-on: `BitMiracle.Docotic.Pdf.HtmlToPdf` (free) | [docker](docker) |

## Benchmark results

<!-- benchmark-results: generated, do not edit -->

From the [2026-10-15 run](../benchmarks/2026-10-15.md) (Windows and Linux on the same machine; method and raw data are linked there). Each value is this library's own result; compare it with the other libraries on the results page.

|  | Result |
|---|---|
| HTML to PDF, median per page (Windows) | 167–1,628 ms over 18 pages; geometric mean 368 ms |
| Cold start (Windows) | 947 ms |
| Throughput, conversions/min, 1 / 8 at once (Windows) | 193 / 841 (sync); 187 / 776 (async) |
| Memory over 1,000 conversions (Windows) | 332 → 510 MB, 0 failures |
| HTML to PDF, median per page (Linux) | 46–1,093 ms over 18 pages; geometric mean 107 ms |
| Cold start (Linux) | 603 ms |
| Throughput, conversions/min, 1 / 8 at once (Linux) | 601 / 1,917 (sync); 642 / 1,937 (async) |
| Memory over 1,000 conversions (Linux) | 453 → 718 MB, 0 failures |
| Content checks (Windows) | 39 / 45; failed: encryption (algorithm), isolation-read (text), lazy-images (images), wide-content (text) |
| Fidelity vs Chrome, mean SSIM (Windows) | 0.942 |
| PDF/A, PDF/UA, PDF/X levels produced / valid (of 17) | 11 / 8 |
| Working with existing PDFs and Word files (Windows) | all checks pass: PDF to image, merge, split, watermark, signature, form filling, ZUGFeRD/Factur-X; some checks fail: text extraction (lowest F1 0.35); not supported: search, Word to PDF, redaction |
| Docker, minimal image | does not run, 86 MB |
| Docker, documented image | runs, 385 MB |

## Gotchas

- **A key is always needed.** Without one, `new PdfDocument()` throws `InvalidOperationException: A license is
  required`; `LicenseManager.HasValidLicense` tells whether a valid key was applied. Bit Miracle recommends adding
  the key once at start-up (in `Program.cs` for ASP.NET Core). The free key lasts 31 days and is for evaluation
  only. ([Trial restrictions](https://bitmiracle.com/pdf-library/trial-restrictions),
  [Licence troubleshooting](https://bitmiracle.com/pdf-library/licenses/troubleshooting))
- **Licence types follow the deployment.** Application covers one desktop or mobile application, Server one
  production server (bound to the server's ID); serverless, autoscaling and SDK/API use need Ultimate.
  ([Licences](https://bitmiracle.com/pdf-library/licenses/))
- **Chromium is downloaded at run time.** The first conversion downloads a Chrome build into `HtmlEngineOptions.Path`, by default `.local-chromium` under the current directory, so the
  process needs network access and a writable folder; `Path` can point to a shared or pre-filled folder. Apps run
  from a read-only package (Azure "run from ZIP") must set `Path`.
  ([HTML to PDF for .NET](https://bitmiracle.com/pdf-library/html-pdf/),
  [Convert HTML to PDF in Azure](https://bitmiracle.com/pdf-library/html-pdf/convert-in-azure))
- **Containers need the Chromium sandbox off.** In Docker, Bit Miracle installs the `chromium` package (for its
  dependencies) and sets `HtmlEngineOptions.UseSandbox = false`; otherwise Chromium fails with "Running as root
  without --no-sandbox is not supported". The T02 and T13 samples turn the sandbox off only when
  `DOTNET_RUNNING_IN_CONTAINER` is `true` (set by the official .NET images).
  ([Convert HTML to PDF in Azure](https://bitmiracle.com/pdf-library/html-pdf/convert-in-azure))
- **Azure App Service and Functions on Windows** cannot run the add-on's Chromium ("side-by-side configuration is
  incorrect"). ([Convert HTML to PDF in Azure](https://bitmiracle.com/pdf-library/html-pdf/convert-in-azure))
- **The HTML API is asynchronous only.** From synchronous code Bit Miracle shows
  `Task.Run(async () => ...).GetAwaiter().GetResult()` and advises using it only when there is no other choice.
  ([Convert HTML to PDF](https://bitmiracle.com/pdf-library/html-pdf/convert#sync-code))
- **Header and footer templates** do not load external resources: use inline styles and data URIs, and set top and
  bottom margins so the templates are not covered (the default margins are 0).
  ([Convert HTML to PDF](https://bitmiracle.com/pdf-library/html-pdf/convert#header-footer))
- **Wide layouts**: Bit Miracle's way to fit a wide page is a larger PDF page size or `Page.Scale`.
  ([Convert HTML to PDF](https://bitmiracle.com/pdf-library/html-pdf/convert#custom-page-settings))

## Links

- Official site: https://bitmiracle.com/pdf-library/
- Documentation: https://bitmiracle.com/pdf-library/help
- Samples: https://github.com/BitMiracle/Docotic.Pdf.Samples
- NuGet: https://www.nuget.org/packages/BitMiracle.Docotic.Pdf/
- Source repository: not open source
