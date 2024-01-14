using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado
{
    internal static class Configuracoes
    {
        static DirectoryInfo baseDir;

        public static DirectoryInfo BaseDir { get => baseDir; set => baseDir = value; }
    }
}
