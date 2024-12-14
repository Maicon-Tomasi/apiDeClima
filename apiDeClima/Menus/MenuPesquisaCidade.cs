using apiDeClima.Entities;
using apiDeClima.Entities.Services;

namespace apiDeClima.Menus;

internal class MenuPesquisaCidade : Menu
{
    public override async Task Executar()
    {
        base.Executar();

        Console.WriteLine("Informe o nome de uma cidade e em seguida o país");
        Console.WriteLine("Exemplo: Orlando,US");
        string nomeCidade = Console.ReadLine();

        CidadeServices cidadeServices = new CidadeServices();

        Cidade cidadeEncontrada = await cidadeServices.Integracao(nomeCidade);

        if (cidadeEncontrada?.Verificacao == true)
        {
            Console.WriteLine("Cidade não encontrada. Verifique o nome digitado.");
        }
        else
        {
            Console.WriteLine($"Cidade: {cidadeEncontrada.Name}");
            foreach (var clima in cidadeEncontrada.Clima)
            {
                Console.WriteLine($"Clima: {clima.Main}");
                Console.WriteLine($"Descrição: {clima.Description}");
            }
            Console.WriteLine($"Temperatura: {cidadeEncontrada.Caracteristicas.Temp} °C");
            Console.WriteLine($"Umidade: {cidadeEncontrada.Caracteristicas.Humidity}%");
            Console.WriteLine($"País: {cidadeEncontrada.Pais.Country}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
    }
}
