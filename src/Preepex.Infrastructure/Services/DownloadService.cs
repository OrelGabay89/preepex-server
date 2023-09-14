using Microsoft.AspNetCore.Http;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities.Media;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services
{
    public partial class DownloadService : IDownloadService
    {

        private readonly IGenericRepository<Download> _downloadRepository;
        private readonly IUnitOfWork _unitOfWork;


        public DownloadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        /// <summary>
        /// Gets a download
        /// </summary>
        /// <param name="downloadId">Download identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the download
        /// </returns>
        public virtual async Task<Download> GetDownloadByIdAsync(int downloadId)
        {
            return await _downloadRepository.GetByIdAsync(downloadId);
        }

        /// <summary>
        /// Gets a download by GUID
        /// </summary>
        /// <param name="downloadGuid">Download GUID</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the download
        /// </returns>
        public virtual async Task<Download> GetDownloadByGuidAsync(Guid downloadGuid)
        {
            if (downloadGuid == Guid.Empty)
                return null;

            return null;
            //var query = from o in _downloadRepository.Table
            //            where o.DownloadGuid == downloadGuid
            //            select o;

            //return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Deletes a download
        /// </summary>
        /// <param name="download">Download</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteDownloadAsync(Download download)
        {

            //await _unitOfWork.Repository<Download>().Delete(download);
        }

        /// <summary>
        /// Inserts a download
        /// </summary>
        /// <param name="download">Download</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertDownloadAsync(Download download)
        {
            //await _downloadRepository.InsertAsync(download);
        }

        /// <summary>
        /// Gets the download binary array
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the download binary array
        /// </returns>
        public virtual async Task<byte[]> GetDownloadBitsAsync(IFormFile file)
        {
            await using var fileStream = file.OpenReadStream();
            await using var ms = new MemoryStream();
            await fileStream.CopyToAsync(ms);
            var fileBytes = ms.ToArray();

            return fileBytes;
        }

    }
}