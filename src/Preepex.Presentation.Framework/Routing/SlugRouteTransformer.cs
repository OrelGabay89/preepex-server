using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;
using Preepex.Core.Application.Events;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Localization;
using Preepex.Presentation.Framework.Events;

namespace Preepex.Presentation.Framework.Routing
{
    public class SlugRouteTransformer : DynamicRouteValueTransformer
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly ILanguageService _languageService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly LocalizationSettings _localizationSettings;

        #endregion

        #region Ctor

        public SlugRouteTransformer(/*IEventPublisher eventPublisher*/
            ILanguageService languageService,
            IUrlRecordService urlRecordService,
            LocalizationSettings localizationSettings)
        {
            //_eventPublisher = eventPublisher;
            _languageService = languageService;
            _urlRecordService = urlRecordService;
            _localizationSettings = localizationSettings;
        }

        #endregion

        #region Methods

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            if (values == null)
                return values;

            if (!values.TryGetValue("SeName", out var slugValue) || string.IsNullOrEmpty(slugValue as string))
                return values;

            var slug = slugValue as string;
            var urlRecord = await _urlRecordService.GetBySlugAsync(slug);

            //no URL record found
            if (urlRecord == null)
                return values;

            //virtual directory path
            var pathBase = httpContext.Request.PathBase;

            //if URL record is not active let's find the latest one
            if (!urlRecord.IsActive)
            {
                var activeSlug = await _urlRecordService.GetActiveSlugAsync(urlRecord.EntityId, urlRecord.EntityName, urlRecord.LanguageId);
                if (string.IsNullOrEmpty(activeSlug))
                    return values;

                //redirect to active slug if found
                values[PreepexPathRouteDefaults.ControllerFieldKey] = "Common";
                values[PreepexPathRouteDefaults.ActionFieldKey] = "InternalRedirect";
                values[PreepexPathRouteDefaults.UrlFieldKey] = $"{pathBase}/{activeSlug}{httpContext.Request.QueryString}";
                values[PreepexPathRouteDefaults.PermanentRedirectFieldKey] = true;
                httpContext.Items["nop.RedirectFromGenericPathRoute"] = true;

                return values;
            }

            //Ensure that the slug is the same for the current language, 
            //otherwise it can cause some issues when customers choose a new language but a slug stays the same
            if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
            {
                var urllanguage = values["language"];
                if (urllanguage != null && !string.IsNullOrEmpty(urllanguage.ToString()))
                {
                    var languages = await _languageService.GetAllLanguagesAsync();
                    var language = languages.FirstOrDefault(x => x.UniqueSeoCode.ToLowerInvariant() == urllanguage.ToString().ToLowerInvariant())
                        ?? languages.FirstOrDefault();

                    var slugForCurrentLanguage = await _urlRecordService.GetActiveSlugAsync(urlRecord.EntityId, urlRecord.EntityName, language.Id);
                    if (!string.IsNullOrEmpty(slugForCurrentLanguage) && !slugForCurrentLanguage.Equals(slug, StringComparison.InvariantCultureIgnoreCase))
                    {
                        //we should make validation above because some entities does not have SeName for standard (Id = 0) language (e.g. news, blog posts)

                        //redirect to the page for current language
                        values[PreepexPathRouteDefaults.ControllerFieldKey] = "Common";
                        values[PreepexPathRouteDefaults.ActionFieldKey] = "InternalRedirect";
                        values[PreepexPathRouteDefaults.UrlFieldKey] = $"{pathBase}/{language.UniqueSeoCode}/{slugForCurrentLanguage}{httpContext.Request.QueryString}";
                        values[PreepexPathRouteDefaults.PermanentRedirectFieldKey] = false;
                        httpContext.Items["nop.RedirectFromGenericPathRoute"] = true;

                        return values;
                    }
                }
            }

            //since we are here, all is ok with the slug, so process URL
            switch (urlRecord.EntityName.ToLowerInvariant())
            {
                case "product":
                    values[PreepexPathRouteDefaults.ControllerFieldKey] = "Product";
                    values[PreepexPathRouteDefaults.ActionFieldKey] = "ProductDetails";
                    values[PreepexPathRouteDefaults.ProductIdFieldKey] = urlRecord.EntityId;
                    values[PreepexPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "producttag":
                    values[PreepexPathRouteDefaults.ControllerFieldKey] = "Catalog";
                    values[PreepexPathRouteDefaults.ActionFieldKey] = "ProductsByTag";
                    values[PreepexPathRouteDefaults.ProducttagIdFieldKey] = urlRecord.EntityId;
                    values[PreepexPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "category":
                    values[PreepexPathRouteDefaults.ControllerFieldKey] = "Catalog";
                    values[PreepexPathRouteDefaults.ActionFieldKey] = "Category";
                    values[PreepexPathRouteDefaults.CategoryIdFieldKey] = urlRecord.EntityId;
                    values[PreepexPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "manufacturer":
                    values[PreepexPathRouteDefaults.ControllerFieldKey] = "Catalog";
                    values[PreepexPathRouteDefaults.ActionFieldKey] = "Manufacturer";
                    values[PreepexPathRouteDefaults.ManufacturerIdFieldKey] = urlRecord.EntityId;
                    values[PreepexPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "vendor":
                    values[PreepexPathRouteDefaults.ControllerFieldKey] = "Catalog";
                    values[PreepexPathRouteDefaults.ActionFieldKey] = "Vendor";
                    values[PreepexPathRouteDefaults.VendorIdFieldKey] = urlRecord.EntityId;
                    values[PreepexPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "newsitem":
                    values[PreepexPathRouteDefaults.ControllerFieldKey] = "News";
                    values[PreepexPathRouteDefaults.ActionFieldKey] = "NewsItem";
                    values[PreepexPathRouteDefaults.NewsItemIdFieldKey] = urlRecord.EntityId;
                    values[PreepexPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "blogpost":
                    values[PreepexPathRouteDefaults.ControllerFieldKey] = "Blog";
                    values[PreepexPathRouteDefaults.ActionFieldKey] = "BlogPost";
                    values[PreepexPathRouteDefaults.BlogPostIdFieldKey] = urlRecord.EntityId;
                    values[PreepexPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "topic":
                    values[PreepexPathRouteDefaults.ControllerFieldKey] = "Topic";
                    values[PreepexPathRouteDefaults.ActionFieldKey] = "TopicDetails";
                    values[PreepexPathRouteDefaults.TopicIdFieldKey] = urlRecord.EntityId;
                    values[PreepexPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                default:
                    //no record found, thus generate an event this way developers could insert their own types
                    //await _eventPublisher.PublishAsync(new GenericRoutingEvent(values, urlRecord));
                    break;
            }

            return values;
        }

        #endregion
    }
}