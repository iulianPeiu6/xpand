using Newtonsoft.Json;

namespace Domain
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Error[] Details { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public InnerError Innererror { get; set; }
    }
}
