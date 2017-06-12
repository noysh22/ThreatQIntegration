using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemplify.Integrations.ThreatQ
{
    public class ThreatQException : Exception
    {
        public ThreatQException() { }
        public ThreatQException(string message) : base(message) { }
        public ThreatQException(string message, Exception innerEx) : base(message, innerEx) { }
    }

    public class ThreatQNullTokenException : ThreatQException
    {
        public ThreatQNullTokenException(string message) : base(message) { }
        public ThreatQNullTokenException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}
