namespace Swiftrade.Core.Application.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null, string callback = "")
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Callback = callback;

        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Callback { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request",
                401 => "Unauthorized ",
                403 => "Forbidded",
                404 => "Resource found",
                500 => "Server Errors",
                _ => null
            };
        }
    }
}