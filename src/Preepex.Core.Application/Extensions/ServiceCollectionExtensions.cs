
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Preepex.Core.Application.Mappings.Resolvers;

namespace Preepex.Core.Application.Extensions
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