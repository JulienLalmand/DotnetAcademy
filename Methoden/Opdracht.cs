using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methoden
{
    static class Opdracht
    {
        public static void FilmRuntime(string naam, int duur = 90, FilmType type = FilmType.UNKNOWN)
        {
            Console.WriteLine($"{naam} ({duur} minuten, {type})");
        }
    }
}
