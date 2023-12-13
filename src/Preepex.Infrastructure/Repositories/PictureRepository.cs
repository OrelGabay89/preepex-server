using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Preepex.Core.Application.Dtos;
using Preepex.Core.Application.Interfaces.Configuration;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Application.Media;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Media;
using Preepex.Infrastructure.DbContexts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        #region declaration
        private readonly PreepexContext _context;
        private readonly ISettingService _settingService;
        IConfiguration _config;
        private readonly string ImagesPath;
        private readonly string _NopUrl;
        private readonly IFileProvider _fileProvider;
        private readonly MediaSettings _mediaSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region ctor
        public PictureRepository(PreepexContext context, IConfiguration config, ISettingService settingService, IFileProvider fileProvider,
            MediaSettings mediaSettings, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            ImagesPath = config["Media:ImageThumbsPath"];
            _NopUrl = config["Media:NopUrl"];
            _settingService = settingService;
            _httpContextAccessor = httpContextAccessor;
            _mediaSettings = mediaSettings;
            _fileProvider = fileProvider;
        }
        #endregion

        #region methods
        public async Task<List<ImageDto>> GetPicturesByProductIdAsync(int productId, int recordsToReturn = 0)
        {
            var result = new List<ImageDto>();
            if (productId == 0)
                return new List<ImageDto>();

            var query = from p in _context.Pictures
                        join pp in _context.ProductPictureMappings on p.Id equals pp.PictureId
                        orderby pp.DisplayOrder, pp.Id
                        where pp.ProductId == productId
                        select p;

            if (recordsToReturn > 0)
                query = query.Take(recordsToReturn);

            var pics = await query.ToListAsync();
            foreach (var picture in pics)
            {
                var image = new ImageDto
                {
                    Alt = picture.AltAttribute,
                    Id = picture.Id,
                    Image_id = picture.Id,
                    Name = picture.SeoFilename,
                };
                var url = (await GetPictureUrlAsync(picture, _mediaSettings.ProductThumbPictureSize)).Url;
                image.Src = $"{_NopUrl}{url}";
                result.Add(image);
            }

            return result;
        }
        public async Task<List<Picture>> GetPicturesEntityByProductIdAsync(int productId, int recordsToReturn = 0)
        {
            var result = new List<Picture>();
            if (productId == 0)
                return new List<Picture>();

            var query = from p in _context.Pictures
                        join pp in _context.ProductPictureMappings on p.Id equals pp.PictureId
                        orderby pp.DisplayOrder, pp.Id
                        where pp.ProductId == productId
                        select p;

            if (recordsToReturn > 0)
                query = query.Take(recordsToReturn);

            result = await query.ToListAsync();
            return result;
        }
        public Task<string> GetFileExtensionFromMimeTypeAsync(string mimeType)
        {
            if (mimeType == null)
                return Task.FromResult<string>(null);

            var parts = mimeType.Split('/');
            var lastPart = parts[^1];
            switch (lastPart)
            {
                case "pjpeg":
                    lastPart = "jpg";
                    break;
                case "x-png":
                    lastPart = "png";
                    break;
                case "x-icon":
                    lastPart = "ico";
                    break;
                default:
                    break;
            }

            return Task.FromResult(lastPart);
        }
        protected Task<string> GetThumbLocalPathAsync(string thumbFileName)
        {
            var thumbsDirectoryPath = _fileProvider.GetAbsolutePath(MediaDefaults.ImageThumbsPath);

            if (_mediaSettings.MultipleThumbDirectories)
            {
                //get the first two letters of the file name
                var fileNameWithoutExtension = _fileProvider.GetFileNameWithoutExtension(thumbFileName);
                if (fileNameWithoutExtension != null && fileNameWithoutExtension.Length > MediaDefaults.MultipleThumbDirectoriesLength)
                {
                    var subDirectoryName = fileNameWithoutExtension[0..MediaDefaults.MultipleThumbDirectoriesLength];
                    thumbsDirectoryPath = _fileProvider.GetAbsolutePath(MediaDefaults.ImageThumbsPath, subDirectoryName);
                    _fileProvider.CreateDirectory(thumbsDirectoryPath);
                }
            }

            var thumbFilePath = _fileProvider.Combine(thumbsDirectoryPath, thumbFileName);
            return Task.FromResult(thumbFilePath);
        }

        public  async Task<(string Url, Picture Picture)> GetPictureUrlAsync(Picture picture,
            int targetSize = 0,
            bool showDefaultPicture = true,
            string storeLocation = null,
            PictureType defaultPictureType = PictureType.Entity)
        {
            if (picture == null)
                return showDefaultPicture ? (await GetDefaultPictureUrlAsync(targetSize, defaultPictureType, storeLocation), null) : (string.Empty, (Picture)null);

            byte[] pictureBinary = null;


            var seoFileName = picture.SeoFilename; // = GetPictureSeName(picture.SeoFilename); //just for sure

            var lastPart = await GetFileExtensionFromMimeTypeAsync(picture.MimeType);
            string thumbFileName;
            if (targetSize == 0)
            {
                thumbFileName = !string.IsNullOrEmpty(seoFileName)
                    ? $"{picture.Id:0000000}_{seoFileName}.{lastPart}"
                    : $"{picture.Id:0000000}.{lastPart}";

                var thumbFilePath = await GetThumbLocalPathAsync(thumbFileName);
                if (await GeneratedThumbExistsAsync(thumbFilePath, thumbFileName))
                    return (await GetThumbUrlAsync(thumbFileName, storeLocation), picture);

                pictureBinary ??= await LoadPictureBinaryAsync(picture);

                SaveThumbAsync(thumbFilePath, thumbFileName, string.Empty, pictureBinary).Wait();

            }
            else
            {
                thumbFileName = !string.IsNullOrEmpty(seoFileName)
                    ? $"{picture.Id:0000000}_{seoFileName}_{targetSize}.{lastPart}"
                    : $"{picture.Id:0000000}_{targetSize}.{lastPart}";

                var thumbFilePath = await GetThumbLocalPathAsync(thumbFileName);
                if (await GeneratedThumbExistsAsync(thumbFilePath, thumbFileName))
                    return (await GetThumbUrlAsync(thumbFileName, storeLocation), picture);

                pictureBinary ??= await LoadPictureBinaryAsync(picture);
            }

            return (await GetThumbUrlAsync(thumbFileName, storeLocation), picture);
        }

        public  async Task<string> GetDefaultPictureUrlAsync(int targetSize = 0,
            PictureType defaultPictureType = PictureType.Entity,
            string storeLocation = null)
        {
            var defaultImageFileName = defaultPictureType switch
            {
                PictureType.Avatar => await _settingService.GetSettingByKeyAsync("Media.Customer.DefaultAvatarImageName", MediaDefaults.DefaultAvatarFileName),
                _ => await _settingService.GetSettingByKeyAsync("Media.DefaultImageName", MediaDefaults.DefaultImageFileName),
            };
            var filePath = await GetPictureLocalPathAsync(defaultImageFileName);
            if (!_fileProvider.FileExists(filePath))
            {
                return string.Empty;
            }

            if (targetSize == 0)
                return await GetImagesPathUrlAsync(storeLocation) + defaultImageFileName;

            var fileExtension = _fileProvider.GetFileExtension(filePath);
            var thumbFileName = $"{_fileProvider.GetFileNameWithoutExtension(filePath)}_{targetSize}{fileExtension}";
            var thumbFilePath = await GetThumbLocalPathAsync(thumbFileName);

            if (!await GeneratedThumbExistsAsync(thumbFilePath, thumbFileName))
            {
                //the named mutex helps to avoid creating the same files in different threads,
                //and does not decrease performance significantly, because the code is blocked only for the specific file.
                //you should be very careful, mutexes cannot be used in with the await operation
                //we can't use semaphore here, because it produces PlatformNotSupportedException exception on UNIX based systems
                using var mutex = new Mutex(false, thumbFileName);
                mutex.WaitOne();
                try
                {
                    using var image = SKBitmap.Decode(filePath);
                    var codec = SKCodec.Create(filePath);
                    var format = codec.EncodedFormat;
                    var pictureBinary = ImageResize(image, format, targetSize);
                    var mimeType = GetMimeTypeFromFileName(thumbFileName);
                    SaveThumbAsync(thumbFilePath, thumbFileName, mimeType, pictureBinary).Wait();
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            
            return await GetThumbUrlAsync(thumbFileName, storeLocation);
        }


        /// <summary>
        /// Gets the MIME type from the file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected virtual string GetMimeTypeFromFileName(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        /// <summary>
        /// Resize image by targetSize
        /// </summary>
        /// <param name="image">Source image</param>
        /// <param name="format">Destination format</param>
        /// <param name="targetSize">Target size</param>
        /// <returns>Image as array of byte[]</returns>
        protected virtual byte[] ImageResize(SKBitmap image, SKEncodedImageFormat format, int targetSize)
        {
            if (image == null)
                throw new ArgumentNullException("Image is null");

            float width, height;
            if (image.Height > image.Width)
            {
                // portrait
                width = image.Width * (targetSize / (float)image.Height);
                height = targetSize;
            }
            else
            {
                // landscape or square
                width = targetSize;
                height = image.Height * (targetSize / (float)image.Width);
            }

            if ((int)width == 0 || (int)height == 0)
            {
                width = image.Width;
                height = image.Height;
            }
            try
            {
                using var resizedBitmap = image.Resize(new SKImageInfo((int)width, (int)height), SKFilterQuality.Medium);
                using var cropImage = SKImage.FromBitmap(resizedBitmap);

                //In order to exclude saving pictures in low quality at the time of installation, we will set the value of this parameter to 80 (as by default)
                return cropImage.Encode(format, _mediaSettings.DefaultImageQuality > 0 ? _mediaSettings.DefaultImageQuality : 80).ToArray();
            }
            catch
            {
                return image.Bytes;
            }

        }        

        protected  Task<string> GetPictureLocalPathAsync(string fileName)
        {
            return Task.FromResult(_fileProvider.GetAbsolutePath("images", fileName));
        }
        protected  Task<string> GetImagesPathUrlAsync(string storeLocation = null)
        {
            var pathBase = _httpContextAccessor.HttpContext.Request.PathBase.Value ?? string.Empty;
            var imagesPathUrl = _mediaSettings.UseAbsoluteImagePath ? storeLocation : $"{pathBase}/";
            imagesPathUrl += "images/";

            return Task.FromResult(imagesPathUrl);
        }
        protected  Task<bool> GeneratedThumbExistsAsync(string thumbFilePath, string thumbFileName)
        {
            return Task.FromResult(_fileProvider.FileExists(thumbFilePath));
        }
        protected  async Task<string> GetThumbUrlAsync(string thumbFileName, string storeLocation = null)
        {
            var url = await GetImagesPathUrlAsync(storeLocation) + "thumbs/";

            if (_mediaSettings.MultipleThumbDirectories)
            {
                //get the first two letters of the file name
                var fileNameWithoutExtension = _fileProvider.GetFileNameWithoutExtension(thumbFileName);
                if (fileNameWithoutExtension != null && fileNameWithoutExtension.Length > MediaDefaults.MultipleThumbDirectoriesLength)
                {
                    var subDirectoryName = fileNameWithoutExtension[0..MediaDefaults.MultipleThumbDirectoriesLength];
                    url = url + subDirectoryName + "/";
                }
            }

            url += thumbFileName;
            return url;
        }
        protected  async Task<byte[]> LoadPictureBinaryAsync(Picture picture, bool fromDb)
        {
            if (picture == null)
                throw new ArgumentNullException(nameof(picture));

            var result = fromDb
                ? (await GetPictureBinaryByPictureIdAsync(picture.Id))?.BinaryData ?? Array.Empty<byte>()
                : await LoadPictureFromFileAsync(picture.Id, picture.MimeType);

            return result;
        }
        public  async Task<Picturebinary> GetPictureBinaryByPictureIdAsync(int pictureId)
        {
            return await _context.Picturebinaries
                .FirstOrDefaultAsync(pb => pb.PictureId == pictureId);
        }
        protected  async Task<byte[]> LoadPictureFromFileAsync(int pictureId, string mimeType)
        {
            var lastPart = await GetFileExtensionFromMimeTypeAsync(mimeType);
            var fileName = $"{pictureId:0000000}_0.{lastPart}";
            var filePath = await GetPictureLocalPathAsync(fileName);

            return await _fileProvider.ReadAllBytesAsync(filePath);
        }
        public  async Task<byte[]> LoadPictureBinaryAsync(Picture picture)
        {
            return await LoadPictureBinaryAsync(picture, await IsStoreInDbAsync());
        }
        public  async Task<bool> IsStoreInDbAsync()
        {
            return await _settingService.GetSettingByKeyAsync("Media.Images.StoreInDB", true);
        }
        protected  async Task SaveThumbAsync(string thumbFilePath, string thumbFileName, string mimeType, byte[] binary)
        {
            //ensure \thumb directory exists
            var thumbsDirectoryPath = _fileProvider.GetAbsolutePath(MediaDefaults.ImageThumbsPath);
            _fileProvider.CreateDirectory(thumbsDirectoryPath);

            //save
            await _fileProvider.WriteAllBytesAsync(thumbFilePath, binary);
        }
        public async Task<Picture> GetByIdAsync(int? pictureId)
        {
            return await _context.Pictures.FirstOrDefaultAsync(x => x.Id == pictureId);
        }
        public IQueryable<ProductPictureMapping> GetTable()
        {
            return _context.ProductPictureMappings.AsQueryable();
        }
        public IQueryable<Picture> Table()
        {
            return _context.Pictures.AsQueryable();
        }
        #endregion
    }
}
