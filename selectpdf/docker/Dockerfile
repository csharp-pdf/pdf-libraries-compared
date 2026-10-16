# T14: samples/T02-html-string in a Linux container.
# Follows https://selectpdf.com/pdf-library/html/Deployment-Docker.htm: a multi-stage build on the official .NET
# images, the project published for linux-x64 (which selects SelectPdf.Universal.Native.linux-x64, see the
# sample's .csproj), and no apt-get step - the native package bundles the Chromium libraries it needs.
# Build context: the selectpdf/ folder.
#   docker build -f docker/Dockerfile -t selectpdf-sample .
#   docker run --rm -v "$PWD/out:/out" selectpdf-sample /out/output.pdf
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY samples/T02-html-string/Sample.csproj samples/T02-html-string/Program.cs ./
RUN dotnet publish Sample.csproj -c Release -r linux-x64 --self-contained false -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Sample.dll"]
