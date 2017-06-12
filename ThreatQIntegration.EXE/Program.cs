using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemplify.Integrations.ThreatQ;
using Siemplify.Integrations.ThreatQ.Data;

namespace ThreatQIntegration.EXE
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ThreatQ");

            const string host = "XXX";
            const string clientId = "XXX";
            const string user = "XXX";
            const string pass = "XXX";

            var client = new ThreatQApiClient(host, clientId, user, pass);

            //var indicators = client.GetRawIndicators().Result;
            var indicators = client.GetIndicators(
                limit: 5,
                includeTypes: ApiDataTypes.Score | ApiDataTypes.Status | ApiDataTypes.Sources | ApiDataTypes.Type).Result;
            //var indicators = client.GetIndicators();

            Console.WriteLine(indicators);

        }
    }
}
