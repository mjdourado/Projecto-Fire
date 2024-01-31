using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado;

public class EditarUtilizador
{
    string helpMeu = """"
            --name Nome Investidor
            --pwd password
            --db data de nascimento usando o formato dd-mm-yyyy ou yyyy-mm-dd
            --assets valor total património
            --expenses média mensal de despesas
            --yield taxa de retorno esperada [0, 1]
            --inflation taxa de inflação [0,1]
            --ttl longevidade prevista em anos
        """";

    string title = """
        Insira um comando.
        Para visualizar as opções de edição digite 'fire set-user --help'
        Para voltar ao menu anterior prima q
        """;

    public void Editar()
    {
        Utilizador user = new Utilizador();
        string jsonFile = Path.Combine(user.dirBase, user._nomeUtilizador + ".json");
        string ficheiroJson = File.ReadAllText(jsonFile);
        Utilizador utilizador = JsonSerializer.Deserialize<Utilizador>(ficheiroJson);
    }


    public void Helper()
    {
        Console.WriteLine(title);
        string userChoice = Console.ReadLine();
        string fire = "fire set-user";
        if (userChoice == "fire set-user --help")
        {
            Console.WriteLine(helpMeu);
            Helper();
        }
        else if (userChoice.StartsWith(fire))
        {
            LerParametros(userChoice);
        }
        else if (userChoice == "q")
        {
            Menus menu = new Menus();
            menu.Utilizador();
        }
        else
        {
            Console.WriteLine("Comando desconhecido, tente novamente");
            Helper();
        }

    }

    public void LerParametros(string userChoice)
    {
        string[] parameters = userChoice.Split("--");
        if (parameters[0] == "fire set-user ")
        {
            parameters = parameters.Skip(1).ToArray();
            foreach (string param in parameters)
            {
                string[] comando = param.Split(new char[] { ' ' }, 2);
                ProcessarComando(comando);
            }
        }
        else
        {
            Console.WriteLine("Comando inválido");
        }

    }

    public void ProcessarComando(string[] comando)
    {
        Utilizador user = new Utilizador();
        string jsonFile = Path.Combine(Configuracoes._logfile);
        Utilizador utilizador = JsonSerializer.Deserialize<Utilizador>(File.ReadAllText(jsonFile));

        for (int i = 2; i < comando.Length; i += 2)
        {
            switch (comando[1])
            {
                case "name":
                    utilizador.nome = comando[1];
                    break;
                case "pwd":
                    utilizador._password = comando[1];
                    break;
                case "db":
                    utilizador.dataNascimento = DateOnly.Parse(comando[1]);
                    break;
                case "assets":
                    utilizador.patrimnio = float.Parse(comando[1]);
                    break;
                case "despenses":
                    utilizador.mediaDespesas = float.Parse(comando[1]);
                    break;
                case "yield":
                    utilizador.retorno = float.Parse(comando[1]);
                    break;
                case "inflation":
                    utilizador.inflacao = float.Parse(comando[1]);
                    break;
                case "ttl":
                    utilizador.longevidade = int.Parse(comando[1]);
                    break;
                default:
                    Console.WriteLine("Comando inválido: " + comando[1]);
                    break;
            }
        }
        string novoJson = JsonSerializer.Serialize(utilizador);
        File.WriteAllText(Configuracoes._logfile, novoJson);
    }
}
