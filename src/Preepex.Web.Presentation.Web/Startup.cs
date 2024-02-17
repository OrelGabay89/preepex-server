using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Preepex.Common.EnvironmentInfo;
using Preepex.Common.Serializer.System.Text.Json;
using Preepex.Core.Application.Extensions;
using Preepex.Core.Application.Routing;
using Preepex.Web.Presentation.Web.Extensions;
using Preepex.Web.Presentation.Web.Middleware;
using StackExchange.Redis;
using Swiftrade.SignalR;
using System.IO;

namespace Preepex.Web.Presentation.Web
{
    public class Startup
    {

        private const string _defaultCorsPolicyName = "CorsPolicy";
        private const string _clientAppAdminDist = "wwwroot/adminapp";
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddInfrastructure(Configuration, Environment); // Adjusted to pass both parameters

            //////ROUTING
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddResponseCompression(options => options.EnableForHttps = true);

            //////LOCALIZATION
            services.AddLocalization(options => options.ResourcesPath = "");

            ////CACHING
            services.AddResponseCaching();

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

       

            //In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = _clientAppAdminDist;
            });


            services.AddSwaggerDocumentation();
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("Default30",
                 new CacheProfile()
                 {
                     Duration = 30,
                 });
                
                options.EnableEndpointRouting = false;
                options.ReturnHttpNotAcceptable = true;
           
            })
           .AddJsonOptions(options =>
            {
                STJson.ApplySerializerSettings(options.JsonSerializerOptions);
            });

            services
           .AddSignalR()
           .AddJsonProtocol(options =>
           {
               options.PayloadSerializerOptions = STJson.GetSerializerSettings();
           });
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
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<VersionMiddleware>();

            app.UseWebSockets();
            
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            
            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.Properties["host.AppName"] = BuildInfo.AppName;

            app.UseStaticFiles();
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Content")
                ),
                RequestPath = "/content"
            });

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None
            });

            //// global cors policy
            ///// UseCors must be called before UseResponseCaching

            //app.UseCors(_defaultCorsPolicyName);

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseRouting();

            app.UseResponseCaching();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            // Configure the SPA for adminapp
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
            //generic routes
            var genericPattern = "/{SeName}";

            app.UseEndpoints(endpointRouteBuilder =>
            {
                endpointRouteBuilder.MapHub<MessageHub>("/signalr/messages").RequireAuthorization("SignalR");
                
                endpointRouteBuilder.MapControllers();

                endpointRouteBuilder.MapDynamicControllerRoute<SlugRouteTransformer>(genericPattern);

                endpointRouteBuilder.MapControllerRoute(name: "Category",
                    pattern: genericPattern,
                    defaults: new { controller = "Catalog", action = "Category" });
            });

        }
    }
}