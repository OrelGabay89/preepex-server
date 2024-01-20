
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

            services.AddAuthorizationPolicies();
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