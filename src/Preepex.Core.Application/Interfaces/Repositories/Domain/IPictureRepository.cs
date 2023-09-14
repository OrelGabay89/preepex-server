using Preepex.Core.Application.Dtos;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Media;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Preepex.Core.Application.Interfaces.Repositories.Domain
{
    public interface IPictureRepository
    {
        IQueryable<Picture> Table();
        Task<Picture> GetByIdAsync(int? pictureId);
        IQueryable<ProductPictureMapping> GetTable();
        Task<List<ImageDto>> GetPicturesByProductIdAsync(int productId, int recordsToReturn = 0);
        Task<List<Picture>> GetPicturesEntityByProductIdAsync(int productId, int recordsToReturn = 0);
        Task<string> GetFileExtensionFromMimeTypeAsync(string mimeType);
        Task<(string Url, Picture Picture)> GetPictureUrlAsync(Picture picture,
            int targetSize = 0,
            bool showDefaultPicture = true,
            string storeLocation = null,
            PictureType defaultPictureType = PictureType.Entity);
    }
}
