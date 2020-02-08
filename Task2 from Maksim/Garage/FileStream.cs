using System;
using System.Collections.Generic;
using System.IO;
using Garage.ClasesOfTransport;
using System.Configuration;

namespace Garage
{
    /// <summary>
    /// Class contains methods for reading information from the file or writing to it.
    /// </summary>
    internal static class FileStream
    {
        /// <summary>
        /// Return true if the file was successful read, otherwise false.
        /// </summary>
        /// <param name="listOfTransport">List contains the transports from the file.</param>
        public static void ReadFileTo(List<Transport> listOfTransport)
        {
            try
            {
                FileReading(listOfTransport);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Reading data from the file.
        /// </summary>
        /// <param name="listOfTransport">Contains information about the transport.</param>
        private static void FileReading(List<Transport> listOfTransport)
        {
            try
            {
                var defaultFileForVehicleInformation = ConfigurationManager.AppSettings["NameOfDefaultFile"];
                using (var reader = new StreamReader(defaultFileForVehicleInformation))
                {
                    while (!reader.EndOfStream)
                    {
                        switch (reader.ReadLine())
                        {
                            case "Car":
                                var car = GetCarFromFile(reader);
                                listOfTransport.Add(car);
                                break;
                            case "Boat":
                                var boat = GetBoatFromFile(reader);
                                listOfTransport.Add(boat);
                                break;
                            case "Plane":
                                var plane = GetPlaneFromFile(reader);
                                listOfTransport.Add(plane);
                                break;
                            default:
                                throw new FormatException();
                        }
                    }
                }
            }
            catch (FileNotFoundException fileException)
            {
                throw fileException;
            }
        }

        private static Boat GetBoatFromFile(StreamReader reader)
        {
            return new Boat
            {
                RegistrationNumber = reader.ReadLine(),
                MaxSpeed = int.Parse(reader.ReadLine()),
                MaxFuelQuantity = double.Parse(reader.ReadLine()),
                FuelQuantity = double.Parse(reader.ReadLine()),
            };
        }

        private static Car GetCarFromFile(StreamReader reader)
        {
            return new Car
            {
                RegistrationNumber = reader.ReadLine(),
                MaxSpeed = int.Parse(reader.ReadLine()),
                MaxFuelQuantity = double.Parse(reader.ReadLine()),
                FuelQuantity = double.Parse(reader.ReadLine()),
                NumberOfWheels = int.Parse(reader.ReadLine()),
            };
        }

        private static Plane GetPlaneFromFile(StreamReader reader)
        {
            return new Plane
            {
                RegistrationNumber = reader.ReadLine(),
                MaxSpeed = int.Parse(reader.ReadLine()),
                MaxFuelQuantity = double.Parse(reader.ReadLine()),
                FuelQuantity = double.Parse(reader.ReadLine()),
                NumberOfWheels = int.Parse(reader.ReadLine()),
            };
        }
    }
}
