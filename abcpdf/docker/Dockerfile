# T14: samples/T02-html-string on Linux. Build context: the abcpdf/ folder.
#   docker build -f docker/Dockerfile -t abcpdf-sample .
#   docker run --rm -e ABCPDF_LICENSE_KEY -v "$PWD/out:/out" abcpdf-sample /out/output.pdf
# Linux has no trial: ABCPDF_LICENSE_KEY must hold a licence (or trial) key.
# The .NET 8 images are Debian 12; the packages are the ABCChrome dependencies ABCpdf lists for Debian 12.7
# (a distribution it describes as not officially supported):
# https://www.websupergoo.com/helppdfnet/source/2-getting_started/6-platforms.htm

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY samples/T02-html-string/Sample.csproj samples/T02-html-string/Program.cs ./
RUN dotnet publish Sample.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
RUN apt-get update \
 && apt-get install -y libasound2 libnss3 libcurl4 \
 && apt-get install -y xserver-xorg-core --no-install-recommends --no-install-suggests \
 && apt-get install -y libcairo2 libatk1.0-0 libatk-bridge2.0-0 libcups2 libxcomposite1 libxdamage1 libxrandr2 \
        libxkbcommon0 libpango-1.0-0 \
 && apt-get install -y libglib2.0-0 \
 && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Sample.dll"]
