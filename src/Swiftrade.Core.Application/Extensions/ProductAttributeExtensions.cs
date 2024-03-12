using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.Enumerations;

namespace Swiftrade.Core.Application.Extensions
{
    public static class ProductAttributeExtensions
    {
        public static bool ShouldHaveValues(this ProductProductattributeMapping productAttributeMapping)
        {
            if (productAttributeMapping == null)
                return false;

            if (productAttributeMapping.AttributeControlTypeId == (int)AttributeControlTypeEnum.TextBox ||
                productAttributeMapping.AttributeControlTypeId == (int)AttributeControlTypeEnum.MultilineTextbox ||
                productAttributeMapping.AttributeControlTypeId == (int)AttributeControlTypeEnum.Datepicker ||
                productAttributeMapping.AttributeControlTypeId == (int)AttributeControlTypeEnum.FileUpload)
                return false;

            //other attribute control types support values
            return true;
        }
    }
}
