

using Microsoft.AspNetCore.Authentication.Cookies;
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
using Microsoft.Extensions.Hosting;
using Preepex.Common.Options;
using Preepex.Core.Application;
using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Communication;
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
using Preepex.Infrastructure.Options;
using Preepex.Infrastructure.Repositories;
using Preepex.Infrastructure.Services;
using Preepex.Infrastructure.Services.Communication;
using Preepex.Infrastructure.Services.DbInitializer;
using Preepex.Infrastructure.Services.Shared;
using StackExchange.Redis;
using System;
using System.Linq;


namespace Preepex.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDatabasePersistence(configuration);
            services.AddIdentity(configuration, environment);
            services.AddRepositories();

            services.AddRedisConfiguration(configuration, environment);
            services.AddAppServices();
            services.AddSharedServices();

            services.AddCommunicationServices(configuration);

            services.AddFactories();
            services.AddAutoMapper(typeof(MappingProfiles));
        }
        public static void AddSharedServices(this IServiceCollection services)
        {
            //services.AddScoped<IApplicationConfigurationService, ApplicationConfigurationService>();
            services.AddScoped<IPasswordGeneratorService, PasswordGeneratorIdentityService>();
        }

        private static void AddStorageServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStorageOptions(configuration);
            services.AddScoped<IFileStorageService, FileStorageService>();
        }

        private static EmailSenderOptions GetEmailSenderOptions(IConfiguration configuration)
        {
            EmailSenderOptions emailSenderOptions = new EmailSenderOptions();
            configuration.GetSection("EmailSender").Bind(emailSenderOptions);

            return emailSenderOptions;
        }

        private static void AddCommunicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var emailSenderOptions = GetEmailSenderOptions(configuration);
            if (emailSenderOptions.UseSendGrid)
            {
                services.AddScoped<IEmailService, EmailSendGridService>();
            }
            else
            {
                services.AddScoped<IEmailService, EmailSMTPService>();
            }

            services.AddScoped<ISMSService, SMSService>();
        }
        private static void AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            string redisConnectionString;

            // Check if the application is running in development mode
            if (environment.IsDevelopment())
            {
                // In development, get the Redis connection string from appsettings.json
                redisConnectionString = configuration.GetConnectionString("RedisCloudURL");
            }
            else
            {
                var envVaribaleRedisUrl = Environment.GetEnvironmentVariable("REDISCLOUD_URL");
                if (!string.IsNullOrEmpty(envVaribaleRedisUrl))
                {
                    // Parse the Heroku Redis URL
                    var uri = new Uri(envVaribaleRedisUrl);
                    var password = uri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                    redisConnectionString = $"{uri.Host}:{uri.Port},password={password},abortConnect=False";
                }
                else
                {
                    redisConnectionString = configuration.GetConnectionString("RedisCloudURL");
                }
            }

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configOptions = ConfigurationOptions.Parse(redisConnectionString, true);
                return ConnectionMultiplexer.Connect(configOptions);
            });
        }
        private static void AddDatabasePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("AppSettings:UseInMemoryDatabase"))
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
            services.AddSingleton<Microsoft.AspNetCore.Authentication.ISystemClock, Microsoft.AspNetCore.Authentication.SystemClock>();
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

        private static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                // Common configuration for all environments
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.Name = "SwiftradeAuth";
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;

                // Environment-specific configuration
                if (environment.IsDevelopment())
                {
                    options.Cookie.SameSite = SameSiteMode.Lax;
                }
                else
                {
                    // In production, use a more restrictive setting
                    options.Cookie.SameSite = SameSiteMode.Strict;
                }
            });

            var builder = services.AddIdentityCore<ApplicationUser>();

            builder = new IdentityBuilder(builder.UserType, typeof(ApplicationRole), builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();
            builder.AddRoleValidator<RoleValidator<ApplicationRole>>();
            builder.AddRoleManager<RoleManager<ApplicationRole>>();

            //.AddApiKey("API", options =>
            //   {
            //       options.HeaderName = "X-Api-Key";
            //       options.QueryName = "apikey";
            //});
            //services.AddAuthorizationPolicies();


            return services;
        }

        private static void AddStorageOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileStorageOptions>(x => configuration.GetSection("Storage").Bind(x));
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
