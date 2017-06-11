using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace Siemplify.Integrations.ThreatQ.Data
{
    public class ApiToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        [DeserializeAs(Name = "expires_in")]
        public int Expires { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        //[JsonIgnore]
        //public RestResponseCookie Cookie { get; set; }
    }
}
