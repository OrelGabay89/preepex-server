namespace Preepex.Core.Application.Dtos
{
    public class UrlrecordDto
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string Slug { get; set; }
        public int EntityId { get; set; }
        public bool IsActive { get; set; }
        public int LanguageId { get; set; }
    }
}
