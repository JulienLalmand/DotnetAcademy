using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    static class Opdracht
    {
        public static void KoerierVraag()
        {
            if (LeveringsBedrijf.postcodes.Length != LeveringsBedrijf.prijzen.Length)
            {
                Console.WriteLine("Fatal: Misconfiguration: de lengte van de prijzen-array komt niet overeen met de lengte van de postcodes-array.");
                Environment.Exit(0xD);
            }

            Console.WriteLine("Geef het gewicht van uw pakket in kg:");
            double gewicht;
            while (!Double.TryParse(Console.ReadLine().Replace('.', ','), out gewicht))
            {
                Console.WriteLine("Dit is geen correct gewicht. Probeer opnieuw.");
            }

            Console.WriteLine("Naar welke postcode wenst u dit pakket te versturen?");
            string postcode = Console.ReadLine();

            if(!LeveringsBedrijf.postcodes.Contains(postcode))
            {
                Console.WriteLine("Hier wordt helaas niet geleverd.");
                return;
            }

            double price = LeveringsBedrijf.prijzen[Array.IndexOf(LeveringsBedrijf.postcodes, postcode)] * gewicht;

            Console.WriteLine($"Dit zal {price} euro kosten.");
        }
    }
}
