using Swiftrade.Common;
using Swiftrade.Common.Results;
using Swiftrade.Core.Application.Communication;
using System;
using System.Threading.Tasks;


namespace Swiftrade.Infrastructure.Services.Communication
{
    internal class SMSService : ISMSService
    {
        public Task<Result> SendSMSAsync(string to, string body) {
            throw new NotImplementedException();
        }

        public Task<Result> SendSMSAsync(string from, string to, string body) {
            throw new NotImplementedException();
        }
    }
}
