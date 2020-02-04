using System;
using System.Collections.Generic;
using System.Linq;
using Garage.Interfeces;
using Garage.ClasesOfTransport;

namespace Garage
{
    /// <summary>
    /// Contain menu items and methods for executing them.
    /// </summary>
    internal class MenuProcessing
    {
        /// <summary>
        /// Shows menu items for user.
        /// </summary>
        public static void ShowMenuItems()
        {
            Console.Clear();
            Console.WriteLine("1: Show Cars.");
            Console.WriteLine("2: Show Boats.");
            Console.WriteLine("3: Show Planes.");
            Console.WriteLine("4: Order list of transport.");
            Console.WriteLine("5: Show the fastest transport.");
            Console.WriteLine("6: Least expensive transport in service.");
            Console.WriteLine("7: Transports whith sound signal.");
            Console.WriteLine("8: Read information from file.");
            Console.WriteLine("9: Save information in file.");
            Console.WriteLine("10: Exit.");
        }

        /// <summary>
        /// Contains the execution logic for each menu item.
        /// </summary>
        /// <param name="isExitFromMenu">Indicates whether the user wants to exit the menu or not.</param>
        /// <param name="isSuccessFullRead">Reflects the success of reading the file.</param>
        /// <param name="isSuccessFullWrite">Reflects the success of writing to the file.</param>
        /// <param name="listOfTransport">Contains information about transports.</param>
        public static void TransportProcessing(ref bool isExitFromMenu, ref bool isSuccessFullRead, ref bool isSuccessFullWrite, List<Transport> listOfTransport)
        {
            switch (EnterNumber())
            {
                case 1:
                    ShowListOfCars(listOfTransport);
                    break;
                case 2:
                    ShowListOfBoats(listOfTransport);
                    break;
                case 3:
                    ShowListOfPlanes(listOfTransport);
                    break;
                case 4:
                    OrderAndShowListOfTransport(listOfTransport);
                    break;
                case 5:
                    ShowTheFastestTransport(listOfTransport);
                    break;
                case 6:
                    ShowLeastExpensiveTransportInService(listOfTransport);
                    break;
                case 7:
                    ShowTransportsWhithSoundSignal(listOfTransport);
                    break;
                case 8:
                    ReadingInformationFromFile(ref isSuccessFullRead, listOfTransport);
                    break;
                case 9:
                    WritingInformationToAFile(ref isSuccessFullWrite, listOfTransport);
                    break;
                case 10:
                    isExitFromMenu = true;
                    break;
                default:
                    Program.ShowMessage("There is no such menu item.");
                    break;
            }
        }

        /// <summary>
        /// Output transport information to the console.
        /// </summary>
        /// <param name="listOfTransport">List whith transports.</param>
        private static void ShowTransportInfo(List<Transport> listOfTransport)
        {
            if (!listOfTransport.Any())
            {
                Program.ShowMessage("NO any transport.");
            }
            else
            {
                Console.Clear();
                foreach (var item in listOfTransport)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("--------------------------------");
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// Checking for correct entry of the menu item number.
        /// </summary>
        /// <returns>Item number.</returns>
        private static int EnterNumber()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                return number;
            }
            catch
            {
                throw;
            }
        }

        private static void WritingInformationToAFile(ref bool isSuccessFullWrite, List<Transport> listOfTransport)
        {
            isSuccessFullWrite = FileStream.IsSaveInFileFrom(listOfTransport);
            if (isSuccessFullWrite)
            {
                Program.ShowMessage("Information is recorded successfully.");
            }
        }

        private static void ReadingInformationFromFile(ref bool isSuccessFullRead, List<Transport> listOfTransport)
        {
            isSuccessFullRead = FileStream.IsReadFileTo(listOfTransport);
            if (isSuccessFullRead)
            {
                Program.ShowMessage("The file was read successfully.");
            }
        }

        private static void ShowTransportsWhithSoundSignal(List<Transport> listOfTransport)
        {
            ShowTransportInfo(listOfTransport.Where(e => e.IsSoundSignal == true).ToList());
        }

        private static void ShowLeastExpensiveTransportInService(List<Transport> listOfTransport)
        {
            var minMaintenanceCost = listOfTransport.Min(e => ((IComputable)e).MaintenanceCost());
            ShowTransportInfo(listOfTransport.Where(e => ((IComputable)e).MaintenanceCost() == minMaintenanceCost).ToList());
        }

        private static void ShowTheFastestTransport(List<Transport> listOfTransport)
        {
            var maxTransportSpeed = listOfTransport.Max(e => e.MaxSpeed);
            ShowTransportInfo(listOfTransport.Where(e => e.MaxSpeed == maxTransportSpeed).ToList());
        }

        private static void OrderAndShowListOfTransport(List<Transport> listOfTransport)
        {
            ShowTransportInfo(listOfTransport.OrderBy(e => e.NumberForSearch).ToList());
        }

        private static void ShowListOfPlanes(List<Transport> listOfTransport)
        {
            ShowTransportInfo(listOfTransport.Where(e => e.NumberForSearch == 3).ToList());
        }

        private static void ShowListOfBoats(List<Transport> listOfTransport)
        {
            ShowTransportInfo(listOfTransport.Where(e => e.NumberForSearch == 2).ToList());
        }

        private static void ShowListOfCars(List<Transport> listOfTransport)
        {
            ShowTransportInfo(listOfTransport.Where(e => e.NumberForSearch == 1).ToList());
        }
    }
}
