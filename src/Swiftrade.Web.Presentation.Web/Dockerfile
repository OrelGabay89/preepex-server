#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Swiftrade.Web.Host/Swiftrade.Web.Host.csproj", "src/Swiftrade.Web.Host/"]
COPY ["src/Swiftrade.Infrastructure/Swiftrade.Infrastructure.csproj", "src/Swiftrade.Infrastructure/"]
COPY ["src/Swiftrade.Services/Swiftrade.Services.csproj", "src/Swiftrade.Services/"]
COPY ["src/Swiftrade.Core/Swiftrade.Core.csproj", "src/Swiftrade.Core/"]
RUN dotnet restore "src/Swiftrade.Web.Host/Swiftrade.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/Swiftrade.Web.Host"
RUN dotnet build "Swiftrade.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Swiftrade.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Swiftrade.Web.Host.dll"]