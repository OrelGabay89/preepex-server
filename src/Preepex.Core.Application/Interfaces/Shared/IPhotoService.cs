using Microsoft.AspNetCore.Http;
using Preepex.Core.Domain.Entities.ApplicationEntities;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared
{
    public interface IPhotoService
    {
        Task<Photo> SaveToDiskAsync(IFormFile photo);
        void DeleteFromDisk(Photo photo);
    }
}