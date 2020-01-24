using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Garage.Transport;
using Garage.Interfeces;

namespace Garage
{
    public static class FileStream
    {
        private static string path = @"C:\Users\Sergey\Desktop\копия\prikol C#\Task2 from Maksim\Garage\Transport.txt";
        public static bool ReadFileTo(List<ITransport> listOfTransport)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while(!reader.EndOfStream)
                    {
                        switch (reader.ReadLine())
                        {
                            case "Car":
                                Car car = new Car {
                                    RegistrationNumber = reader.ReadLine(),
                                    MaxSpeed = int.Parse(reader.ReadLine()),
                                    MaxFuelQuantity = double.Parse(reader.ReadLine()),
                                    FuelQuantity = double.Parse(reader.ReadLine()),
                                    NumberOfWheels = int.Parse(reader.ReadLine())
                                };
                                listOfTransport.Add(car);
                                break;
                            case "Boat":
                                Boat boat = new Boat {
                                    RegistrationNumber = reader.ReadLine(),
                                    MaxSpeed = int.Parse(reader.ReadLine()),
                                    MaxFuelQuantity = double.Parse(reader.ReadLine()),
                                    FuelQuantity = double.Parse(reader.ReadLine())
                                };
                                listOfTransport.Add(boat);
                                break;
                            case "Plane":
                                Plane plane = new Plane {
                                    RegistrationNumber = reader.ReadLine(),
                                    MaxSpeed = int.Parse(reader.ReadLine()),
                                    MaxFuelQuantity = double.Parse(reader.ReadLine()),
                                    FuelQuantity = double.Parse(reader.ReadLine()),
                                    NumberOfWheels = int.Parse(reader.ReadLine())
                                };
                                listOfTransport.Add(plane);
                                break;
                            default:
                                throw new FormatException();
                        }
                    }

                    reader.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveInFileFrom(List<ITransport> listOfTransprt)
        {
            if (listOfTransprt == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var item in listOfTransprt)
                    {
                        switch (item.NumberForSearchAndSort)
                        {
                            case 1:
                                writer.WriteLine("Car");
                                writer.WriteLine(item.MaxSpeed);
                                writer.WriteLine(item.MaxFuelQuantity);
                                writer.WriteLine(item.FuelQuantity);
                                writer.WriteLine(item.NumberOfWheels);
                                writer.WriteLine(item.RegistrationNumber);
                                break;
                            case 2:
                                writer.WriteLine("Boat");
                                writer.WriteLine(item.MaxSpeed);
                                writer.WriteLine(item.MaxFuelQuantity);
                                writer.WriteLine(item.FuelQuantity);
                                writer.WriteLine(item.RegistrationNumber);
                                break;
                            case 3:
                                writer.WriteLine("Plane");
                                writer.WriteLine(item.MaxSpeed);
                                writer.WriteLine(item.MaxFuelQuantity);
                                writer.WriteLine(item.FuelQuantity);
                                writer.WriteLine(item.NumberOfWheels);
                                writer.WriteLine(item.RegistrationNumber);
                                break;
                            default:
                                throw new FormatException();
                        }
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
