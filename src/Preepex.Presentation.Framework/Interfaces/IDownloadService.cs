﻿using Microsoft.AspNetCore.Http;
using Preepex.Core.Domain.Entities.Media;
using System;
using System.Threading.Tasks;

namespace Preepex.Presentation.Framework.Interfaces
{
    public partial interface IDownloadService
    {
        /// <summary>
        /// Gets a download
        /// </summary>
        /// <param name="downloadId">Download identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the download
        /// </returns>
        Task<Download> GetDownloadByIdAsync(int downloadId);

        /// <summary>
        /// Gets a download by GUID
        /// </summary>
        /// <param name="downloadGuid">Download GUID</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the download
        /// </returns>
        Task<Download> GetDownloadByGuidAsync(Guid downloadGuid);

        /// <summary>
        /// Deletes a download
        /// </summary>
        /// <param name="download">Download</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteDownloadAsync(Download download);

        /// <summary>
        /// Inserts a download
        /// </summary>
        /// <param name="download">Download</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertDownloadAsync(Download download);

        /// <summary>
        /// Gets the download binary array
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the download binary array
        /// </returns>
        Task<byte[]> GetDownloadBitsAsync(IFormFile file);
    }
}