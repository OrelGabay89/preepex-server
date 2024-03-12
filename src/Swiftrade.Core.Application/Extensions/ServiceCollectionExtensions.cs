
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Swiftrade.Core.Application.Mappings.Resolvers;

namespace Swiftrade.Core.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<PhoneNumberToStringConverter>();
            services.AddScoped<StringToPhoneNumberConverter>();


        }

       
    }
}