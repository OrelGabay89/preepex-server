
using Microsoft.Extensions.DependencyInjection;
using Preepex.Core.Application.Mappings.Resolvers;

namespace Preepex.Core.Application.Extenstions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<PhoneNumberToStringConverter>();
            services.AddScoped<StringToPhoneNumberConverter>();

            //services.AddAutoMapper(config =>
            //{
            //    config.ConstructServicesUsing(t => services.BuildServiceProvider().GetRequiredService(t));
            //    config.AddProfile<MappingProfiles>();
            //});

            services.AddAuthorizationCore();
            services.AddAuthorizationPolicies();
        }

        private static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            //services.AddSingleton<IAuthorizationPolicyProvider, CustomAuthorizationPolicyProvider>();
            //services.AddScoped<IAuthorizationHandler, UserOperationAuthorizationHandler>();
        }
    }
}