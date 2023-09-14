using Preepex.Core.Application.Dtos;
using Preepex.Core.Domain.Entities.Identity;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared
{
    public interface ITokenService
    {
        Task<string> CreateToken(ApplicationUser user);

        Task<JwtResponseDto> ValidateToken(string token);
    }
}