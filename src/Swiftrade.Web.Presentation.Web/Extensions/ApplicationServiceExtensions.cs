
using Microsoft.Extensions.DependencyInjection;
using Preepex.Infrastructure.Resources.Services;
using Swiftrade.Common.Singleton;
using Swiftrade.Core.Application.Configuration;
using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Application.Interfaces.Security;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Application.Interfaces.Shared.Catalog;
using Swiftrade.Core.Application.Interfaces.Shared.Customers;
using Swiftrade.Core.Application.Interfaces.Shared.Shipping;
using Swiftrade.Core.Application.Interfaces.Shared.Tax;
using Swiftrade.Core.Application.Messages;
using Swiftrade.Core.Application.Routing;
using Swiftrade.Infrastructure;
using Swiftrade.Infrastructure.DbContexts;
using Swiftrade.Infrastructure.Resources.Services;
using Swiftrade.Infrastructure.Services;
using Swiftrade.Infrastructure.Services.Catalog;
using Swiftrade.Infrastructure.Services.Customers;
using Swiftrade.Infrastructure.Services.Security;
using Swiftrade.Infrastructure.Services.Shared;
using Swiftrade.Infrastructure.Services.Shipping;
using Swiftrade.Infrastructure.Services.Stores;
using Swiftrade.Infrastructure.Services.Tax;
using Swiftrade.Infrastructure.Services.Topics;

namespace Swiftrade.Web.Presentation.Web.Extensions
{
    public static class ApplicationServicesExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services
              .AddMvc(options =>
              {
                  options.EnableEndpointRouting = false;

              })
              
              .AddNewtonsoftJson(o =>
              {
                  //o.SerializerSettings.ContractResolver = new DefaultContractResolver();
                  o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
              })
              .AddSessionStateTempDataProvider();

            services.AddSingleton<IResponseCacheService, RedisResponseCacheService>();

            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IEmailAccountService, EmailAccountService>();
            services.AddScoped<ISmtpBuilder, SmtpBuilder>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IDownloadService, DownloadService>();
            services.AddScoped<IPasswordGeneratorService, PasswordGeneratorIdentityService>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddScoped<IStoreMappingService, StoreMappingService>();
            services.AddScoped<IStoreService, StoreService>();
    
            services.AddScoped<IAclService, AclService>();
            services.AddScoped<ILocalizedEntityService, LocalizedEntityService>();
            services.AddScoped<ISpecificationAttributeService, SpecificationAttributeService>();
            services.AddScoped<IUrlRecordService, UrlRecordService>();
            services.AddScoped<IPriceCalculationService, PriceCalculationService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IOrderReportService, OrderReportService>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTagService,ProductTagService>();
            services.AddScoped<IProductAttributeService, ProductAttributeService>();
            services.AddScoped<IDateRangeService, DateRangeService>();
            services.AddScoped<IPriceCalculationService, PriceCalculationService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITaxService, TaxService>();
            services.AddScoped<IWorkContext, WebWorkContext>();
            services.AddScoped<IPriceFormatter, PriceFormatter>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ISubscribersService, SubscribersService>();

            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IGenericAttributeService, GenericAttributeService>();

            services.AddScoped<SlugRouteTransformer>();

            var appSettings = Singleton<AppSettings>.Instance ?? new AppSettings();
            if (appSettings.Get<AzureBlobConfig>().Enabled)
                services.AddScoped<IPictureService, AzurePictureService>();
            else
                services.AddScoped<IPictureService, PictureService>();

            services
             .AddSignalR();

            return services;
        }
    }
}