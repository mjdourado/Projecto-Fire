using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado
{
    internal class Utilizador
    {
        
        private string _nome;
        private string _password;

        private string FilePath()
        {
            string filePath = Path.Combine(Configuracoes.BaseDir.FullName, _nome);
            return filePath;
        }

        public void NovoUtilizador()
        {
            Console.WriteLine("Insira um novo utilizador até quinza (15) caracteres");
            _nome = Console.ReadLine();
            if (_nome.Length > 15)
            {
                Console.WriteLine("Nome de Utilizador Inválido. Tente novamente!");
            }
            else
            {
                NovoFicheiro();
                EditarFicheiro(_nome);
                NovaPassword();
            }
        }

        public void NovaPassword()
        {
            Console.WriteLine("Insira uma password até oito (8) caracteres");
            _password = Console.ReadLine();
            if (_password.Length > 8)
            {
                Console.WriteLine("Password inválida. Tente novamente!");
                NovaPassword();
            }
            else
            {
                Console.WriteLine("Registo efectuado com sucesso!");
                EditarFicheiro(_password);
                Menus novo = new Menus();
                novo.Utilizador();
            }
        }

        public Utilizador()
        {
            var dir = new DirectoryInfo(Configuracoes.BaseDir.FullName);
            if (!dir.Exists)
                dir.Create();
        }

        public void NovoFicheiro()
        {
            var file = new FileInfo(FilePath());
            if (!file.Exists)
            {
                file.Create();
            }
        }

        public void EditarFicheiro(string info)
        {
            var ficheiro = File.AppendText(FilePath());
            ficheiro.WriteLine(info);
            ficheiro.Close();

        }

        public void Autenticar()
        {
            Console.WriteLine("Insira o nome de utilizador");
            _nome = Console.ReadLine();
            Console.WriteLine("Insira a password");
            _password = Console.ReadLine();
            Validar(_nome, _password);
        }

        public void Validar(string username, string password)
        {
            var credenciais = File.ReadAllLines(FilePath());

            if (username == credenciais[0] && password == credenciais[1])
            {
                Console.WriteLine("Autenticado!");
                Menus novo = new Menus();
                novo.Utilizador();
            }
            else
            {
                Console.WriteLine("Credenciais incorrectas, tente de novo!");
                Autenticar();
            }

        }

        public void Eliminar()
        {
            Console.WriteLine("Insira o nome de utilizador");
            _nome = Console.ReadLine();
            Console.WriteLine("Insira a password");
            _password = Console.ReadLine();
            File.Delete(FilePath());
            Console.WriteLine("Utilizador Eliminado com Sucesso");
        }
    }
}
