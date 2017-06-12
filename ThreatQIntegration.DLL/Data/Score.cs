using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Siemplify.Integrations.ThreatQ.Data
{
    public class Score
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("indicator_id")]
        public int IndicatorId { get; set; }

        [JsonProperty("generated_score")]
        public double GeneratedScore { get; set; }

        [JsonProperty("manual_score")]
        public object ManualScore { get; set; }

        [JsonProperty("score_config_hash")]
        public string ScoreConfigHash { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
