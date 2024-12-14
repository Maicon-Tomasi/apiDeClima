using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apiDeClima.Entities
{
    internal class Pais
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
