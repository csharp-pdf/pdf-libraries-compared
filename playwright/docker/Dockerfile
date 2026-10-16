# T14: samples/T02-html-string in Linux, on Playwright's official .NET image
# (https://playwright.dev/dotnet/docs/docker). Build from the playwright/ folder:
#   docker build -f docker/Dockerfile -t playwright-sample .
#   docker run --rm --init --ipc=host -v "$PWD/out:/out" playwright-sample /out/output.pdf

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY samples/T02-html-string/Sample.csproj samples/T02-html-string/Program.cs ./
RUN dotnet publish Sample.csproj -c Release -o /app

# The image holds the browsers of this Playwright version and their system dependencies, in /ms-playwright
# (PLAYWRIGHT_BROWSERS_PATH); its tag must match the Microsoft.Playwright package version.
FROM mcr.microsoft.com/playwright/dotnet:v1.63.0-noble
# The image is built on .NET 10; the sample targets net8.0, so the .NET 8 runtime is added with the
# install script the Docker page shows for other .NET versions.
RUN curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --install-dir /usr/share/dotnet --channel 8.0 --runtime dotnet
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Sample.dll"]
