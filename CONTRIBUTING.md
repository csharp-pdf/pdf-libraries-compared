# Contributing

Thanks for helping keep these comparisons accurate.

## Ground rules

- **Every claim needs a source.** Link the vendor's documentation, pricing page,
  NuGet listing, changelog or a reproducible run, and add the date you checked it
  (`verified YYYY-MM-DD`). Claims without a source are not merged.
- **Samples must compile and run.** Each sample is a console project targeting
  `net8.0` unless the library cannot. CI builds and runs it; a sample that does not
  produce the expected output is not merged.
- **Use the library the way its vendor recommends.** If a sample is slow or wrong
  because it is configured badly, that is a bug in the sample — please fix it.
- **No ratings or marketing language.** Describe what a library does and link the
  evidence; leave the verdict to the reader.
- **Trial watermarks are fine.** Commercial libraries run on their free trial;
  never commit a licence key.

## Vendors

If you work on a library covered here, you are welcome to:

- correct facts about your product (with a source),
- improve your library's samples or configuration,
- point out a benchmark setting that does not reflect recommended usage.

Please say in the pull request that you represent the vendor. We will review
vendor corrections the same way as any other — on the evidence.

If your licence agreement restricts publishing benchmark results, let us know in
an issue and we will publish features and samples only.

## How to submit

- **Small fix (typo, outdated version, broken link):** open a pull request.
- **Factual correction:** use the
  [correction issue form](https://github.com/csharp-pdf/pdf-libraries-compared/issues/new?template=correction.yml), or a pull
  request that includes the source.
- **New library:** use the
  [library request form](https://github.com/csharp-pdf/pdf-libraries-compared/issues/new?template=add-library.yml). New library
  pages follow [`_template/README.md`](_template/README.md) and need samples for the
  full task set (or a sourced "not supported" for each missing task).

## Folder layout for a library

```
<library-slug>/
  README.md            facts, install, supported tasks, gotchas
  samples/
    T01-hello-world/   one console project per task
    T02-html-string/
    ...
  docker/Dockerfile    minimal working Linux image, or a sourced "not supported"
```

## Licensing of contributions

By contributing you agree that text is licensed under
[CC BY 4.0](LICENSE-CONTENT) and code under [MIT](LICENSE).
