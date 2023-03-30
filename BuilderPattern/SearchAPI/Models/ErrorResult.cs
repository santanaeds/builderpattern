using Newtonsoft.Json;

namespace SearchAPI.Models
{
    public class ErrorResult
    {
        public ErrorResult(string code, string message = null, string innerMessage = null)
        {
            Error = new Error
            {
                Code = code,
                Message = message,
                InnerMessage = innerMessage
            };
        }

        [JsonProperty("error")] public Error Error { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("message")] public string Message { get; set; }
        [JsonProperty("innerMessage")] public string InnerMessage { get; set; }
    }
}
