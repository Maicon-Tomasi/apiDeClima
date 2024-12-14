using apiDeClima.Entities;
using apiDeClima.Entities.Services;
using apiDeClima.Menus;

namespace ConsumindoApiClima;

class Program
{
    private static Dictionary<int, Menu> opcoes = new();
    public static async Task Main(string[] args)
    {
        opcoes.Add(1, new MenuPesquisaCidade());
        opcoes.Add(-1, new MenuSair());
        Program program = new Program();
        await program.ExibirOpcoesDoMenu();
    }

    public static void ExibirLogo()
    {
        Console.WriteLine(@"
            ····················································
            :                                                  :
            :      _    ____ ___    ____ _ _                   :
            :     / \  |  _ \_ _|  / ___| (_)_ __ ___   __ _   :
            :    / _ \ | |_) | |  | |   | | | '_ ` _ \ / _` |  :
            :   / ___ \|  __/| |  | |___| | | | | | | | (_| |  :
            :  /_/   \_\_|  |___|  \____|_|_|_| |_| |_|\__,_|  :
            :                                                  :
            ····················································
        ");
    }


    public async Task ExibirOpcoesDoMenu()
    {
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para Pesquisa o clima de cidade");
        Console.WriteLine("Digite -1 para sair");
         
        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
        {
            Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
            await menuASerExibido.Executar();
            if (opcaoEscolhidaNumerica > 0) await ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine("Opção inválida");
        }
    }



    public static async Task PesquisaCidade()
    {
        
    }
}