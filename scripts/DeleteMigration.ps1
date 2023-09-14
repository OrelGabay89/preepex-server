param (
    [string]$migrationName = $env:NAME
)

Write-Host "Using migration name: $migrationName"
dotnet ef --startup-project "./src/Preepex.Web.Presentation.Web/Preepex.Web.Presentation.Web.csproj" --project "./src/Preepex.Infrastructure/Preepex.Infrastructure.csproj" migrations remove "$migrationName"