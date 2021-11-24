using System;

namespace Tekst
{
    class Program
    {
        static void Main(string[] args)
        {

            Opdracht.PrintASCIIName();
            Console.WriteLine("\n");

            Console.WriteLine("Note: (string interpolatie gebruikte ik al in de vorige oefening.)");
            Console.WriteLine("\n");

            Opdracht.PrintAvailableDrives();
            Console.Write($"Geef het nummer van je harde-schijf waarvan je meer informatie wenst:");
            string userInput = Console.ReadLine();
            while (!isValidDriveNumber(userInput))
            {
                Console.WriteLine("Dit is geen geldige harde-schijf nummer. Probeer opnieuw.\n");
                Opdracht.PrintAvailableDrives();
                Console.Write($"\nGeef het nummer van je harde-schijf waarvan je meer informatie wenst:");
                userInput = Console.ReadLine();
            }

            Opdracht.PrintSystemInformation(Convert.ToInt32(userInput));

            //End
            Console.ReadKey();
        }

        static bool isValidDriveNumber(string input)
        {
            int number;

            if (!Int32.TryParse(input, out number))
                return false;

            if (number > Opdracht.GetAmountOfDrives() || number <= 0)
                return false;

            return true;
        }
    }
}
