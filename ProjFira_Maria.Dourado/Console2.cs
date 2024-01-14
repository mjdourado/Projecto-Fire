using ProjFira_Maria.Dourado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado
{
    internal class Console2
    {
        public static int ReadInt()
        {
            string input = Console.ReadLine();

            _ = int.TryParse(input, out int value);
            return value;
        }
    }
}

