using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado;

internal class Menus
{
    public void MenuGeral()
    {
        string menu1 = """
            * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            *                                                       *
            *         - Para iniciar sessão digite 1                *
            *                                                       *
            *         - Para registar novo utilizador digite 2      *
            *                                                       *
            *         - Para sair digite 3                          *
            *                                                       *
            * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            """;

        Console.WriteLine(menu1);
        var escolhaMenu = Console2.ReadInt();
        Console.Clear();

        if (escolhaMenu == 1)
        {
            Utilizador novo = new Utilizador();
            novo.Autenticar();
        }
        else if (escolhaMenu == 2)
        {

            Utilizador novo = new Utilizador();
            novo.NovoUtilizador();

        }

        else if (escolhaMenu == 3)
        {
            Console.WriteLine("Obrigada e até breve");
            return;
        }
        else
        {
            Console.WriteLine("O número que introduziu não é válido, tente novamente!");
            Console.WriteLine();
            MenuGeral();
        }
    }

    public void Utilizador()
    {
        string menu = """
                      * * * * * * * * * * * * * * * * * * * * * * * * 
                      *                                             *
                      *      - Para editar utilizador digite 1      *
                      *      - Para editar despesas digite 2        *
                      *      - Para dashboard digite 3              *
                      *      - Para eliminar conta digite 4         *
                      *      - Para sair digite 5                   *
                      *                                             *
                      * * * * * * * * * * * * * * * * * * * * * * * * 
                      """;
        Console.WriteLine(menu);
        int numero = Console2.ReadInt();
        if (numero == 1)
        {
            EditarUtilizador novaedicao = new EditarUtilizador();
            novaedicao.Helper();

        }
        else if (numero == 2)
        {
            ImportarDespesas importar = new ImportarDespesas();
            importar.LerFicheiro();
        }
        else if (numero == 3)
        {
            //DashBoard();
        }
        else if (numero == 4)
        {
            Utilizador novo = new Utilizador();
            novo.Eliminar();
        }
        else if (numero == 5)
        {
            Console.WriteLine("Obrigada e até breve");
            return;
        }
        else
        {
            Console.WriteLine("O número que introduziu não é válido, tente novamente!");
            Console.WriteLine();
        }
        Utilizador();
    }

    public void Administrador()
    {
        string menu = """
                      * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
                      *                                                         *
                      *        - Para definir directoria base digite 0          *
                               - Para importar categorias digite 1              *
                      *        - Para aceder às estatísticas digite 2           *
                      *        - Para sair digite 3                             *
                      *                                                         *
                      * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
                      """;
        Console.WriteLine(menu);

        int numero = Console2.ReadInt();

        if (numero == 0)
        {
           Iniciar novo = new Iniciar();
            novo.DefinirDirectoriaBase();
            Administrador();
        }
        else if (numero == 1)
        {
            Categoria nova = new Categoria();
            nova.DefinirCategorias();
        }
        else if (numero == 2)
        {
            Estatisticas novo = new Estatisticas();
        }
        else if (numero == 3)
        {
            Console.WriteLine("Obrigada e até breve");
        }
        else
        {
            Console.WriteLine("O número que introduziu não é válido, tente novamente!");
            Console.WriteLine();
            Administrador();
        }
    }
}
