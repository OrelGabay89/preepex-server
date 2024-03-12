using Swiftrade.Core.Domain.Entities.Common;

namespace Swiftrade.Core.Domain.Entities.ApplicationEntities
{
    public class Photo : BaseEntity<int>
    {
        public string PictureUrl { get; set; }
        public string FileName { get; set; }
        public bool IsMain { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}