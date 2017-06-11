using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemplify.Integrations.ThreatQ.Data
{
    [Flags]
    public enum ApiDataTypes
    {
        None = 0x0,
        Type = 0x1,
        Status,
        Sources,
        Score
    }

    public enum SortOrder
    {
        ASC,
        DESC
    }
}
