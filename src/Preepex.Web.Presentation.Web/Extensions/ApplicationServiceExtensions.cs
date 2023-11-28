
using Microsoft.Extensions.DependencyInjection;
using Nop.Services.Common;
using Nop.Services.Media;
using Preepex.Common.Singleton;
using Preepex.Core.Application.Configuration;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Application.Interfaces.Security;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces.Shared.Catalog;
using Preepex.Core.Application.Interfaces.Shared.Customers;
using Preepex.Core.Application.Interfaces.Shared.Shipping;
using Preepex.Core.Application.Interfaces.Shared.Tax;
using Preepex.Core.Application.Messages;
using Preepex.Infrastructure;
using Preepex.Infrastructure.DbContexts;
using Preepex.Infrastructure.Resources.Services;
using Preepex.Infrastructure.Services;
using Preepex.Infrastructure.Services.Catalog;
using Preepex.Infrastructure.Services.Customers;
using Preepex.Infrastructure.Services.Security;
using Preepex.Infrastructure.Services.Shared;
using Preepex.Infrastructure.Services.Shipping;
using Preepex.Infrastructure.Services.Stores;
using Preepex.Infrastructure.Services.Tax;
using Preepex.Infrastructure.Services.Topics;
using Preepex.Presentation.Framework.Routing;

namespace Preepex.Web.Presentation.Web.Extensions
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
                  o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
              })
              .AddSessionStateTempDataProvider();

            services.AddSingleton<IResponseCacheService, RedisResponseCacheService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IPaymentService, PaymentService>();


            //Tools
            services.AddScoped<IPasswordGeneratorService, PasswordGeneratorIdentityService>();
            services.AddScoped<ISmtpBuilder, SmtpBuilder>();


            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IEmailAccountService, EmailAccountService>();
            services.AddScoped<IEmailSender, EmailSender>();
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
            services.AddScoped<IPriceCalculationService, PriceCalculationService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITaxService, TaxService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubscribersService, SubscribersService>();

            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IGenericAttributeService, GenericAttributeService>();

            services.AddTransient<IImportantMessagesLogger, NoopImportantMessagesLogger>();
            services.AddScoped<SlugRouteTransformer>();

            var appSettings = Singleton<AppSettings>.Instance ?? new AppSettings();
            if (appSettings.Get<AzureBlobConfig>().Enabled)
                services.AddScoped<IPictureService, AzurePictureService>();
            else
                services.AddScoped<IPictureService, PictureService>();



            // services.AddScoped<IPriceFormatter, PriceFormatter>();

            return services;
        }
    }
}