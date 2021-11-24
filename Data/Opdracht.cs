using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    static class Opdracht
    {
        public static void BerekenPoef()
        {
            double totaalBedrag = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Voer bedrag in?");
                double bedrag;
                if (Double.TryParse(Console.ReadLine().Replace('.', ','), out bedrag))
                {
                    totaalBedrag = totaalBedrag + bedrag;
                    Console.WriteLine($"De poef staat op {totaalBedrag} euro.");
                }
                else
                {
                    Console.WriteLine("Geen geldig bedrag. Probeer opnieuw.");
                    i--;
                    continue;
                }
            }

            Console.WriteLine("***************");
            Console.WriteLine($"Het totaal van de poef is {totaalBedrag} en zal { Math.Ceiling(totaalBedrag / 10)} weken duren om volledig afbetaald te worden.");
        }
    }
}
