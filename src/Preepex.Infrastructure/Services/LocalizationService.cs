using Microsoft.Extensions.Localization;
using Preepex.Core.Application.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Preepex.Infrastructure.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer _localizer;

        public LocalizationService(IStringLocalizerFactory factory)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var type = Type.GetType($"PreepexResource_{currentCulture.Name}"); // typeof(PreepexResource_en);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create($"PreepexResource_{currentCulture.Name}", assemblyName.Name);
        }

        public LocalizedString this[string key] => _localizer[key];

        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }

        public LocalizedString GetCulturedLocalizedString(string key, string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            return GetLocalizedString(key);
        }

        public string GetLocalizedString(string key, params string[] parameters)
        {
            return string.Format(_localizer[key], parameters);
        }

        public IEnumerable<LocalizedString> GetAllCulturedLocalizedString()
        {
            return _localizer.GetAllStrings();
        }

    }
}