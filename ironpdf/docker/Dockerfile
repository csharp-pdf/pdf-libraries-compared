# T14: samples/T02-html-string in a Linux container.
# Follows IronPDF's Docker guide (https://ironpdf.com/get-started/ironpdf-docker/), ".NET 8 on Ubuntu 24.04":
# the official .NET noble images, the guide's apt-get package list, and the IronPdf.Linux package (the
# sample's .csproj selects it when it is built on Linux). The licence key is passed at run time:
#   docker build -f docker/Dockerfile -t ironpdf-sample .        (build context: the ironpdf/ folder)
#   docker run --rm -e IRONPDF_LICENSE_KEY -v "$PWD/out:/out" ironpdf-sample /out/output.pdf

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-noble AS build
WORKDIR /app
COPY samples/T02-html-string/Sample.csproj .
RUN dotnet restore
COPY samples/T02-html-string/Program.cs .
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-noble AS runtime

# Install IronPDF dependencies for Ubuntu 24.04 Noble (64-bit transition libraries)
RUN apt-get update && apt-get install -y \
    libasound2t64 \
    libatk1.0-0t64 \
    libatk-bridge2.0-0t64 \
    libcairo2 \
    libcups2t64 \
    libdbus-1-3 \
    libdrm2 \
    libexpat1 \
    libfontconfig1 \
    libgbm1 \
    libglib2.0-0t64 \
    libgtk-3-0t64 \
    libnspr4 \
    libnss3 \
    libpango-1.0-0 \
    libpangocairo-1.0-0 \
    libx11-6 \
    libxcb1 \
    libxcomposite1 \
    libxdamage1 \
    libxext6 \
    libxfixes3 \
    libxkbcommon0 \
    libxrandr2 \
    fonts-liberation \
    wget \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Sample.dll"]
