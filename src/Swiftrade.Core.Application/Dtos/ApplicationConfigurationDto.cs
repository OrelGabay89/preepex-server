namespace CH.CleanArchitecture.Core.Application.Dtos
{
    public class ApplicationConfigurationDto
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool IsEncrypted { get; set; }
    }
}
