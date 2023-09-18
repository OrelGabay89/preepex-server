using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using Preepex.Core.Application.Interfaces.Shared;

namespace Preepex.Infrastructure.Services
{
    public class NoopImportantMessagesLogger : IImportantMessagesLogger
    {
        //Post a message using simple strings
        public string PostMessage(string text, string channel = null)
        {
            return "NoopImportantMessagesLogger";
        }
    }
}