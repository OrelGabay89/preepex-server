
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Preepex.Core.Application;
using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Configuration;
using Preepex.Core.Application.Errors;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Configuration;
using Preepex.Core.Application.Interfaces.Factories;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces.Storage;
using Preepex.Core.Domain.Entities.Identity;
using Preepex.Core.Domain.Entities.Media;
using Preepex.Infrastructure.DbContexts;
using Preepex.Infrastructure.Factories;
using Preepex.Infrastructure.Mappings;
using Preepex.Infrastructure.Repositories;
using Preepex.Infrastructure.Services;
using Preepex.Infrastructure.Services.DbInitializer;
using Preepex.Infrastructure.Services.Shared;
using System;
using System.Linq;


namespace Preepex.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity(configuration);
            services.AddDatabasePersistence(configuration);
            services.AddAppServices();

            services.AddFactories();
            services.AddRepositories();
            services.AddAutoMapper(typeof(MappingProfiles));
        }

        public static void AddSharedServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordGeneratorService, PasswordGeneratorIdentityService>();
            services.AddScoped<IFileStorageService, FileStorageService>();
        }
        private static void AddDatabasePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("StoreDb"));
                services.AddDbContext<AppIdentityDbContext>(options =>
                    options.UseInMemoryDatabase("AppIdentityDb"));
                services.AddDbContext<PreepexContext>(options =>
                  options.UseInMemoryDatabase("PreepexDb"));
            }
            else
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

                // [CanBeNull] Action<MySqlDbContextOptionsBuilder> mySqlOptionsAction = null
                services.AddDbContext<ApplicationDbContext>(x =>
                              x.UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion,
                              new Action<MySqlDbContextOptionsBuilder>(Action => Action.EnableRetryOnFailure())));

                services.AddDbContext<AppIdentityDbContext>(x =>
                {
                    x.UseMySql(configuration.GetConnectionString("IdentityConnection"), serverVersion, new Action<MySqlDbContextOptionsBuilder>(Action => Action.EnableRetryOnFailure()));
                });
                services.AddDbContext<PreepexContext>(x =>
                {
                    x.UseMySql(configuration.GetConnectionString("PreepexConnection"), serverVersion, new Action<MySqlDbContextOptionsBuilder>(Action => Action.EnableRetryOnFailure()));
                });
            }
            services.AddScoped<IDbInitializerService, DbInitializerService>();
        }

        private static void AddFactories(this IServiceCollection services)
        {
            services.AddScoped<ICatalogModelFactory, CatalogModelFactory>();
            services.AddScoped<IProductModelFactory, ProductModelFactory>();
        }

        private static void AddAppServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IFileProvider, PreepexFileProvider>();
            services.AddScoped<IWebHelper, WebHelper>();

            services.AddSingleton<ILocker, MemoryCacheManager>();
            services.AddSingleton<IStaticCacheManager, MemoryCacheManager>();
            services.AddSingleton<ITypeFinder, TypeFinder>();
            services.AddSingleton<AppSettings>();


            var typeFinder = services
                      .BuildServiceProvider()
                      .GetRequiredService<ITypeFinder>();
            // register all settings
            var settings = typeFinder.FindClassesOfType(typeof(ISettings), false).ToList();
            foreach (var setting in settings)
            {
                services.AddSingleton(setting, serviceProvider =>
                {
                    var scope = serviceProvider.CreateScope();
                    return scope.ServiceProvider.GetRequiredService<ISettingService>().LoadSettingAsync(setting, 0).Result;
                });
            }

            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var configurations = typeFinder
               .FindClassesOfType<IConfig>()
               .Select(configType => (IConfig)Activator.CreateInstance(configType))
               .ToList();
            foreach (var config in configurations)
            {
                configuration.GetSection(config.Name).Bind(config, options => options.BindNonPublicProperties = true);
            }

            var hostEnvironment = services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();
            
            CommonHelper.DefaultFileProvider = new PreepexFileProvider(hostEnvironment);


            var appSettings = AppSettingsHelper.SaveAppSettings(configurations, CommonHelper.DefaultFileProvider, false);
            services.AddSingleton(appSettings);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
        }
        
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            services.AddScoped<IEmailAccountRepository, EmailAccountRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreContext, WebStoreContext>();
            services.AddScoped<IProductWarehouseInventoryRepository, ProductWarehouseInventoryRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IPictureRepository, PictureRepository>();
            services.AddScoped<ILocalizedPropertyRepository, LocalizedPropertyRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IProductAttributeRepository, ProductAttributeRepository>();
            services.AddScoped<IDateRangeRepository, DateRangeRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductManufacturerRepository, ProductManufacturerRepository>();
        }


        private static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.Name = "SwiftradeAuth";
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.SlidingExpiration = true;
                    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                });
                //.AddApiKey("API", options =>
                //   {
                //       options.HeaderName = "X-Api-Key";
                //       options.QueryName = "apikey";
                //});



            var builder = services.AddIdentityCore<ApplicationUser>();

            builder = new IdentityBuilder(builder.UserType, typeof(ApplicationRole), builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();
            builder.AddRoleValidator<RoleValidator<ApplicationRole>>();
            builder.AddRoleManager<RoleManager<ApplicationRole>>();

            //services.AddAuthorizationPolicies();

            
            return services;
        }

        private static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("SignalR", policy =>
                {
                    policy.AuthenticationSchemes.Add("SignalR");
                    policy.RequireAuthenticatedUser();
                });

                // Require auth on everything except those marked [AllowAnonymous]
                options.FallbackPolicy = new AuthorizationPolicyBuilder("API")
                .RequireAuthenticatedUser()
                .Build();
            });


        }



    }
}
