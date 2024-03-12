using System.Collections.Generic;

namespace Swiftrade.Core.Application.Models
{
    public class ProductTagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SeName { get; set; }

        public int ProductCount { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
