﻿
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Preepex.Common.Options;
using Preepex.Infrastructure.Extensions;
using System;

namespace Preepex.Web.Presentation.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddInfrastructureLayer(configuration, environment);

            services.AddValidatorsFromAssemblyContaining<Startup>();

        }


    }
}
