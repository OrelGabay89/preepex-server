﻿using Microsoft.AspNetCore.Http;
using Preepex.Core.Application.Extenstions;
using System;

namespace Preepex.Presentation.Framework.Extensions
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
