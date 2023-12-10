using Newtonsoft.Json;

namespace Domain
{
    public class InnerError
    {
        public string Code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public InnerError Innererror { get; set; }
    }
}