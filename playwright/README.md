# Playwright for .NET

Playwright for .NET is Microsoft's browser automation library for Chromium, Firefox and WebKit, used mainly for
end-to-end testing of web apps. It creates PDFs with Chromium's `page.PdfAsync`, which prints the current page; it
has no API for opening or changing existing PDF files.

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | Microsoft | [nuget.org](https://www.nuget.org/packages/Microsoft.Playwright/1.63.0) | verified 2026-10-16 |
| Licence | MIT (the .NET package); the Node.js driver bundled in the package is Apache-2.0 | [nuget.org](https://www.nuget.org/packages/Microsoft.Playwright/1.63.0), [playwright-dotnet](https://github.com/microsoft/playwright-dotnet/blob/main/LICENSE), [playwright](https://github.com/microsoft/playwright/blob/main/LICENSE) | verified 2026-10-16 |
| Price (entry) | Free (open source) | [nuget.org](https://www.nuget.org/packages/Microsoft.Playwright/1.63.0) | verified 2026-10-16 |
| Free tier / trial limits | None: no trial, no page or watermark limits | [playwright-dotnet licence](https://github.com/microsoft/playwright-dotnet/blob/main/LICENSE) | verified 2026-10-16 |
| NuGet package(s) | `Microsoft.Playwright` | [nuget.org](https://www.nuget.org/packages/Microsoft.Playwright/) | verified 2026-10-16 |
| Latest version | 1.63.0 | [nuget.org](https://www.nuget.org/packages/Microsoft.Playwright/1.63.0) | verified 2026-10-16 |
| Target frameworks | .NET Standard 2.0 (.NET 8 recommended) | [nuget.org Frameworks tab](https://www.nuget.org/packages/Microsoft.Playwright/1.63.0#supportedframeworks-body-tab), [system requirements](https://playwright.dev/dotnet/docs/intro#system-requirements) | verified 2026-10-16 |
| Operating systems | Windows 11+, Windows Server 2019+, WSL; macOS 14+; Debian 12 and 13, Ubuntu 22.04, 24.04 and 26.04 (x86-64 and arm64) | [system requirements](https://playwright.dev/dotnet/docs/intro#system-requirements) | verified 2026-10-16 |
| Rendering engine (HTML to PDF) | Chromium: version 1.63.0 uses Chromium 153.0.8010.12, a Chrome for Testing build | [release notes v1.63.0](https://github.com/microsoft/playwright-dotnet/releases/tag/v1.63.0), [browsers](https://playwright.dev/dotnet/docs/browsers#chromium) | verified 2026-10-16 |
| Native dependencies | The browser is not in the package; it is downloaded with `playwright.ps1 install` and runs as a separate process. The package bundles a Node.js runtime for the Playwright driver. On Linux, the browser needs system packages (`install-deps`) | [browsers](https://playwright.dev/dotnet/docs/browsers#install-browsers), [install system dependencies](https://playwright.dev/dotnet/docs/browsers#install-system-dependencies) | verified 2026-10-16 |
| Latest release date | 2026-09-23 (nuget.org); GitHub release 2026-09-21 | [nuget.org versions](https://www.nuget.org/packages/Microsoft.Playwright/#versions-body-tab), [GitHub release](https://github.com/microsoft/playwright-dotnet/releases/tag/v1.63.0) | verified 2026-10-16 |

## Install

```bash
dotnet add package Microsoft.Playwright
dotnet build
pwsh bin/Debug/net8.0/playwright.ps1 install chromium
```

The browser can also be installed from code, which is what the samples here do
([Install browsers via API](https://playwright.dev/dotnet/docs/browsers#install-browsers-via-api)):

```csharp
var exitCode = Microsoft.Playwright.Program.Main(["install", "chromium"]);
if (exitCode != 0)
    throw new Exception($"Playwright exited with code {exitCode}");
```

On Linux, `install --with-deps chromium` also installs the browser's system packages
([install system dependencies](https://playwright.dev/dotnet/docs/browsers#install-system-dependencies)).

## Supported tasks

| # | Task | Status | Sample |
|---|---|---|---|
| T1 | Hello world PDF | **supported** | [T01-hello-world](samples/T01-hello-world/Program.cs) |
| T2 | HTML string to PDF | **supported** | [T02-html-string](samples/T02-html-string/Program.cs) |
| T3 | URL to PDF | **supported** | [T03-url](samples/T03-url/Program.cs) |
| T4 | Page size, margins and orientation | **supported** | [T04-page-setup](samples/T04-page-setup/Program.cs) |
| T5 | Header and footer with page numbers | **supported** | [T05-header-footer](samples/T05-header-footer/Program.cs) |
| T6 | Merge PDFs | **not supported** | [`page.PdfAsync` is the only PDF API; it prints a page](https://playwright.dev/dotnet/docs/api/class-page#page-pdf) |
| T7 | Watermark / stamp | **not supported** | [no API for existing PDFs](https://playwright.dev/dotnet/docs/api/class-page#page-pdf) |
| T8 | Fill a PDF form | **not supported** | [no API for existing PDFs](https://playwright.dev/dotnet/docs/api/class-page#page-pdf) |
| T9 | Extract text | **not supported** | [no API for existing PDFs](https://playwright.dev/dotnet/docs/api/class-page#page-pdf) |
| T10 | PDF to image | **not supported** | [no API for existing PDFs](https://playwright.dev/dotnet/docs/api/class-page#page-pdf) |
| T11 | Digital signature | **not supported** | [no signing option in `page.PdfAsync`](https://playwright.dev/dotnet/docs/api/class-page#page-pdf) |
| T12 | PDF/A output | **not supported** | [no PDF/A option in `page.PdfAsync`](https://playwright.dev/dotnet/docs/api/class-page#page-pdf) |
| T13 | ASP.NET Core endpoint | **supported** | [T13-aspnet-core](samples/T13-aspnet-core/Program.cs) |
| T14 | Linux / Docker deployment | **supported** | [docker/Dockerfile](docker/Dockerfile) |

Status values: **supported** (link the sample), **not supported** (link the
source that says so), **add-on** (name the extra package or product).

## Benchmark results

<!-- benchmark-results: generated, do not edit -->

From the [2026-10-15 run](../benchmarks/2026-10-15.md) (Windows and Linux on the same machine; method and raw data are linked there). Each value is this library's own result; compare it with the other libraries on the results page.

|  | Result |
|---|---|
| HTML to PDF, median per page (Windows) | 101–1,417 ms over 18 pages; geometric mean 280 ms |
| Cold start (Windows) | 823 ms |
| Throughput, conversions/min, 1 / 8 at once (Windows) | 223 / 1,167 (sync); 208 / 1,205 (async) |
| Memory over 1,000 conversions (Windows) | 276 → 302 MB, 1 failures |
| HTML to PDF, median per page (Linux) | 51–1,099 ms over 18 pages; geometric mean 108 ms |
| Cold start (Linux) | 771 ms |
| Throughput, conversions/min, 1 / 8 at once (Linux) | 603 / 2,080 (sync); 524 / 2,490 (async) |
| Memory over 1,000 conversions (Linux) | 435 → 721 MB, 0 failures |
| Content checks (Windows) | 38 / 42; failed: forms (formFields), html-header-footer (imageEveryPage), wide-content (text) |
| Fidelity vs Chrome, mean SSIM (Windows) | 0.948 |
| Working with existing PDFs and Word files (Windows) | not supported: text extraction, search, PDF to image, Word to PDF, redaction, merge, split, watermark, signature, form filling, ZUGFeRD/Factur-X |
| Docker, minimal image | does not run, 123 MB |

## Gotchas

- **The browser is a separate download.** Browsers go to `%USERPROFILE%\AppData\Local\ms-playwright` on Windows,
  `~/Library/Caches/ms-playwright` on macOS and `~/.cache/ms-playwright` on Linux, or to `PLAYWRIGHT_BROWSERS_PATH`.
  They "take a few hundred megabytes of disk space", and each Playwright version needs its own browser build, so
  `install` has to run again after an upgrade.
  ([Managing browser binaries](https://playwright.dev/dotnet/docs/browsers#managing-browser-binaries))
- **`install chromium` downloads two builds**: the full Chromium build and the Chromium headless shell, which a
  headless launch uses by default. `--only-shell` skips the full build when only headless mode is used; the
  `chromium` channel selects Chrome's new headless mode instead.
  ([Chromium: headless shell](https://playwright.dev/dotnet/docs/browsers#chromium-headless-shell))
- **Print media by default.** `page.PdfAsync` renders with `print` CSS media; call `EmulateMediaAsync` with
  `Media.Screen` first for the screen layout. Backgrounds are not printed unless `PrintBackground = true`.
  ([page.PdfAsync](https://playwright.dev/dotnet/docs/api/class-page#page-pdf))
- **Defaults: Letter paper, no margins, untagged.** `Format` defaults to Letter, all margins to 0, and `Tagged` and
  `Outline` to false. ([page.PdfAsync options](https://playwright.dev/dotnet/docs/api/class-page#page-pdf))
- **Header and footer templates are limited.** "Script tags inside templates are not evaluated" and "Page styles
  are not visible inside templates"; page numbers come from elements with the classes `pageNumber` and
  `totalPages`. With the default zero margins there is no room for them, so the T5 sample sets top and bottom
  margins. ([page.PdfAsync](https://playwright.dev/dotnet/docs/api/class-page#page-pdf))
- **Linux needs system packages.** `install-deps` (or `install --with-deps`) installs them; behind a proxy run it
  as root. ([Install system dependencies](https://playwright.dev/dotnet/docs/browsers#install-system-dependencies))
- **Docker image.** `mcr.microsoft.com/playwright/dotnet:v1.63.0-noble` contains the browsers and their system
  dependencies but not the Playwright package; its tag must match the package version. It is built on .NET 10, so
  the T14 Dockerfile adds the .NET 8 runtime with the install script shown on the Docker page. The page recommends
  `--init` and `--ipc=host` ("Chromium can run out of memory and crash" without it), and a non-root user with a
  seccomp profile for untrusted pages. The T14 image is about 1.5 GB compressed (5.3 GB on disk), as it includes
  Firefox and WebKit. ([Docker](https://playwright.dev/dotnet/docs/docker),
  [recommended configuration](https://playwright.dev/dotnet/docs/docker#recommended-docker-configuration),
  [other .NET versions](https://playwright.dev/dotnet/docs/docker#using-a-different-net-version))

## Links

- Official site: https://playwright.dev/dotnet/
- Documentation: https://playwright.dev/dotnet/docs/intro, `page.PdfAsync`: https://playwright.dev/dotnet/docs/api/class-page#page-pdf
- NuGet: https://www.nuget.org/packages/Microsoft.Playwright/
- Source repository: https://github.com/microsoft/playwright-dotnet
- Migration guide to SelectPdf (written by SelectPdf): https://github.com/selectpdf/migrate-to-selectpdf/tree/main/from-playwright
