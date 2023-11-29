FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine3.17-arm64v8 as base

WORKDIR /build


COPY StudentInformation.Application/*.csproj StudentInformation.Application/
COPY StudentInformation.Api/*.csproj StudentInformation.Api/
COPY StudentInformation.sln StudentInformation.sln
COPY . .

RUN dotnet restore
RUN dotnet build



RUN dotnet publish StudentInformation.Api \
  --no-restore \
  -c Release \
  -o /app


FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=base /app .
EXPOSE 5005
ENV ASPNETCORE_URLS=http://+:5005

ENTRYPOINT ["dotnet", "StudentInformation.Api.dll"]