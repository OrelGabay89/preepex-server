using Microsoft.AspNetCore.Http;
using System;

namespace Preepex.Core.Application.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string GetSubDomain(this HttpRequest request)
        {
            string result = new Uri(request.Headers["Referer"]).GetSubDomain();
            return result;
        }
    }
}
