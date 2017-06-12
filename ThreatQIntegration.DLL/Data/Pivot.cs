using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Siemplify.Integrations.ThreatQ.Data
{
    public class Pivot
    {
        [JsonProperty("indicator_id")]
        public int IndicatorId { get; set; }

        [JsonProperty("source_id")]
        public int SourceId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("creator_source_id")]
        public int CreatorSourceId { get; set; }
    }
}
