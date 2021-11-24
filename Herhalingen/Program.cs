using System;

namespace Herhalingen
{
    class Program
    {
        static void Main(string[] args)
        {
            EulerProject();
            Boekhouder();
        }

        static void EulerProject()
        {
            Console.WriteLine("Deel 1 - Euler");
            int totaal = 0;

            for (int i = 0; i <= 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    totaal += i;
                }
            }

            Console.WriteLine($"Totaal: {totaal}");

            Console.WriteLine("Druk op een toets om de boekhouder gedeelte te starten (looped).");
            Console.ReadKey();
        }
        
        static void Boekhouder()
        {
            Boekhouding b = new Boekhouding();

            while(true)
            {
                double getal;
                Console.WriteLine("Voer een nieuw getal: ");
                while(!Double.TryParse(Console.ReadLine(), out getal))
                {
                    Console.WriteLine("Dit is geen correct getal. Probeer opnieuw.");
                }

                b.Add(getal);
                Console.WriteLine("\n-------------------------------");
                Console.WriteLine($"Balans:\t\t\t {b.GetSum()}");
                Console.WriteLine($"Balans Negatief:\t {b.GetSumOfNegatives()}");
                Console.WriteLine($"Balans Positief:\t {b.GetSumOfPositives()}");
                Console.WriteLine($"Gemiddelde:\t\t {b.GetAverage()}");
                Console.WriteLine("-------------------------------\n");

            }
        }
    }
}
