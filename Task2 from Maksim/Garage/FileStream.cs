using System;
using System.Collections.Generic;
using System.IO;
using Garage.Clases;

namespace Garage
{
    /// <summary>
    /// Class contains methods for reading information from the file or writing to it.
    /// </summary>
    public static class FileStream
    {
        private const string DefaultFileForVehicleInformation = @"Transport.txt";

        /// <summary>
        /// Return true if the file was successful read, otherwise false.
        /// </summary>
        /// <param name="listOfTransport">List contains the transports from the file.</param>
        /// <returns>Return true or throw an exception.</returns>
        public static bool IsReadFileTo(List<Transport> listOfTransport)
        {
            try
            {
                FileReading(listOfTransport);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Return true if file written is successful, otherwise false.
        /// </summary>
        /// <param name="listOfTransprt">List contains the transports that should be written to the file.</param>
        /// <returns>Return true or throw an exception.</returns>
        public static bool IsSaveInFileFrom(List<Transport> listOfTransprt)
        {
            if (listOfTransprt == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                FileWriting(listOfTransprt);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Reading from the file.
        /// </summary>
        /// <param name="listOfTransport">Contains information about the transport.</param>
        private static void FileReading(List<Transport> listOfTransport)
        {
            using (StreamReader reader = new StreamReader(DefaultFileForVehicleInformation))
            {
                while (!reader.EndOfStream)
                {
                    switch (reader.ReadLine())
                    {
                        case "Car":
                            var car = new Car
                            {
                                RegistrationNumber = reader.ReadLine(),
                                MaxSpeed = int.Parse(reader.ReadLine()),
                                MaxFuelQuantity = double.Parse(reader.ReadLine()),
                                FuelQuantity = double.Parse(reader.ReadLine()),
                                NumberOfWheels = int.Parse(reader.ReadLine()),
                            };
                            listOfTransport.Add(car);
                            break;
                        case "Boat":
                            var boat = new Boat
                            {
                                RegistrationNumber = reader.ReadLine(),
                                MaxSpeed = int.Parse(reader.ReadLine()),
                                MaxFuelQuantity = double.Parse(reader.ReadLine()),
                                FuelQuantity = double.Parse(reader.ReadLine()),
                            };
                            listOfTransport.Add(boat);
                            break;
                        case "Plane":
                            var plane = new Plane
                            {
                                RegistrationNumber = reader.ReadLine(),
                                MaxSpeed = int.Parse(reader.ReadLine()),
                                MaxFuelQuantity = double.Parse(reader.ReadLine()),
                                FuelQuantity = double.Parse(reader.ReadLine()),
                                NumberOfWheels = int.Parse(reader.ReadLine()),
                            };
                            listOfTransport.Add(plane);
                            break;
                        default:
                            throw new FormatException();
                    }
                }
            }
        }

        /// <summary>
        /// Writing to the file.
        /// </summary>
        /// <param name="listOfTransprt">Contains information about the transport.</param>
        private static void FileWriting(List<Transport> listOfTransprt)
        {
            using (StreamWriter writer = new StreamWriter(DefaultFileForVehicleInformation))
            {
                foreach (var item in listOfTransprt)
                {
                    switch (item.NumberForSearch)
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
        }
    }
}
