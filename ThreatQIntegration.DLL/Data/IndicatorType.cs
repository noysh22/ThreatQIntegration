using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Siemplify.Integrations.ThreatQ.Data
{
    public class IndicatorType
    {
        private static string _yesIndicator = "Y";

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("score")]
        public object Score { get; set; }

        [JsonProperty("wildcard_matching")]
        public string WildcardMatching { get; set; }

        [JsonIgnore]
        public bool IsWildcardMatching => WildcardMatching.Equals(_yesIndicator);

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
