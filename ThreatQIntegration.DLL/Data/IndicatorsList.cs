using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace Siemplify.Integrations.ThreatQ.Data
{
    public class IndicatorsList
    {
        [JsonProperty("total")]
        [DeserializeAs(Name = "total")]
        public uint TotalIndicators { get; set; }

        [JsonProperty("data")]
        [DeserializeAs(Name = "data")]
        public List<Indicator> Indicators { get; set; }
    }
}
