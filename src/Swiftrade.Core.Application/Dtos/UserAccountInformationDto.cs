namespace Swiftrade.Core.Application.Dtos
{
    public class UserAccountInformationDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DisplayName { get; set; }

        public AddressDto AddressDto { get; set; }

        public string NewEmail { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }

        public bool IsEmailChange { get; set; }
        public bool IsPasswordChange { get; set; }

    }
}