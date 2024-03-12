using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swiftrade.Core.Application.Errors;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Swiftrade.Web.Presentation.Web.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                // Check if the application is in debugging mode or a specific flag is set
                if (_env.IsDevelopment() || Environment.GetEnvironmentVariable("DETAILED_ERROR_LOGGING") == "true")
                {
                    await context.Response.WriteAsync(json);
                }
                else
                {
                    // In production, return a generic error message
                    var prodError = new { error = "An error occurred. Please try again later." };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(prodError));
                }
            }
        }
    }
}