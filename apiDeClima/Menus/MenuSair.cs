using apiDeClima.Entities;

namespace apiDeClima.Menus;

internal class MenuSair : Menu
{
    public override async Task Executar()
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
