namespace Swiftrade.Core.Application.Models
{
    /// <summary>
    /// Represents an email account model
    /// </summary>
    public record EmailAccountModel : BaseNopEntityModel
    {
        #region Properties

        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool EnableSsl { get; set; }

        public bool UseDefaultCredentials { get; set; }

        public bool IsDefaultEmailAccount { get; set; }

        public string SendTestEmailTo { get; set; }

        #endregion
    }
}
