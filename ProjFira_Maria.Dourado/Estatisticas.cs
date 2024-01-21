using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado;

public class Estatisticas
{
    string nome;
    float patrimonio;
    float valorMensal;
    float racio;
    float despesas;
    float retorno;
    float retornoMensalInicial; 

    public void Statistics()
    {
        Console.WriteLine("Escreva o nome do utilizador de quem deseja ver a estatísticas");
        string statUser = Console.ReadLine();
        string fileUser = Configuracoes.BaseDir.FullName + "statUser.json";
        var userFile = File.ReadAllText(fileUser);
        var userJson = JsonSerializer.Deserialize<Utilizador>(userFile);

        nome = userJson.nome;
        patrimonio = userJson.patrimnio;
        despesas = userJson.mediaDespesas;
        retorno = userJson.retorno;
        ValorMensal();
    }

    public void ValorMensal()
    {
        retornoMensalInicial = patrimonio * retorno / 12;
        valorMensal = retornoMensalInicial - despesas;
        Racio();
    }

    public void Racio()
    {
        racio = valorMensal / despesas;
        Consola();
    }

    public void Consola()
    {
        Console.WriteLine($"O utilzador {nome} dispões de um património no valor de {patrimonio}€.");
        Console.WriteLine($"O seu valor mensal se se reformasse agora, seria de {retornoMensalInicial}€.");
        Console.WriteLine($"O seu rácio de liberdade financeira, no ano actual é de {racio}, de acordo com as despesas idicadas pelo utilizador.");
        Console.WriteLine("Para voltar ao menu anterior prima q");
        string userRequest = Console.ReadLine();
        if (userRequest == "q")
        {
            Menus menu = new Menus();
            menu.Utilizador();
        };
    }
}
