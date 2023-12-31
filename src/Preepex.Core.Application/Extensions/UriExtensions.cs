﻿using Preepex.Common.Extensions;
using Preepex.Core.Domain.Consts;
using System;
using System.Linq;

namespace Preepex.Core.Application.Extensions
{
    public static class UriExtensions
    {
        public static string GetSubDomain(this Uri url)
        {
            var parts = url.Host.Split('.').ToList();

            if (parts.Any())
            {
                if (!parts.First().Equals(AppConsts.Host))
                {
                    return parts.First();
                }
            }

            return null;
        }
    }
}
