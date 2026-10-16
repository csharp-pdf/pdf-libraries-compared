# T14: samples/T02-html-string on Linux. Build context: the docotic/ folder.
#   docker build -f docker/Dockerfile -t docotic-sample .
#   docker run --rm -e DOCOTIC_LICENSE_KEY -v "$PWD/out:/out" docotic-sample /out/output.pdf
# Bit Miracle's Docker setup: install the chromium package for Chromium's dependencies (the add-on still downloads its
# own Chromium build at the first conversion) and disable the Chromium sandbox in code, which the sample does when
# DOTNET_RUNNING_IN_CONTAINER is set (the official .NET images set it).
# https://bitmiracle.com/pdf-library/html-pdf/convert-in-azure

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY samples/T02-html-string/Sample.csproj samples/T02-html-string/Program.cs ./
RUN dotnet publish Sample.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
RUN apt-get update && apt-get install -y chromium && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Sample.dll"]
