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
        public async Task<Cidade> Integracao(string cidade = null, string latitude = null, string longitude = null)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            if ( !string.IsNullOrWhiteSpace(cidade))  { 
                 response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cidade}&appid={CHAVE API}&units=metric&lang=pt");
            }
            else if (!string.IsNullOrWhiteSpace(latitude) && !string.IsNullOrWhiteSpace(longitude))
            {
                 response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={CHAVE API}&units=metric&lang=pt");
            }
            else
            {
                Console.WriteLine("Erro: Nenhuma informação válida foi fornecida.");
                return new Cidade
                {
                    Verificacao = true
                };
            }

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
