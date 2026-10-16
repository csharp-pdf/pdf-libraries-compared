# How samples are written and checked

Every library has one sample per task (T1–T14). A reader should be able to copy a sample's `Program.cs` into a
new console project, add the packages from its `.csproj`, and get the same result.

## Layout

```
<library-slug>/
  README.md                     the library page (from _template/README.md)
  samples/
    T01-hello-world/
      Sample.csproj             net8.0 console project, PackageReferences pinned to exact versions
      Program.cs                top-level statements, the vendor's documented API, short comments
      expect.json               what the checker verifies (below)
    T02-html-string/
    ...
    T13-aspnet-core/            an ASP.NET Core minimal API (Sdk="Microsoft.NET.Sdk.Web")
  docker/
    Dockerfile                  T14: builds samples/T02-html-string (or T01) into a Linux image
    expect.json
```

Task folders: `T01-hello-world`, `T02-html-string`, `T03-url`, `T04-page-setup`, `T05-header-footer`,
`T06-merge`, `T07-watermark`, `T08-fill-form`, `T09-extract-text`, `T10-pdf-to-image`, `T11-digital-signature`,
`T12-pdfa`. T13 is `T13-aspnet-core`; T14 is the library's `docker/` folder.

A task the library cannot do has **no folder**: the library page marks it *not supported* and links the source
that says so.

## Rules

- **Inputs and outputs by plain file name.** Samples read `invoice.pdf`, `accessible.pdf` and `order-form.pdf`
  (from [`_inputs/`](../_inputs)) from the current directory and write `output.pdf` (T10: `page-1.png`, …) to the
  current directory. The output file name may be passed as the first argument. The checker runs each sample in a
  scratch directory that holds a copy of the inputs.
- **The vendor's documented way.** Use the API the vendor's documentation or official samples use for the task,
  with their default settings; link that page in a comment at the top of `Program.cs`.
- **Licence keys from environment variables only**, never in code: `IRONPDF_LICENSE_KEY`, `ABCPDF_LICENSE_KEY`,
  `DOCOTIC_LICENSE_KEY`. A sample works without a key wherever the library has a keyless trial.
- **Exact package versions** in every `.csproj`, the same across one library's samples.
- **Short.** No helper classes unless the task needs them; no error handling beyond what the vendor shows.

## The tasks

| # | Task | What the sample does | Checked |
|---|---|---|---|
| T1 | Hello world PDF | A one-page PDF containing the text `Hello world` (HTML libraries convert `<h1>Hello world</h1>`; code-first libraries draw it). | 1 page; text |
| T2 | HTML string to PDF | Converts an HTML string with a heading `Quarterly report` and a 3-row table (`Alpha`, `Beta`, `Gamma`). | text |
| T3 | URL to PDF | Converts `https://example.com/`. | text `This domain is for use in documentation examples` (the page's only body text; `Example Domain` is just its `<title>`) |
| T4 | Page size, margins and orientation | `Hello world` on A4 **landscape** with 20 mm margins. | 842 × 595 pt; text |
| T5 | Header and footer with page numbers | A 3-page document (three `<h1>` sections separated by page breaks, or three drawn pages) with the header `Quarterly report` and the footer `Page N of M` on every page. | 3 pages; header and `Page N of 3` on each page |
| T6 | Merge PDFs | `invoice.pdf` + `accessible.pdf` → one PDF. | 5 pages; text from both |
| T7 | Watermark / stamp | `invoice.pdf` with the text `CONFIDENTIAL` on every page. | 3 pages; `CONFIDENTIAL` on each page; original text kept |
| T8 | Fill a PDF form | `order-form.pdf`: `name` = `Jane Doe`, `email` = `jane@example.com`, `plan` = `Pro`, `news` checked. | field values (pypdf) |
| T9 | Extract text | Prints the text of `invoice.pdf` to standard output. | stdout contains `Northwind Supplies` and `Total due` |
| T10 | PDF to image | Renders page 1 of `invoice.pdf` to `page-1.png` at 150 DPI. | PNG, about 1240 × 1754 px |
| T11 | Digital signature | Signs `invoice.pdf` with a self-signed certificate the sample creates at run time (`CertificateRequest`). | one signature, intact (pyHanko) |
| T12 | PDF/A | `invoice.pdf`'s content (or the T2 HTML) as **PDF/A-2b**, or the closest level the library documents (say which in `expect.json`). | veraPDF compliant |
| T13 | ASP.NET Core endpoint | A minimal API whose `GET /report` returns the T2 document as `application/pdf` (a library without HTML conversion returns its T1 document). | HTTP 200, PDF, text |
| T14 | Linux / Docker | `docker/Dockerfile`: a multi-stage build of `samples/T02-html-string` (a library without HTML conversion: `samples/T01-hello-world`) on the official .NET images, with the OS packages the vendor documents; the container writes the file named by its first argument (`/out/output.pdf`). If the vendor's documented Docker setup does not work on current .NET images, there is no `docker/` folder and the library page says why, with the source. The build context is the library folder: copy only the sample's `Sample.csproj` and `Program.cs` (never `bin/` or `obj/`). | image builds; PDF; text |

## expect.json

```json
{
  "outputs": [
    { "file": "output.pdf", "pages": 1, "text": ["Hello world"] }
  ]
}
```

Keys the checker understands, per output: `pages` (exact), `minPages`, `text` (all must appear in the document),
`textEveryPage` (a regular expression that must match on every page; escape backslashes for JSON, e.g. `"Page \d+ of 3"`), `pageSize` (`[width, height]` in points, ±2), `fields`
(`{"name": "Jane Doe"}`, read with pypdf), `signed` (`true`: one intact signature), `pdfa` (`"2b"`: veraPDF),
`image` (`[width, height]` in pixels, ±2 %). At the top level: `stdout` (strings that must appear in standard
output), `web` (`{"path": "/report"}` for T13) and `notes` (free text, e.g. why a different PDF/A level is used).

Run the checker from the repository root:

```bash
python tools/check_samples.py                 # every library
python tools/check_samples.py selectpdf T08   # one library, one task
```

It needs the .NET 8 SDK, Python 3 with `pypdf`, `pymupdf` and `pyhanko`, Docker for T14, and veraPDF for T12
(`VERAPDF` = path of the veraPDF launcher).
