using System;
using System.Collections.Generic;
using System.Linq;

namespace GewichtInSpace
{
    class Program
    {
        static void Main(string[] args)
        {

            //Instantiate calculator with some hardcoded data
            IPlanetWeightCalculator planetWeightCalculator = new PlanetWeightCalculator(new Dictionary<string, double>
            {
                { "Aarde", 1.00 },
                { "Mercurius", 0.38 },
                { "Venus", 0.91 },
                { "Mars", 0.38 },
                { "Jupiter", 2.34 },
                { "Saturnus", 1.06 },
                { "Uranus", 0.92 },
                { "Neptunus", 1.19 },
                { "Pluto", 0.06 },
            });

            Dictionary<string, double> result;

            if(planetWeightCalculator.TryCalculateAll(75.5, out result, true))
            {
                for(int i = 0; i < result.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Je weegt op {result.Keys.ElementAt(i)} {result.Values.ElementAt(i)}kg.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (i == result.Count - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Je weegt op {result.Keys.ElementAt(i)} {result.Values.ElementAt(i)}kg.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine($"Je weegt op {result.Keys.ElementAt(i)} {result.Values.ElementAt(i)}kg.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Could not calculate your weight on all planets in bulk.");
            }

            #region Deeltje zonder de kleuren
            /**
            //Get all known planets
            List<string> planets = planetWeightCalculator.GetCurrentlyKnownPlanets();

            //Add some unknown planet as well just to make sure it doesn't go overkop
            planets.Add("SomeUnknownPlanetOurCalculatorDoesntKnow");

            //Iterate and calculate, then display
            foreach(string planet in planets)
            {
                double weight;

                if(planetWeightCalculator.TryCalculate(planet, 75, out weight))
                {
                    Console.WriteLine($"Je weegt op {planet} {weight}kg.");
                }
                else
                {
                    Console.WriteLine($"Could not determine your weight on {planet}.");
                }
            }
            **/
            #endregion
            
            
            //End
            Console.ReadKey(true);
        }
    }
}
