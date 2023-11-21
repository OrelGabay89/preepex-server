using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Preepex.Core.Application.Extenstions;
using Preepex.Presentation.Framework.Routing;
using Preepex.Web.Presentation.Web.Extensions;
using Preepex.Web.Presentation.Web.Middleware;
using StackExchange.Redis;
using System.IO;

namespace Preepex.Web.Presentation.Web
{
    public class Startup
    {

        private const string _defaultCorsPolicyName = "CorsPolicy";
        //private const string _clientAppStoreDist = "wwwroot";
        private const string _clientAppAdminDist = "wwwroot/adminapp";


        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("Default30",
                    new CacheProfile()
                    {
                        Duration = 30,
                    });
            });

            //////ROUTING
            services.AddRouting(options => options.LowercaseUrls = true);

            //////LOCALIZATION
            services.AddLocalization(options => options.ResourcesPath = "");

            ////CACHING
            services.AddResponseCaching();

            services.AddInfrastructure(_config);

            services.AddApplicationLayer();

            services.AddApplicationServices();

            // Configure CORS for angular UI
            //services.AddCors(
            //    options => options.AddPolicy(
            //        _defaultCorsPolicyName,
            //        builder => builder
            //            .WithOrigins(
            //             // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
            //             _config.GetCorsOrigins())
            //            .AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .AllowCredentials()
            //    )
            //);

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            //In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = _clientAppAdminDist;
            });


            services.AddSwaggerDocumentation();
            services.AddControllers(options => options.EnableEndpointRouting = false);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Common Swagger configuration for both Development and Production
            app.UseSwagger();
            app.UseSwaggerUI();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Redirect to Swagger URL when the server starts in both Development and Production
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("swagger");
                    return;
                }

                await next();
            });

            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();

                // Optional: Add any Production specific configurations here
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            
            app.UseRouting();

            app.UseStaticFiles();
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Content")
                ),
                RequestPath = "/content"
            });
            

            //// global cors policy
            ///// UseCors must be called before UseResponseCaching

            //app.UseCors(_defaultCorsPolicyName);

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseResponseCaching();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");

            });

            string adminAppPath = Path.Combine(Directory.GetCurrentDirectory(), _clientAppAdminDist);

            if (Directory.Exists(adminAppPath))
            {
                app.UseSpaStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(adminAppPath),
                });

                app.Map("/adminapp", admin =>
                {
                    admin.UseSpa(spa =>
                    {
                        spa.Options.SourcePath = _clientAppAdminDist;
                        spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
                        {
                            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), _clientAppAdminDist))
                        };
                        spa.Options.DefaultPage = "/index.html";
                    });
                });
            }

            app.UseAuthentication();
            
            app.UseAuthorization();
            
            //generic routes
            var genericPattern = "/{SeName}";

            app.UseEndpoints(endpointRouteBuilder =>
            {
                endpointRouteBuilder.MapControllers();

                endpointRouteBuilder.MapDynamicControllerRoute<SlugRouteTransformer>(genericPattern);

                endpointRouteBuilder.MapControllerRoute(name: "Category",
                    pattern: genericPattern,
                    defaults: new { controller = "Catalog", action = "Category" });

                //endpointRouteBuilder.MapControllerRoute(name: "GenericUrl",
                //   pattern: "{genericSeName}",
                //   defaults: new { controller = "Common", action = "GenericUrl" });

                //endpointRouteBuilder.MapControllerRoute(name: "GenericUrlWithParameter",
                //    pattern: "{genericSeName}/{genericParameter}",
                //    defaults: new { controller = "Common", action = "GenericUrl" });
                
                //endpointRouteBuilder.MapControllerRoute(name: "Product",
                //    pattern: genericPattern,
                //    defaults: new { controller = "Product", action = "ProductDetails" });

                //endpointRouteBuilder.MapControllerRoute(name: "Manufacturer",
                //    pattern: genericPattern,
                //    defaults: new { controller = "Catalog", action = "Manufacturer" });

                //endpointRouteBuilder.MapControllerRoute(name: "Vendor",
                //    pattern: genericPattern,
                //    defaults: new { controller = "Catalog", action = "Vendor" });

                //endpointRouteBuilder.MapControllerRoute(name: "NewsItem",
                //    pattern: genericPattern,
                //    defaults: new { controller = "News", action = "NewsItem" });

                //endpointRouteBuilder.MapControllerRoute(name: "BlogPost",
                //    pattern: genericPattern,
                //    defaults: new { controller = "Blog", action = "BlogPost" });

                //endpointRouteBuilder.MapControllerRoute(name: "Topic",
                //    pattern: genericPattern,
                //    defaults: new { controller = "Topic", action = "TopicDetails" });

                //endpointRouteBuilder.MapControllerRoute(name: "ProductsByTag",
                //    pattern: genericPattern,
                //    defaults: new { controller = "Catalog", action = "ProductsByTag" });
            });

        }
    }
}