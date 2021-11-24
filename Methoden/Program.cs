using System;

namespace Methoden
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Geef een naam van een film:");
                string filmName = Console.ReadLine();

                Console.WriteLine("Hoe lang duurt de film? (in minuten)");
                int duur;
                Int32.TryParse(Console.ReadLine(), out duur);

                Console.WriteLine("Welke genre?");
                Console.WriteLine($"De mogelijkheden zijn {String.Join(',', Enum.GetNames(typeof(FilmType)))}");
                string genre = Console.ReadLine();

                FilmType res;

                if(Enum.TryParse<FilmType>(genre.ToUpper(), out res))
                {
                    if(duur != 0)
                        Opdracht.FilmRuntime(filmName, duur,  res);
                    else
                        Opdracht.FilmRuntime(naam: filmName, type: res);
                }
                else
                {
                    if(duur != 0)
                        Opdracht.FilmRuntime(filmName, duur);
                    else
                        Opdracht.FilmRuntime(filmName);
                }
                Console.WriteLine("--------------------------\n");
            }
        }

    }
}
