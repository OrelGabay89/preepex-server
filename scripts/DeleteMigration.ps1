param (
    [string]$migrationName = $env:NAME
)

Write-Host "Using migration name: $migrationName"
dotnet ef --startup-project "./src/Swiftrade.Web.Presentation.Web/Swiftrade.Web.Presentation.Web.csproj" --project "./src/Swiftrade.Infrastructure/Swiftrade.Infrastructure.csproj" migrations remove "$migrationName"