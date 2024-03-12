using Swiftrade.Core.Application.Dtos;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.Entities.Media;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Swiftrade.Core.Application.Interfaces.Repositories.Domain
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
