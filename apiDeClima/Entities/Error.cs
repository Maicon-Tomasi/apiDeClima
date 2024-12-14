using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDeClima.Entities;
    internal class Error
    {
        [JsonProperty("cod")]
        public int cod { get; set; }
    }
