using Swiftrade.Core.Domain.Entities.Common;
using System.Collections.Generic;

namespace Swiftrade.Core.Application.Models
{
    public class CategorySimpleModel : BaseEntity<int>
    {
        public CategorySimpleModel()
        {
            SubCategories = new List<CategorySimpleModel>();
        }

        public string Name { get; set; }

        public string SeName { get; set; }

        public int? NumberOfProducts { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public List<CategorySimpleModel> SubCategories { get; set; }

        public bool HaveSubCategories { get; set; }

        public string Route { get; set; }
    }
}
