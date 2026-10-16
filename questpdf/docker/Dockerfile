# T14: samples/T01-hello-world (QuestPDF has no HTML conversion) on the official .NET 8 images.
# Build from the questpdf/ folder:  docker build -f docker/Dockerfile -t questpdf-sample .
# Run:                              docker run --rm -v "$PWD/out:/out" questpdf-sample /out/output.pdf
#
# No OS packages are installed: the QuestPDF package ships its native libraries for linux-x64, linux-arm64 and
# linux-musl-x64, and its README lists Linux and Docker as supported (https://www.nuget.org/packages/QuestPDF).
# QuestPDF's documentation has no page of Linux packages to install.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY samples/T01-hello-world/Sample.csproj samples/T01-hello-world/Program.cs ./
RUN dotnet publish Sample.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Sample.dll"]
