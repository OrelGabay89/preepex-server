using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Enumerations;

namespace Preepex.Core.Application.Extenstions
{
    public static class ProductAttributeExtensions
    {
        public static bool ShouldHaveValues(this ProductProductattributeMapping productAttributeMapping)
        {
            if (productAttributeMapping == null)
                return false;

            if (productAttributeMapping.AttributeControlTypeId ==(int)AttributeControlTypeEnum.TextBox ||
                productAttributeMapping.AttributeControlTypeId == (int)AttributeControlTypeEnum.MultilineTextbox ||
                productAttributeMapping.AttributeControlTypeId == (int)AttributeControlTypeEnum.Datepicker ||
                productAttributeMapping.AttributeControlTypeId == (int)AttributeControlTypeEnum.FileUpload)
                return false;

            //other attribute control types support values
            return true;
        }
    }
}
