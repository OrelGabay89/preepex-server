using Preepex.Core.Application.Models;
using System.Collections.Generic;

namespace Preepex.Core.Application.Dtos
{
    public class TopMenuDto
    {
        public IList<CategorySimpleModel> Categories { get; set; }
    }
}
