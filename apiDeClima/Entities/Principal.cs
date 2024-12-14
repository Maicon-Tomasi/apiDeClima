using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apiDeClima.Entities
{
    internal class Principal
    {
        [JsonProperty("temp")]
        public float Temp { get; set; }
        [JsonProperty("humidity")]
        public float Humidity { get; set; }
    }
}
