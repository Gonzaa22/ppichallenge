using Newtonsoft.Json.Linq;

namespace PPIChallengeAPI.Models.Helpers
{
    public class ApiResponse
    {
        public ApiResponse(int _statusCode, string _message, JObject _data)
        {
            statusCode = _statusCode;
            message = _message;
            data = _data;
        }

        public int statusCode { get; set; }
        public string message { get; set; }
        public JObject data { get; set; }
    }
}
