
Migration:

#Add#

dotnet ef migrations add "ADD YOUR COMMENT HERE" -p src\Swiftrade.Infrastructure -s src\Swiftrade.Web.Presentation.Web -c ApplicationDbContext -o Migrations/Application
dotnet ef migrations add "ADD YOUR COMMENT HERE" -p src\Swiftrade.Infrastructure -s src\Swiftrade.Web.Presentation.Web -c AppIdentityDbContext -o Migrations/Identity

Then -->
#Update#
dotnet ef database update -p src\Swiftrade.Infrastructure -s src\Swiftrade.Web.Host  -c StoreContext
dotnet ef database update -p src\Swiftrade.Infrastructure -s src\Swiftrade.Web.Host  -c AppIdentityDbContext

update-database -context ApplicationDbContext
update-database -context IdentityDbContext
 
tasks
UseMustChangePassword middleware
