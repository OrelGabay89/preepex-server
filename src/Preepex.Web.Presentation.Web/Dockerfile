#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Preepex.Web.Host/Preepex.Web.Host.csproj", "src/Preepex.Web.Host/"]
COPY ["src/Preepex.Infrastructure/Preepex.Infrastructure.csproj", "src/Preepex.Infrastructure/"]
COPY ["src/Preepex.Services/Preepex.Services.csproj", "src/Preepex.Services/"]
COPY ["src/Preepex.Core/Preepex.Core.csproj", "src/Preepex.Core/"]
RUN dotnet restore "src/Preepex.Web.Host/Preepex.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/Preepex.Web.Host"
RUN dotnet build "Preepex.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Preepex.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Preepex.Web.Host.dll"]