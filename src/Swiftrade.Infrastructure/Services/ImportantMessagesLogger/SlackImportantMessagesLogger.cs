using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace Swiftrade.Infrastructure.Services.IImportantMessagesLogger
{
    public class SlackImportantMessagesLogger 
    {
        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();
        const string SLACK_URL = "https://hooks.slack.com/services/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";

        public SlackImportantMessagesLogger()
        {
            _uri = new Uri(SLACK_URL);
        }

        //Post a message using simple strings
        public string PostMessage(string text, string channel = null)
        {
            var payload = new Payload
            {
                Channel = channel,
                Text = text
            };
            return PostMessage(payload);
        }

        //Post a message using a Payload object
        private string PostMessage(Payload payload)
        {
            var payloadJson = JsonConvert.SerializeObject(payload);
            using (var client = new WebClient())
            {
                var data = new NameValueCollection { ["payload"] = payloadJson };
                var response = client.UploadValues(_uri, "POST", data);
                //The response text is usually "ok"
                return _encoding.GetString(response);
            }
        }
    }

    //This class serializes into the Json payload required by Slack Incoming WebHooks
    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}