using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosClients
{
    public class GalacticException : Exception
    {
        public GalacticException(string mess) : base(mess) { }

        public GalacticException() : base() { }

        public GalacticException(string mess, Exception innerException) : base(mess, innerException) { }
    }
}
