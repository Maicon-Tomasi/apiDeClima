using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDeClima.Entities.Services
{
    internal class CidadeServices
    {
        public async Task<Cidade> Integracao(string cidade)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cidade}&appid=735c5dbe0e335e47fd925e80875c0b61&units=metric&lang=pt");
            var jsonString = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(jsonString);

            // Verifica se o campo "cod" é "404"
            if ((string)json["cod"] == "404")
            {
                Console.WriteLine($"Erro: {json["message"]}");
                return new Cidade
                {
                    Verificacao = true // Indica que houve erro
                };
            }

            Cidade jsonObject = JsonConvert.DeserializeObject<Cidade>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }
            else
            {
                   
                return new Cidade
                {
                    Verificacao = true
                };
            }
        }
    }
}
