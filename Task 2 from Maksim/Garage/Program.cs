using System;
using System.Collections.Generic;
using System.Linq;
using Garage.Interfeces;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitFromMenu = false;
            bool successfullRead = false, successfullWrite = false;
            List<ITransport> listOfTransport = new List<ITransport>();
            SetDefaultPrise();

            while (!exitFromMenu)
            {   
                try
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
                    switch (EnterNumber())
                    {
                        case 1:
                            ShowTransportInfo(listOfTransport.Where(e => e.NumberForSearchAndSort == 1).ToList());
                            break;
                        case 2:
                            ShowTransportInfo(listOfTransport.Where(e => e.NumberForSearchAndSort == 2).ToList());
                            break;
                        case 3:
                            ShowTransportInfo(listOfTransport.Where(e => e.NumberForSearchAndSort == 3).ToList());
                            break;
                        case 4:
                            ShowTransportInfo(listOfTransport.OrderBy(e => e.NumberForSearchAndSort).ToList());
                            break;
                        case 5:
                            ShowTransportInfo(listOfTransport.Where(e => e.MaxSpeed == listOfTransport.Max(e => e.MaxSpeed)).ToList());
                            break;
                        case 6:
                            ShowTransportInfo(listOfTransport.Where(e => e.MaintenanceCost() == listOfTransport.Min(e => e.MaintenanceCost())).ToList());
                            break;
                        case 7:
                            ShowTransportInfo(listOfTransport.Where(e => e.SoundSignal == true).ToList());
                            break;
                        case 8:
                            successfullRead = FileStream.ReadFileTo(listOfTransport);
                            if (successfullRead)
                            {
                                ShowMessage("The file was read successfully.");
                            }
                            break;
                        case 9:
                            successfullWrite = FileStream.SaveInFileFrom(listOfTransport);
                            if (successfullWrite)
                            {
                                ShowMessage("Information is recorded successfully.");
                            }
                            break;
                        case 10:
                            exitFromMenu = true;
                            break;
                        default:
                            ShowMessage("There is no such menu item.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
            }
            
        }

        static void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public static void ShowTransportInfo(List<ITransport> listOfTransport)
        {
            if (listOfTransport.Count == 0)
            {
                ShowMessage("NO any transport.");
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

        static int EnterNumber()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                return number;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void SetDefaultPrise()
        {
            Price.Fuel = 3;
            Price.OilChange = 2;
            Price.TransportWash = 20;
            Price.WheelMaintenance = 35;
        }
    }
}
