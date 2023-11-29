FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine3.17-arm64v8 as base

WORKDIR /build

COPY *.csproj StudentInformation.Consumer.csproj
COPY . .

RUN dotnet restore StudentInformation.Consumer.csproj
RUN dotnet build StudentInformation.Consumer.csproj

RUN dotnet publish StudentInformation.Consumer.csproj \
  --no-restore \
  -c Release \
  -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=base /app .

ENTRYPOINT ["dotnet", "StudentInformation.Consumer.dll"]