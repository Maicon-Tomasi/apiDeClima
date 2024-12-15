using apiDeClima.Entities;
using apiDeClima.Entities.Services;

namespace apiDeClima.Menus;

internal class MenuPesquisaCidadeComLatitude : Menu
{
    public override async Task Executar()
    {
        base.Executar();

        Console.WriteLine("Informe a latitude do local:");
        Console.WriteLine("Exemplo: -20.469836459057294");
        string latitude = Console.ReadLine();

        Console.WriteLine("Informe a longitude do local:");
        Console.WriteLine("Exemplo: -54.57107713156447");
        string longitude = Console.ReadLine();

        CidadeServices cidadeServices = new CidadeServices();

        Cidade cidadeEncontrada = await cidadeServices.Integracao(null, latitude, longitude);

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
