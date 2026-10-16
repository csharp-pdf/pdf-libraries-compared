# T14: samples/T01-hello-world (PDFsharp has no HTML conversion) on the official .NET 8 images.
# PDFsharp's Core build is managed code and PDFsharp documents no OS packages. On Linux it finds no fonts:
# "Any fonts must be supplied by a FontResolver" (https://docs.pdfsharp.net/General/Overview/FAQ.html). The sample's
# resolver reads the TrueType file named by FONT_FILE; this image takes one from the Debian fonts-liberation package.
# Build from the library folder:  docker build -f docker/Dockerfile -t pdfsharp-sample .
# Run:                            docker run --rm -v "$PWD/out:/out" pdfsharp-sample /out/output.pdf
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY samples/T01-hello-world/Sample.csproj samples/T01-hello-world/Program.cs ./
RUN dotnet publish Sample.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends fonts-liberation \
    && rm -rf /var/lib/apt/lists/*
ENV FONT_FILE=/usr/share/fonts/truetype/liberation/LiberationSans-Regular.ttf
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Sample.dll"]
