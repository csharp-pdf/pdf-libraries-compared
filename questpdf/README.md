# QuestPDF

QuestPDF is a .NET library that generates PDF documents from C# code through a fluent layout API (text, images,
tables, grids, page headers and footers). It does not convert HTML. Its Document Operations API, built on qpdf,
works on existing PDF files: merge, page selection, overlay and underlay, attachments and encryption.

## Facts

| | | Source | Verified |
|---|---|---|---|
| Vendor | QuestPDF (NuGet owners: MarcinZiabek, QuestPDF) | [nuget.org](https://www.nuget.org/packages/QuestPDF/2026.9.1) | verified 2026-10-16 |
| Licence | QuestPDF Community License (free, for eligible users) or a paid Professional / Enterprise licence. The Community License is not an OSI-approved open-source licence, and the MIT License does not govern use under it. | [Community License](https://www.questpdf.com/license/community.html), [licence pages](https://www.questpdf.com/license/) | verified 2026-10-16 |
| Price (entry) | Professional: $1,999 + local tax, renews annually ("one legal entity", all developers). Enterprise: $4,999 + local tax (company and its affiliates). | [pricing](https://www.questpdf.com/pricing.html) | verified 2026-10-16 |
| Free tier / trial limits | Community: free for individuals and organisations with annual gross revenue under USD 1,000,000, and regardless of revenue for qualifying charities, academic institutions and open-source projects; public-sector entities and publicly traded companies are not eligible. No watermark, licence key or time limit. Organisations that do not qualify may evaluate for up to 60 days (internal testing, technical review, non-production use). | [pricing](https://www.questpdf.com/pricing.html), [License Selection Guide](https://www.questpdf.com/license/guide.html) | verified 2026-10-16 |
| NuGet package(s) | `QuestPDF` | [nuget.org](https://www.nuget.org/packages/QuestPDF) | verified 2026-10-16 |
| Latest version | 2026.9.1 | [nuget.org](https://www.nuget.org/packages/QuestPDF/2026.9.1) | verified 2026-10-16 |
| Target frameworks | net5.0, net6.0, net8.0, net10.0, netstandard2.0 | [nuget.org, Frameworks](https://www.nuget.org/packages/QuestPDF/2026.9.1#supportedframeworks-body-tab) | verified 2026-10-16 |
| Operating systems | Windows, Linux, macOS; Docker and Kubernetes listed as supported | [README on nuget.org](https://www.nuget.org/packages/QuestPDF/2026.9.1) | verified 2026-10-16 |
| Rendering engine (HTML to PDF) | none (no HTML conversion); layout and rendering by its own engine on Skia | [quick start](https://www.questpdf.com/quick-start.html), [release notes 2026.9.1](https://github.com/QuestPDF/QuestPDF/releases/tag/2026.9.1) | verified 2026-10-16 |
| Native dependencies | Native libraries `QuestPdfSkia` and `qpdf` ship in the package (`runtimes/` for win-x64, win-x86, win-arm64, linux-x64, linux-arm64, linux-musl-x64, osx-x64, osx-arm64); 2026.9.1 uses Skia m154 and qpdf 12.4.1 | [package (.nupkg)](https://www.nuget.org/api/v2/package/QuestPDF/2026.9.1), [release notes 2026.9.1](https://github.com/QuestPDF/QuestPDF/releases/tag/2026.9.1) | verified 2026-10-16 |
| Latest release date | 2026-09-25 (2026.9.1) | [nuget.org](https://www.nuget.org/packages/QuestPDF/2026.9.1), [GitHub releases](https://github.com/QuestPDF/QuestPDF/releases) | verified 2026-10-16 |

## Install

```bash
dotnet add package QuestPDF
```

Set the licence type once at startup, before the first document
([licence configuration](https://www.questpdf.com/license/configuration.html)):

```csharp
QuestPDF.Settings.License = LicenseType.Community;   // or Professional / Enterprise, whichever applies to you
```

## Supported tasks

| # | Task | Status | Sample |
|---|---|---|---|
| T1 | Hello world PDF | **supported** | [T01-hello-world](samples/T01-hello-world) |
| T2 | HTML string to PDF | **not supported** | QuestPDF builds documents from C# code; its [documentation index](https://www.questpdf.com/llms.txt) has no HTML conversion |
| T3 | URL to PDF | **not supported** | as T2 |
| T4 | Page size, margins and orientation | **supported** | [T04-page-setup](samples/T04-page-setup) |
| T5 | Header and footer with page numbers | **supported** | [T05-header-footer](samples/T05-header-footer) |
| T6 | Merge PDFs | **supported** | [T06-merge](samples/T06-merge) |
| T7 | Watermark / stamp | **supported** (overlay of a PDF page) | [T07-watermark](samples/T07-watermark) |
| T8 | Fill a PDF form | **not supported** | "Interactive fillable form fields (AcroForms) are not currently supported" ([issue #550](https://github.com/QuestPDF/QuestPDF/issues/550)); AcroForm support is listed under "Future" on the [roadmap](https://www.questpdf.com/roadmap.html) |
| T9 | Extract text | **not supported** | reading the content of existing PDFs ("PDF content inspection") is listed under "Future" on the [roadmap](https://www.questpdf.com/roadmap.html) |
| T10 | PDF to image | **not supported** | `GenerateImages` renders documents built with QuestPDF, not existing PDF files ([generating output](https://www.questpdf.com/concepts/generating-output.html), [Document Operations](https://www.questpdf.com/concepts/document-operations.html)) |
| T11 | Digital signature | **not supported** | "Digital signature support ... remains in our backlog" ([issue #369](https://github.com/QuestPDF/QuestPDF/issues/369)); listed under "Future" on the [roadmap](https://www.questpdf.com/roadmap.html) |
| T12 | PDF/A output | **supported** (documents QuestPDF builds; PDF/A-2b here) | [T12-pdfa](samples/T12-pdfa) |
| T13 | ASP.NET Core endpoint | **supported** (returns the T1 document) | [T13-aspnet-core](samples/T13-aspnet-core) |
| T14 | Linux / Docker deployment | **supported** (`mcr.microsoft.com/dotnet/runtime:8.0`, no extra OS packages) | [docker/](docker) |

Status values: **supported** (link the sample), **not supported** (link the
source that says so), **add-on** (name the extra package or product).

## Benchmark results

<!-- benchmark-results: generated, do not edit -->

From the [2026-10-15 run](../benchmarks/2026-10-15.md) (Windows and Linux on the same machine; method and raw data are linked there). Each value is this library's own result; compare it with the other libraries on the results page.

|  | Result |
|---|---|
| Working with existing PDFs and Word files (Windows) | all checks pass: merge, split, watermark; not supported: text extraction, search, PDF to image, Word to PDF, redaction, signature, form filling, ZUGFeRD/Factur-X |
| Docker, minimal image | runs, 84 MB |

## Gotchas

- **The licence type must be set in code.** `QuestPDF.Settings.License` is set once at application startup, before
  the first document ([licence configuration](https://www.questpdf.com/license/configuration.html)). Which type
  applies depends on revenue and organisation type, not on features: every tier has the same features
  ([pricing](https://www.questpdf.com/pricing.html)). An organisation whose revenue crosses USD 1,000,000 gets a
  90-day transition period from the end of that fiscal year ([pricing](https://www.questpdf.com/pricing.html)).
- **No HTML.** Documents are composed in C#; an HTML template has to be rebuilt with the layout API. Merge, overlay,
  page selection, attachments and encryption work on existing PDF files through `DocumentOperation`
  ([Document Operations](https://www.questpdf.com/concepts/document-operations.html)); `DocumentOperation.Save`
  writes to a file path.
- **Watermarks are overlays.** The documented route is a separate PDF page with the watermark, laid over the target
  pages with `OverlayFile` and `LayerConfiguration` (`RepeatSourcePages` repeats it on every page)
  ([Document Operations](https://www.questpdf.com/concepts/document-operations.html#overlays-and-underlays)).
- **PDF/A only for documents QuestPDF builds.** `DocumentSettings.PDFA_Conformance` (PDF/A-2 and PDF/A-3 levels)
  and `PDFUA_Conformance` (PDF/UA-1) apply to generated documents
  ([document settings](https://www.questpdf.com/concepts/document-settings.html),
  [accessibility](https://www.questpdf.com/concepts/accessibility.html)); PDF/A-4 and PDF/UA-2 are under "Future"
  on the [roadmap](https://www.questpdf.com/roadmap.html).
- **Fonts.** The package includes the Lato font (Latin, Greek and Cyrillic), so the samples need no system fonts,
  also in a bare Linux container. System fonts are not used unless `QuestPDF.Settings.UseSystemFonts = true`; the
  documentation recommends deploying the font files with the application, because a minimal container may have no
  fonts at all ([font management](https://www.questpdf.com/api-reference/text/font-management.html)).
- **Linux.** No OS packages were needed on `mcr.microsoft.com/dotnet/runtime:8.0` ([Dockerfile](docker/Dockerfile)).
  The SkiaSharp NuGet package QuestPDF documents for Linux applies only to its optional SkiaSharp integration
  ([SkiaSharp integration](https://www.questpdf.com/api-reference/skiasharp-integration.html)). The old
  "platform-specific dependencies" page
  (`https://www.questpdf.com/going-production/platform-specific-dependencies.html`) returns 404 (checked 2026-10-16).

## Links

- Official site: <https://www.questpdf.com/>
- Documentation: <https://www.questpdf.com/quick-start.html>
- NuGet: <https://www.nuget.org/packages/QuestPDF>
- Source repository: <https://github.com/QuestPDF/QuestPDF> (source published under the licences above; see [LICENSE.md](https://github.com/QuestPDF/QuestPDF/blob/main/LICENSE.md))
