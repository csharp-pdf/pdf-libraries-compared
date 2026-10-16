# T14: samples/T02-html-string on the official .NET 8 images. iText Core and pdfHTML are managed .NET Standard 2.0
# assemblies and iText documents no OS packages for them. pdfHTML's default font provider uses the fonts shipped
# with pdfHTML, not system fonts (https://kb.itextpdf.com/itext/chapter-6-using-fonts-in-pdfhtml).
# Build from the library folder:  docker build -f docker/Dockerfile -t itext-sample .
# Run:                            docker run --rm -v "$PWD/out:/out" itext-sample /out/output.pdf
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY samples/T02-html-string/Sample.csproj samples/T02-html-string/Program.cs ./
RUN dotnet publish Sample.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Sample.dll"]
