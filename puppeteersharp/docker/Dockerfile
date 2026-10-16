# T14: samples/T02-html-string in Linux. Build from the puppeteersharp/ folder:
#   docker build -f docker/Dockerfile -t puppeteersharp-sample .
#   docker run --rm --init -v "$PWD/out:/out" puppeteersharp-sample /out/output.pdf
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY samples/T02-html-string/Sample.csproj samples/T02-html-string/Program.cs ./
RUN dotnet publish Sample.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
# The Debian dependencies listed in Puppeteer's troubleshooting guide, which the PuppeteerSharp README links
# (https://pptr.dev/troubleshooting#chrome-doesnt-launch-on-linux).
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
       ca-certificates fonts-liberation libasound2 libatk-bridge2.0-0 libatk1.0-0 libc6 libcairo2 libcups2 \
       libdbus-1-3 libexpat1 libfontconfig1 libgbm1 libgcc1 libglib2.0-0 libgtk-3-0 libnspr4 libnss3 \
       libpango-1.0-0 libpangocairo-1.0-0 libstdc++6 libx11-6 libx11-xcb1 libxcb1 libxcomposite1 libxcursor1 \
       libxdamage1 libxext6 libxfixes3 libxi6 libxrandr2 libxrender1 libxss1 libxtst6 lsb-release wget xdg-utils \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app ./
# A non-root user, as in the guide's Docker example.
RUN groupadd -r pptruser && useradd -r -m -g pptruser -G audio,video pptruser && chown -R pptruser:pptruser /app
USER pptruser
# Without extra privileges, Docker's default security profile leaves Chrome no usable sandbox ("No usable
# sandbox!"). The guide runs its container with --cap-add=SYS_ADMIN instead; to keep Chrome's sandbox, delete this
# line and run the image with that flag. PUPPETEER_DANGEROUS_NO_SANDBOX=true makes PuppeteerSharp add --no-sandbox
# (https://github.com/hardkoded/puppeteer-sharp/releases/tag/v24.40.0); the guide strongly discourages running
# without a sandbox (https://pptr.dev/troubleshooting#setting-up-chrome-linux-sandbox).
ENV PUPPETEER_DANGEROUS_NO_SANDBOX=true
# Runs the sample once, so that BrowserFetcher.DownloadAsync() stores Chrome in /app at build time rather than at
# every container start.
RUN dotnet Sample.dll /tmp/output.pdf && rm /tmp/output.pdf
ENTRYPOINT ["dotnet", "Sample.dll"]
