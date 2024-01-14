using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado
{
    internal class NovaPasta
    {
        string pastaBase;

        public void ConfigurarPasta()
        {
            Console.WriteLine("Insira o caminho pretendido para a pasta base.");
            pastaBase = Console.ReadLine();
            CriarPasta();
        }

        public void CriarPasta()
        {
            var dir = new DirectoryInfo(pastaBase);
            if (!dir.Exists)
                dir.Create();
            Configuracoes.BaseDir = dir;


        }
    }
}
