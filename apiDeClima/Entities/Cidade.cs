using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDeClima.Entities;
internal class Cidade
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("weather")]
    public List<Weather> Clima { get; set; }

    [JsonProperty("main")] 
    public Principal Caracteristicas { get; set; }

    [JsonProperty("sys")]
    public Pais Pais { get; set; }

    public bool Verificacao { get; set; }


}                                
