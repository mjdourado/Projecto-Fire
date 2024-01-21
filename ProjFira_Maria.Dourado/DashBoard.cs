using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProjFira_Maria.Dourado;

public class DashBoard
{
    string userFilePath = Configuracoes._logfile;
    string dashBoard = $"Dashboard de {Configuracoes._logUser}";
    string nome;
    float patrimonio;
    int idade;
    int anosRestates;
    float despesas;
    float retorno;
    float inflacao;
    float retornoMensalInicial;
    float racio;
    float valorMensal;

    public void DefinirValores()
    {
        var userFile = File.ReadAllText(userFilePath);
        var userJson = JsonSerializer.Deserialize<Utilizador>(userFile);
        nome = userJson.nome;
        patrimonio = userJson.patrimnio;
        despesas = userJson.mediaDespesas;
        retorno = userJson.retorno;
        idade = DateTime.Now.Year - userJson.dataNascimento.Year;
        anosRestates = userJson.longevidade - idade;
        inflacao = userJson.inflacao;
        retornoMensalInicial = patrimonio * retorno / 12;
        racio = valorMensal / despesas;
        retornoMensalInicial = patrimonio * retorno / 12;
        valorMensal = retornoMensalInicial - despesas;
        Dash();
    }

    public void Dash()
    {
        Console.WriteLine(dashBoard);
        if (Console.ReadLine() == "fire set-user")
        {
            EditarUtilizador novo = new EditarUtilizador();
            novo.Helper();
        }

        Console.WriteLine($"O valor do património de {nome} é de {patrimonio}€.");
        Console.WriteLine($"As suas despesas mensais são de {despesas}€.");
        Console.WriteLine($"Estima-se que a taxa de inflação seja de {inflacao}, de acordo com o utilizador.");
        Console.WriteLine($"Estima-se que irá viver mais {anosRestates} anos");
        Console.WriteLine($"O seu rendimento mensal é de cerca de {retornoMensalInicial}");
        Console.WriteLine($"O seu rácio de independência financeira é de {racio}, no ano actual, mas este valor irá alterar, de acordo com a inflação");
        Console.WriteLine("Para voltar ao menu anterior prima q");
        string userRequest = Console.ReadLine();
        if (userRequest == "q")
        {
            Menus menu = new Menus();
            menu.Utilizador();
        };
    }
}

//- Se se reformar agora, quanto poderá receber mensalmente;
//- Indicação se o utilizador se pode reformar neste momento;
        
            