using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Siemplify.Integrations.ThreatQ.Data
{
    public class Status
    {
        private static string _yesIndicator = "Y";

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("user_editable")]
        public string UserEditable { get; set; }

        [JsonIgnore]
        public bool IsUserEditable => UserEditable.Equals(_yesIndicator);

        [JsonProperty("visible")]
        public string Visible { get; set; }

        [JsonIgnore]
        public bool IsVisible => Visible.Equals(_yesIndicator);

        [JsonProperty("include_in_export")]
        public string IncludeInExport { get; set; }

        [JsonIgnore]
        public bool IsIncludeInExport => IncludeInExport.Equals(_yesIndicator);

        [JsonProperty("protected")]
        public string Protected { get; set; }

        [JsonIgnore]
        public bool IsProtected => Protected.Equals(_yesIndicator);

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
