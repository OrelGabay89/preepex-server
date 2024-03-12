using Swiftrade.Core.Application.Models;
using System.Collections.Generic;

namespace Swiftrade.Core.Application.Dtos
{
    public class TopMenuDto
    {
        public IList<CategorySimpleModel> Categories { get; set; }
    }
}
