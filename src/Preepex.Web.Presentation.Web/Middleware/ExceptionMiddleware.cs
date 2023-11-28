using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Preepex.Core.Application.Errors;
using Preepex.Infrastructure.Services;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Preepex.Core.Application.Interfaces.Shared;

namespace Preepex.Web.Presentation.Web.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        //private IImportantMessagesLogger _importantMessagesLogger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
            //_importantMessagesLogger = importantMessagesLogger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //_importantMessagesLogger.PostMessage("An Exception has occured while the application was running: " + ex);
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}