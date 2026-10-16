# PuppeteerSharp

PuppeteerSharp is a .NET port of the Node.js Puppeteer API for automating Chrome and Firefox. It creates PDFs
with the browser's `page.pdf` (`PdfAsync`, `PdfDataAsync`, `PdfStreamAsync`), which prints the current page; it
has no API for opening or changing existing PDF files.

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | Open source project by Darío Kondratiuk (hardkoded) | [nuget.org](https://www.nuget.org/packages/PuppeteerSharp/25.13.1), [GitHub](https://github.com/hardkoded/puppeteer-sharp) | verified 2026-10-16 |
| Licence | MIT | [nuget.org](https://www.nuget.org/packages/PuppeteerSharp/25.13.1), [LICENSE](https://github.com/hardkoded/puppeteer-sharp/blob/master/LICENSE) | verified 2026-10-16 |
| Price (entry) | Free (open source) | [LICENSE](https://github.com/hardkoded/puppeteer-sharp/blob/master/LICENSE) | verified 2026-10-16 |
| Free tier / trial limits | None: no trial, no page or watermark limits | [LICENSE](https://github.com/hardkoded/puppeteer-sharp/blob/master/LICENSE) | verified 2026-10-16 |
| NuGet package(s) | `PuppeteerSharp` (also `PuppeteerSharp.Cdp` for Chrome-only AOT apps, `PuppeteerSharp.AspNetFramework` for ASP.NET on .NET Framework) | [README, Published Packages](https://github.com/hardkoded/puppeteer-sharp#published-packages) | verified 2026-10-16 |
| Latest version | 25.14.0; the samples here pin 25.13.1, the version in the benchmark run | [nuget.org versions](https://www.nuget.org/packages/PuppeteerSharp/#versions-body-tab) | verified 2026-10-16 |
| Target frameworks | .NET Standard 2.0, .NET 8, .NET 10 | [nuget.org Frameworks tab](https://www.nuget.org/packages/PuppeteerSharp/25.13.1#supportedframeworks-body-tab) | verified 2026-10-16 |
| Operating systems | Windows, macOS and Linux (the platforms `BrowserFetcher` downloads for); Chrome for Testing downloads for linux-arm64 since 25.13.0 | [BrowserFetcher.cs](https://github.com/hardkoded/puppeteer-sharp/blob/v25.13.1/lib/PuppeteerSharp/BrowserFetcher.cs), [release notes v25.13.0](https://github.com/hardkoded/puppeteer-sharp/releases/tag/v25.13.0) | verified 2026-10-16 |
| Rendering engine (HTML to PDF) | Chrome: 25.13.1 downloads Chrome for Testing 154.0.8037.57 (25.14.0: 155.0.8059.79) | [release notes v25.12.0](https://github.com/hardkoded/puppeteer-sharp/releases/tag/v25.12.0), [v25.14.0](https://github.com/hardkoded/puppeteer-sharp/releases/tag/v25.14.0), [Chrome for Testing](https://developer.chrome.com/blog/chrome-for-testing) | verified 2026-10-16 |
| Native dependencies | The browser is not in the package; `BrowserFetcher.DownloadAsync()` downloads it and it runs as a separate process. The browser is Google's Chrome for Testing build, which is not covered by the package's MIT licence. On Linux it needs the system libraries in Puppeteer's troubleshooting guide | [README, Generate PDF files](https://github.com/hardkoded/puppeteer-sharp#generate-pdf-files), [Chrome for Testing](https://developer.chrome.com/blog/chrome-for-testing), [troubleshooting](https://pptr.dev/troubleshooting#chrome-doesnt-launch-on-linux) | verified 2026-10-16 |
| Latest release date | 25.14.0: 2026-10-15; 25.13.1: 2026-10-11 (nuget.org) | [nuget.org versions](https://www.nuget.org/packages/PuppeteerSharp/#versions-body-tab), [GitHub releases](https://github.com/hardkoded/puppeteer-sharp/releases) | verified 2026-10-16 |

## Install

```bash
dotnet add package PuppeteerSharp
```

The browser is downloaded from code, as in the README's sample
([Generate PDF files](https://github.com/hardkoded/puppeteer-sharp#generate-pdf-files)):

```csharp
var browserFetcher = new BrowserFetcher();
await browserFetcher.DownloadAsync();
```

## Supported tasks

| # | Task | Status | Sample |
|---|---|---|---|
| T1 | Hello world PDF | **supported** | [T01-hello-world](samples/T01-hello-world/Program.cs) |
| T2 | HTML string to PDF | **supported** | [T02-html-string](samples/T02-html-string/Program.cs) |
| T3 | URL to PDF | **supported** | [T03-url](samples/T03-url/Program.cs) |
| T4 | Page size, margins and orientation | **supported** | [T04-page-setup](samples/T04-page-setup/Program.cs) |
| T5 | Header and footer with page numbers | **supported** | [T05-header-footer](samples/T05-header-footer/Program.cs) |
| T6 | Merge PDFs | **not supported** | [the PDF API prints a page (`PdfOptions`)](https://www.puppeteersharp.com/api/PuppeteerSharp.PdfOptions.html) |
| T7 | Watermark / stamp | **not supported** | [no API for existing PDFs](https://www.puppeteersharp.com/api/PuppeteerSharp.PdfOptions.html) |
| T8 | Fill a PDF form | **not supported** | [no API for existing PDFs](https://www.puppeteersharp.com/api/PuppeteerSharp.PdfOptions.html) |
| T9 | Extract text | **not supported** | [no API for existing PDFs](https://www.puppeteersharp.com/api/PuppeteerSharp.PdfOptions.html) |
| T10 | PDF to image | **not supported** | [no API for existing PDFs](https://www.puppeteersharp.com/api/PuppeteerSharp.PdfOptions.html) |
| T11 | Digital signature | **not supported** | [no signing option in `PdfOptions`](https://www.puppeteersharp.com/api/PuppeteerSharp.PdfOptions.html) |
| T12 | PDF/A output | **not supported** | [no PDF/A option in `PdfOptions`](https://www.puppeteersharp.com/api/PuppeteerSharp.PdfOptions.html) |
| T13 | ASP.NET Core endpoint | **supported** | [T13-aspnet-core](samples/T13-aspnet-core/Program.cs) |
| T14 | Linux / Docker deployment | **supported** | [docker/Dockerfile](docker/Dockerfile) |

Status values: **supported** (link the sample), **not supported** (link the
source that says so), **add-on** (name the extra package or product).

## Benchmark results

<!-- benchmark-results: generated, do not edit -->

From the [2026-10-15 run](../benchmarks/2026-10-15.md) (Windows and Linux on the same machine; method and raw data are linked there). Each value is this library's own result; compare it with the other libraries on the results page.

|  | Result |
|---|---|
| HTML to PDF, median per page (Windows) | 274–1,688 ms over 18 pages; geometric mean 486 ms |
| Cold start (Windows) | 1,003 ms |
| Throughput, conversions/min, 1 / 8 at once (Windows) | 125 / 325 (sync); 127 / 346 (async) |
| Memory over 1,000 conversions (Windows) | 325 → 584 MB, 0 failures |
| HTML to PDF, median per page (Linux) | 75–1,111 ms over 18 pages; geometric mean 150 ms |
| Cold start (Linux) | 528 ms |
| Throughput, conversions/min, 1 / 8 at once (Linux) | 450 / 798 (sync); 471 / 838 (async) |
| Memory over 1,000 conversions (Linux) | 398 → 683 MB, 0 failures |
| Content checks (Windows) | 38 / 42; failed: forms (formFields), html-header-footer (imageEveryPage), wide-content (text) |
| Fidelity vs Chrome, mean SSIM (Windows) | 0.949 |
| Working with existing PDFs and Word files (Windows) | not supported: text extraction, search, PDF to image, Word to PDF, redaction, merge, split, watermark, signature, form filling, ZUGFeRD/Factur-X |
| Docker, minimal image | does not run, 79 MB |

## Gotchas

- **Where the browser goes.** Without `BrowserFetcherOptions.Path`, `BrowserFetcher` stores browsers in the
  application's own folder (`AppContext.BaseDirectory`), so every application or build output gets its own copy.
  For the default browser, `DownloadAsync()` downloads both Chrome for Testing and Chrome Headless Shell; with the
  samples here on Windows x64 that is about 435 MB plus 273 MB per folder.
  ([BrowserFetcher.cs](https://github.com/hardkoded/puppeteer-sharp/blob/v25.13.1/lib/PuppeteerSharp/BrowserFetcher.cs#L129-L139),
  [BrowserFetcherOptions](https://www.puppeteersharp.com/api/PuppeteerSharp.BrowserFetcherOptions.html))
- **Install the browser before the application runs in production.** "Installing the browser during runtime is
  not recommended"; the docs advise installing it beforehand and passing its path to `LaunchAsync`. The T14
  Dockerfile runs the sample once at build time so that the download is in the image.
  ([Issues generating PDF files](https://github.com/hardkoded/puppeteer-sharp/blob/master/docfx_project/docs/IssuesGeneratingPdfFiles.md))
- **PDF timeouts on Windows servers.** Since Chromium 125, PDF generation needs sandbox permissions on the browser
  folder; PuppeteerSharp tries to set them after the download and reports the result in
  `InstalledBrowser.PermissionsFixed`. ([Issues generating PDF files](https://github.com/hardkoded/puppeteer-sharp/blob/master/docfx_project/docs/IssuesGeneratingPdfFiles.md))
- **Print media by default.** `page.pdf` uses the print CSS media type; call `EmulateMediaTypeAsync(MediaType.Screen)`
  first for the screen layout. Backgrounds are not printed unless `PrintBackground = true`.
  ([Puppeteer Page.pdf](https://pptr.dev/api/puppeteer.page.pdf), [PdfOptions](https://www.puppeteersharp.com/api/PuppeteerSharp.PdfOptions.html))
- **Defaults: Letter paper, no margins, tagged.** `Format` defaults to Letter and margins to none; `Tagged` is
  true in PuppeteerSharp 25. ([Puppeteer PDFOptions](https://pptr.dev/api/puppeteer.pdfoptions),
  [PdfOptions.cs](https://github.com/hardkoded/puppeteer-sharp/blob/v25.13.1/lib/PuppeteerSharp/PdfOptions.cs))
- **Header and footer templates.** Page numbers come from elements with the classes `pageNumber` and `totalPages`.
  With the default margins (none) the templates have no room, so the T5 sample sets top and bottom margins.
  ([PdfOptions.HeaderTemplate](https://www.puppeteersharp.com/api/PuppeteerSharp.PdfOptions.html))
- **Linux system libraries.** The README links Puppeteer's troubleshooting guide, which lists the Debian/Ubuntu
  packages Chrome needs; the T14 Dockerfile installs that list. The README also says "X-server is required on
  Linux"; the T14 container runs headless without one.
  ([README, Prerequisites](https://github.com/hardkoded/puppeteer-sharp#prerequisites),
  [troubleshooting](https://pptr.dev/troubleshooting#chrome-doesnt-launch-on-linux))
- **Chrome's sandbox in Docker.** Started without extra privileges, Chrome fails with "No usable sandbox!". The
  guide's Docker example runs as a non-root user and starts the container with `--cap-add=SYS_ADMIN`; running
  without a sandbox is "strongly discouraged". The T14 Dockerfile sets `PUPPETEER_DANGEROUS_NO_SANDBOX=true`
  (PuppeteerSharp then adds `--no-sandbox`) so that it runs with a plain `docker run`; remove it and use
  `--cap-add=SYS_ADMIN` to keep the sandbox.
  ([Running Puppeteer in Docker](https://pptr.dev/troubleshooting#running-puppeteer-in-docker),
  [Setting up Chrome Linux sandbox](https://pptr.dev/troubleshooting#setting-up-chrome-linux-sandbox),
  [release notes v24.40.0](https://github.com/hardkoded/puppeteer-sharp/releases/tag/v24.40.0))

## Links

- Official site: https://www.puppeteersharp.com/
- Documentation: https://www.puppeteersharp.com/api/index.html, examples: https://www.puppeteersharp.com/docs/index.html
- NuGet: https://www.nuget.org/packages/PuppeteerSharp/
- Source repository: https://github.com/hardkoded/puppeteer-sharp
- Migration guide to SelectPdf (written by SelectPdf): https://github.com/selectpdf/migrate-to-selectpdf/tree/main/from-puppeteersharp
