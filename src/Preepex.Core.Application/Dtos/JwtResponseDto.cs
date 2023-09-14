namespace Preepex.Core.Application.Dtos
{
    public class JwtResponseDto : UserDto
    {
        public bool IsValidToken { get; set; }
        public string UserId { get; set; }
        public JwtResponseDto(bool _isValidToken = false)
        {
            IsValidToken = _isValidToken;
        }
    }
}