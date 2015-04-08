using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace DIntegra.TU.Communicate
{
    public class ClientHeadProperty
    {
        internal HttpRequestHeader Header { get; set; }

        internal String Title { get; set; }

        internal String Value { get; set; }
    }
}
