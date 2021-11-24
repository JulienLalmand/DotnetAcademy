using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace Tekst
{
    static class Opdracht
    {
        public static void PrintASCIIName()
        {
            string name = @"

                       .-.      .-.   _             
                       : :      : :  :_;            
                     _ : :.-..-.: :  .-. .--. ,-.,-.
                    : :; :: :; :: :_ : :' '_.': ,. :
                    `.__.'`.__.'`.__;:_;`.__.':_;:_;
                                
                                
                   ";

            foreach (char c in name)
            {
                //Random color for each character, careful for the eyes!
                Console.ForegroundColor = (ConsoleColor)Enum.GetValues(typeof(ConsoleColor)).GetValue(new Random().Next(Enum.GetValues(typeof(ConsoleColor)).Length));
                Console.Write(c);
            }

            //Reset color to original value
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintAvailableDrives()
        {
            Console.WriteLine("*** LIST OF AVAILABLE DRIVES ***");
            DriveInfo[] driveInfoArray = DriveInfo.GetDrives();
            for(int i = 0; i < driveInfoArray.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {driveInfoArray[i].Name}");
            }
        }

        public static int GetAmountOfDrives()
        {
            return DriveInfo.GetDrives().Length;
        }


        public static void PrintSystemInformation(int driveNumber)
        {
            Console.WriteLine($"*** SYSTEM INFORMATION ***");
            Console.WriteLine("");
            Console.WriteLine($"Machine Name:\t\t\t {Environment.MachineName}");
            Console.WriteLine($"Operating System:\t\t {Environment.OSVersion}");
            Console.WriteLine($"Total Physical Memory:\t\t {GetTotalPhysicalMemory()}Gb");
            Console.WriteLine($"Available Space (#{driveNumber}):\t\t {GetAvailableMainHardDriveSpace(driveNumber)}Gb");
            Console.WriteLine($"Total Space (#{driveNumber}):\t\t {GetTotalMainHardDriveSpace(driveNumber)}Gb");
        }

        private static int GetTotalPhysicalMemory()
        {
            ManagementObjectSearcher Search = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory ");

            UInt64 total = 0;
            foreach (ManagementObject ram in Search.Get())
            {
                total += (UInt64)ram.GetPropertyValue("Capacity");
            }

            return ConvertBytesToGb(total);
        }

        private static int GetAvailableMainHardDriveSpace(int driveNumber)
        {
            long maindriveinbytes = DriveInfo.GetDrives()[driveNumber - 1].AvailableFreeSpace;
            return ConvertBytesToGb(Convert.ToUInt64(maindriveinbytes));
        }

        private static int GetTotalMainHardDriveSpace(int driveNumber)
        {
            long maindriveinbytes = DriveInfo.GetDrives()[driveNumber - 1].TotalSize;
            return ConvertBytesToGb(Convert.ToUInt64(maindriveinbytes));
        }

        private static int ConvertBytesToGb(UInt64 bytes)
        {
            return Convert.ToInt32(bytes / 1073741824);
        }

    }
}
