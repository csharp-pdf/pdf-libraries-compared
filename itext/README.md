# iText (with pdfHTML)

iText Core is a .NET (and Java) library for creating, editing and enhancing PDF documents; pdfHTML is an iText
add-on that converts HTML and CSS into PDF
([nuget.org: itext](https://www.nuget.org/packages/itext/9.8.0),
[nuget.org: itext.pdfhtml](https://www.nuget.org/packages/itext.pdfhtml/6.3.4)).

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | Apryse Software (iText) | [nuget.org package owner/authors](https://www.nuget.org/packages/itext/9.8.0), [itextpdf.com](https://itextpdf.com/) | verified 2026-10-16 |
| Licence | Dual licence: AGPL-3.0 or commercial (OEM or volume subscription) | [How to buy](https://itextpdf.com/how-buy), [AGPLv3 licence](https://itextpdf.com/how-buy/AGPLv3-license) | verified 2026-10-16 |
| Price (entry) | Not published: commercial pricing is quote-based (OEM pricing is custom; the volume licence is an annual subscription priced on the number of PDF files processed) | [How to buy](https://itextpdf.com/how-buy) | verified 2026-10-16 |
| Free tier / trial limits | AGPL use is free of charge, with the AGPL conditions (your application's source must be disclosed under the AGPL, the iText producer line must be kept in every PDF); no watermark or page limit in the samples here. Commercial evaluation: 30-day free trial | [AGPLv3 licence](https://itextpdf.com/how-buy/AGPLv3-license), [How to buy](https://itextpdf.com/how-buy) | verified 2026-10-16 |
| NuGet package(s) | `itext` (Core), `itext.bouncy-castle-adapter` (required by the kernel), `itext.pdfhtml` (HTML add-on) | [Installing iText Community for .NET](https://kb.itextpdf.com/itext/installing-itext-community-for-net-developers), [nuget.org](https://www.nuget.org/packages/itext.pdfhtml/6.3.4) | verified 2026-10-16 |
| Latest version | itext 9.8.0, itext.bouncy-castle-adapter 9.8.0, itext.pdfhtml 6.3.4 | [itext](https://www.nuget.org/packages/itext/9.8.0), [itext.bouncy-castle-adapter](https://www.nuget.org/packages/itext.bouncy-castle-adapter/9.8.0), [itext.pdfhtml](https://www.nuget.org/packages/itext.pdfhtml/6.3.4) | verified 2026-10-16 |
| Target frameworks | .NET Standard 2.0, .NET Framework 4.6.1 | [nuget.org "Frameworks" tab](https://www.nuget.org/packages/itext/9.8.0#supportedframeworks-body-tab) | verified 2026-10-16 |
| Operating systems | Any OS that runs .NET Standard 2.0 (managed assemblies); Linux shown by this page's [Docker sample](docker/Dockerfile) | [nuget.org "Frameworks" tab](https://www.nuget.org/packages/itext/9.8.0#supportedframeworks-body-tab) | verified 2026-10-16 |
| Rendering engine (HTML to PDF) | Own (pdfHTML parses HTML and CSS itself, no browser; it does not run JavaScript) | [Do we need a browser engine to render HTML+CSS to PDF?](https://kb.itextpdf.com/itext/do-we-need-a-browser-engine-to-render-html-css-to-) | verified 2026-10-16 |
| Native dependencies | None (NuGet dependencies are managed packages: itext.commons, BouncyCastle.Cryptography, System.* packages) | [nuget.org "Dependencies" tab](https://www.nuget.org/packages/itext/9.8.0#dependencies-body-tab) | verified 2026-10-16 |
| Latest release date | 2026-09-30 (itext 9.8.0 and itext.pdfhtml 6.3.4 on nuget.org; GitHub release 2026-10-01) | [nuget.org versions](https://www.nuget.org/packages/itext#versions-body-tab), [GitHub release 9.8.0](https://github.com/itext/itext-dotnet/releases/tag/9.8.0), [release notes](https://kb.itextpdf.com/itext/release-itext-core-9-8-0) | verified 2026-10-16 |

## Install

```bash
dotnet add package itext --version 9.8.0
dotnet add package itext.bouncy-castle-adapter --version 9.8.0
dotnet add package itext.pdfhtml --version 6.3.4   # HTML to PDF
```

## Supported tasks

| # | Task | Status | Sample |
|---|---|---|---|
| T1 | Hello world PDF | supported | [T01-hello-world](samples/T01-hello-world/Program.cs) |
| T2 | HTML string to PDF | add-on: pdfHTML (`itext.pdfhtml`) | [T02-html-string](samples/T02-html-string/Program.cs) |
| T3 | URL to PDF | add-on: pdfHTML (`itext.pdfhtml`); pdfHTML has no URL input, so the page is downloaded and converted as a stream, as in [iText's sample](https://github.com/itext/itext-publications-samples-dotnet/blob/develop/itext/itext.publications/itext.publications.htmlsamples/itext/samples/htmlsamples/chapter07/C07E04_CreateFromURL.cs) | [T03-url](samples/T03-url/Program.cs) |
| T4 | Page size, margins and orientation | supported | [T04-page-setup](samples/T04-page-setup/Program.cs) |
| T5 | Header and footer with page numbers | supported (the sample uses pdfHTML CSS `@page` margin boxes; with iText Core alone, page event handlers, as in [PdfHtmlHeaderAndFooter](https://github.com/itext/itext-publications-samples-dotnet/blob/develop/itext/itext.samples/itext/samples/sandbox/pdfhtml/PdfHtmlHeaderAndFooter.cs)) | [T05-header-footer](samples/T05-header-footer/Program.cs) |
| T6 | Merge PDFs | supported | [T06-merge](samples/T06-merge/Program.cs) |
| T7 | Watermark / stamp | supported | [T07-watermark](samples/T07-watermark/Program.cs) |
| T8 | Fill a PDF form | supported | [T08-fill-form](samples/T08-fill-form/Program.cs) |
| T9 | Extract text | supported | [T09-extract-text](samples/T09-extract-text/Program.cs) |
| T10 | PDF to image | add-on: pdfRender, which has no native .NET API: it is called as a command-line tool and needs a licence file ([How do I use pdfRender in a .NET environment?](https://kb.itextpdf.com/itext/how-do-i-use-pdfrender-in-a-net-environment)); no sample | — |
| T11 | Digital signature | supported | [T11-digital-signature](samples/T11-digital-signature/Program.cs) |
| T12 | PDF/A output | supported (PDF/A-2b; the sample converts the T2 HTML with pdfHTML) | [T12-pdfa](samples/T12-pdfa/Program.cs) |
| T13 | ASP.NET Core endpoint | supported (returns the T2 document, pdfHTML) | [T13-aspnet-core](samples/T13-aspnet-core/Program.cs) |
| T14 | Linux / Docker deployment | supported | [docker/Dockerfile](docker/Dockerfile) |

## Benchmark results

<!-- benchmark-results: generated, do not edit -->

From the [2026-10-15 run](../benchmarks/2026-10-15.md) (Windows and Linux on the same machine; method and raw data are linked there). Each value is this library's own result; compare it with the other libraries on the results page.

|  | Result |
|---|---|
| HTML to PDF, median per page (Windows) | 94–1,334 ms over 18 pages; geometric mean 183 ms |
| Cold start (Windows) | 617 ms |
| Throughput, conversions/min, 1 / 8 at once (Windows) | 139 / 370 (sync); – / – (async) |
| Memory over 1,000 conversions (Windows) | 172 → 161 MB, 0 failures |
| HTML to PDF, median per page (Linux) | 136–1,406 ms over 18 pages; geometric mean 262 ms |
| Cold start (Linux) | 765 ms |
| Throughput, conversions/min, 1 / 8 at once (Linux) | 136 / 318 (sync); – / – (async) |
| Memory over 1,000 conversions (Linux) | 221 → 227 MB, 0 failures |
| Content checks (Windows) | 39 / 48; failed: isolation-read (text), isolation-write (text), js-chart (text), paged-media (pages), web-fonts (fontsEmbedded), wide-content (text) |
| Fidelity vs Chrome, mean SSIM (Windows) | 0.782 |
| PDF/A, PDF/UA, PDF/X levels produced / valid (of 17) | 10 / 8 |
| Working with existing PDFs and Word files (Windows) | all checks pass: redaction, merge, split, watermark, signature, form filling; some checks fail: text extraction (lowest F1 0.18), search (8/10 checks); not supported: PDF to image, Word to PDF, ZUGFeRD/Factur-X |
| Docker, minimal image | runs, 84 MB |

## Gotchas

- **AGPL conditions.** Without a commercial licence, iText is used under the AGPL: the source of your own
  application must be disclosed under the AGPL (including network deployment), and the producer line iText writes
  into every PDF must be kept ([AGPLv3 licence](https://itextpdf.com/how-buy/AGPLv3-license)).
- **The Bouncy Castle adapter is a separate package.** `itext.bouncy-castle-adapter` (or the FIPS variant, never
  both) has to be installed next to `itext` ([Installing iText Community for .NET](https://kb.itextpdf.com/itext/installing-itext-community-for-net-developers)).
- **pdfHTML is not a browser.** It parses HTML and CSS itself and does not evaluate JavaScript; iText suggests
  pre-processing script-driven pages with a browser engine ([KB](https://kb.itextpdf.com/itext/do-we-need-a-browser-engine-to-render-html-css-to-)).
- **No URL input in pdfHTML.** `HtmlConverter` takes a string, a stream or a file; iText's own URL sample downloads
  the page first ([C07E04_CreateFromURL](https://github.com/itext/itext-publications-samples-dotnet/blob/develop/itext/itext.publications/itext.publications.htmlsamples/itext/samples/htmlsamples/chapter07/C07E04_CreateFromURL.cs)).
  With a stream there is no parent folder, so set a base URI for relative links, images and CSS
  ([Chapter 1: Hello HTML to PDF](https://kb.itextpdf.com/itext/chapter-1-hello-html-to-pdf)).
- **PDF/A needs an ICC profile from the application.** iText ships none; its samples load an sRGB profile from
  disk for the output intent, and for HTML input use a font provider limited to embeddable fonts
  ([HtmlToPdfA3Convert](https://github.com/itext/itext-publications-samples-dotnet/blob/develop/itext/itext.samples/itext/samples/sandbox/pdfhtml/HtmlToPdfA3Convert.cs)).
- **Fonts in pdfHTML.** The default font provider registers the 14 standard PDF fonts and the fonts shipped with
  pdfHTML, not system fonts (`registerSystemFonts` defaults to `false`), so a container needs no font packages
  ([Chapter 6: Using fonts in pdfHTML](https://kb.itextpdf.com/itext/chapter-6-using-fonts-in-pdfhtml)).
- **Complex scripts need a closed-source add-on.** Indic ligatures and Hebrew right-to-left text need pdfCalligraph,
  which is "not available under an open source license"
  ([Which languages are supported in pdfHTML?](https://kb.itextpdf.com/itext/which-languages-are-supported-in-pdfhtml)).
- **No PDF rendering in .NET.** pdfRender is Java-native; .NET applications run its command-line version with a
  licence file ([KB](https://kb.itextpdf.com/itext/how-do-i-use-pdfrender-in-a-net-environment)).

## Links

- Official site: https://itextpdf.com/
- Documentation: https://kb.itextpdf.com/itext/ (knowledge base), https://api.itextpdf.com/iText/dotnet/9.8.0/ (API reference)
- Official samples: https://github.com/itext/itext-publications-samples-dotnet
- NuGet: https://www.nuget.org/packages/itext, https://www.nuget.org/packages/itext.pdfhtml
- Source repository: https://github.com/itext/itext-dotnet (iText Core), https://github.com/itext/i7n-pdfhtml (pdfHTML)
- Migration guide to SelectPdf (written by SelectPdf): https://github.com/selectpdf/migrate-to-selectpdf/tree/main/from-itext
