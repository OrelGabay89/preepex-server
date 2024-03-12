using Swiftrade.Common.Paging;

namespace Swiftrade.Core.Application.Request
{
    public class ProductSearchRequest : PaginationRequest
    {
        public int? Category { get; set; }
        public int? Brand { get; set; }
        public int? Color { get; set; }
        public int? Size { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }

    }
}
