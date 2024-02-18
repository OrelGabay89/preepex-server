using System.Threading.Tasks;
using Preepex.Common.Results;

namespace Preepex.Core.Application.Communication
{
    public interface ISMSService
    {
        /// <summary>
        /// Sends an SMS using the system's default SMS number as 'from'
        /// </summary>
        /// <param name="to"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<Result> SendSMSAsync(string to, string body);

        /// <summary>
        /// Sends an SMS
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<Result> SendSMSAsync(string from, string to, string body);
    }
}