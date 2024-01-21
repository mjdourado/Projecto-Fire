using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
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
    public EditarUtilizador()
    {
        Utilizador novo = new Utilizador();
        string jsonFile = Path.Combine(novo.dirBase, novo._nomeUtilizador + ".json");
        string ficheiroJson = File.ReadAllText(jsonFile);
        Utilizador utilizador = JsonSerializer.Deserialize<Utilizador>(ficheiroJson);
    }
    

    public void Helper()
    {
        Console.WriteLine(title);
        string userChoice = Console.ReadLine();
        if (userChoice == "fire set-user --help")
        {
            Console.WriteLine(helpMeu);
        }
        else if (userChoice.StartsWith("fire set-user") && userChoice != "fire set-ser --help")
        {
            LerParametros(userChoice);
        }
        else
        {
            Console.WriteLine("Comando desconhecido, tente novamente");
        }
        Helper();
    }

    public void LerParametros(string userChoice)
    {
        string[] parameters = userChoice.Split("--");
        parameters = parameters.Skip(1).ToArray();
        foreach (string param in parameters)
        {
            string[] comando = param.Split(new char[] { ' ' }, 2);

            if (comando[0] == "fire" && comando[1] == "set-user")
            {
                ProcessarComando(comando);
            }
            else
            {
                Console.WriteLine("Comando inválido");
            }
        }
    }

    public static void ProcessarComando(string[] comando)
    {
        for (int i = 2; i < comando.Length; i += 2)
        {
            switch (comando[i])
            {
                case "--name":
                    // lógica para alterar o nome do investidor
                    break;
                case "--pwd":
                    // lógica para alterar a password
                    break;
                case "--db":
                    break;
                case "--assets":
                    break;
                case "--despenses":
                    break;
                case "--yield":
                    break;
                case "--inflation":
                    break;
                case "--ttl":
                    break;
                default:
                    Console.WriteLine("Comando inválido: " + comando[i]);
                    break;
            }
        }
    }

    public void AlterarDado()
    {

    }
}
