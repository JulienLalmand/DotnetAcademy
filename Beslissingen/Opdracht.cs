using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beslissingen
{
    static class Opdracht
    {
        public static void BerekenBMI()
        {
            double lengte;
            double gewicht;

            Console.WriteLine($"*** BMI Calculator ***\n");
            Console.WriteLine("Geef je lengte in meters in:");
            
            while(!Double.TryParse(Console.ReadLine().Replace('.', ','), out lengte))
            {
                Console.WriteLine("Geen geldig getal voor je lengte. Probeer opnieuw.");
            }

            Console.WriteLine("Geef vervolgens jouw gewicht in kilogram in:");
            while (!Double.TryParse(Console.ReadLine().Replace('.', ','), out gewicht))
            {
                Console.WriteLine("Geen geldig getal voor je gewicht. Probeer opnieuw.");
            }

            Console.WriteLine("Wens je feedback te krijgen bij je BMI? (y/N)");
            bool feedbackGewenst = (Console.ReadLine().ToUpper() == "Y" ? true : false);

            using(IBMICalculator bmiCalculator = new BMICalculator(lengte, gewicht))
            {
                double bmi = bmiCalculator.CalculateBMI();

                Console.WriteLine($"Jouw BMI is {bmi}.");

                if(feedbackGewenst)
                {
                    switch(bmiCalculator.GetBMIType())
                    {
                        case BMIType.ONDERGEWICHT:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ondergewicht.");
                            break;
                        case BMIType.NORMAAL:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Normaal.");
                            break;
                        case BMIType.OVERGEWICHT:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Overgewicht. Je loopt niet echt een risico, maar je mag niet dikker worden.");
                            break;
                        case BMIType.ZWAARLIJVIGHEID:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Zwaarlijvigheid (obesitas). Verhoogde kans op allerlei aandoeningen zoals diabetes, hartaandoeningen en rugklachten. Je zou 5 tot 10 kg moeten vermageren.");
                            break;
                        case BMIType.ERNSTIGE_ZWAARLIJVIGHEID:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Ernstige zwaarlijvigheid. Je moet dringend vermageren want je gezondheid is in gevaar (of je hebt je lengte of gewicht in verkeerde eenheid ingevoerd).");
                            break;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            return;
        }
    }
}
