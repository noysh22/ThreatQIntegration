using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Siemplify.Integrations.ThreatQ.Data
{
    public class Indicator
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        [JsonProperty("status_id")]
        public int StatusId { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("last_detected_at")]
        public DateTime LastDetectedAt { get; set; }

        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("expired_at")]
        public DateTime ExpiredAt { get; set; }

        [JsonProperty("expires_calculated_at")]
        public DateTime ExpiresCalculatedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("touched_at")]
        public DateTime TouchedAt { get; set; }

        [JsonProperty("type")]
        public IndicatorType Type { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("sources")]
        public List<Source> Sources { get; set; }

        [JsonProperty("score")]
        public Score Score { get; set; }

    }
}
