using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado
{
    internal class EditarUtilizador
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

        

        public void Helper()
        {
            Console.WriteLine(title);
            string userChoice = Console.ReadLine();
            if (userChoice == "fire set-user --help")
            {
                Console.WriteLine(helpMeu);
            }
            else if (userChoice.StartsWith("fire set-user"))
            {
                LerParametros(userChoice);
            } else
            {
                Console.WriteLine("Comando desconhecido, tente novamente");
            }
            Helper();
        }

        public void LerParametros(string userChoice)
        {
            string[] parameters = userChoice.Split("--");
            parameters = parameters.Skip(1).ToArray();
            foreach(string param in parameters)
            {
                string[] separatedparam = param.Split(new char[] { ' ' }, 2);

                //switch case para todas as opões (nome, pwd etc etc)
                //função para cada alteração.
            }

        }
    }
}
