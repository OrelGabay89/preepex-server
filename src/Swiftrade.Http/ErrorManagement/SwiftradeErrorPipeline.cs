using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NLog;
using Preepex.Common.Serializer.System.Text.Json;
using Swiftrade.Http.Exceptions;

namespace Swiftrade.Http.ErrorManagement
{
    public class SwiftradeErrorPipeline
    {
        private readonly Logger _logger;

        public SwiftradeErrorPipeline(Logger logger)
        {
            _logger = logger;
        }

        public async Task HandleException(HttpContext context)
        {
            _logger.Trace("Handling Exception");

            var response = context.Response;
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            var statusCode = HttpStatusCode.InternalServerError;
            var errorModel = new ErrorModel
            {
                Message = exception?.Message,
                Description = exception?.ToString()
            };

            if (exception is ApiException apiException)
            {
                _logger.Warn(apiException, "API Error:\n{0}", apiException.Message);

                errorModel = new ErrorModel(apiException);
                statusCode = apiException.StatusCode;
            }
            else if (exception is ValidationException validationException)
            {
                _logger.Warn("Invalid request {0}", validationException.Message);

                response.StatusCode = (int)HttpStatusCode.BadRequest;


                response.ContentType = "application/json";
                await response.WriteAsync(STJson.ToJson(validationException.Errors));
                return;
            }
            //else if (exception is ModelNotFoundException)
            //{
            //    statusCode = HttpStatusCode.NotFound;
            //}


            else
            {
                _logger.Fatal(exception, "Request Failed. {0} {1}", context.Request.Method, context.Request.Path);
            }

            await errorModel.WriteToResponse(response, statusCode);
        }
    }
}
