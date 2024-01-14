using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado
{
    internal class Administrador
    {
        private string userName = "admin";
        private string password = "TcGf3o#23";

        public void Autenticar()
        {
            Console.WriteLine("Insira o nome de utilizador");
            string username = Console.ReadLine();
            Console.WriteLine("Insira a palavra pass");
            string password = Console.ReadLine();
            Validar(username, password);
        }

        public void Validar(string user, string pwd) {
           
            if (user == userName && pwd == password)
            {
                Menus novo = new Menus();
                novo.Administrador();
                return;
            }
            Console.WriteLine("Password incorrecta, tente de novo!");
            Administrador novaAutenticacao = new Administrador();
            novaAutenticacao.Autenticar();
        }
    }
}
