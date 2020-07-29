using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDashboard.Model
{
    public class MessageWrapper
    {
        public string Type { get; set; }

        public JObject ObjectAsJObject { get; set; }
    
    }
}
