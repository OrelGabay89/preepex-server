using Swiftrade.Common.Enumerations;
using System.Collections.Generic;

namespace Swiftrade.Core.Application.Interfaces.Shared
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        public string Username { get; }
        public string Name { get; }
        public IEnumerable<RolesEnum> Roles { get; }
    }
}
