using System;
using System.Collections.Generic;
using System.IO;
using Garage.ClasesOfTransport;

namespace Garage
{
    /// <summary>
    /// Class contains methods for reading information from the file or writing to it.
    /// </summary>
    internal static class FileStream
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
            using (var reader = new StreamReader(DefaultFileForVehicleInformation))
            {
                while (!reader.EndOfStream)
                {
                    switch (reader.ReadLine())
                    {
                        case "Car":
                            var car = CreateCar(reader);
                            listOfTransport.Add(car);
                            break;
                        case "Boat":
                            var boat = CreateBoat(reader);
                            listOfTransport.Add(boat);
                            break;
                        case "Plane":
                            var plane = CreatePlane(reader);
                            listOfTransport.Add(plane);
                            break;
                        default:
                            throw new FormatException();
                    }
                }
            }
        }

        private static Boat CreateBoat(StreamReader reader)
        {
            return new Boat
            {
                RegistrationNumber = reader.ReadLine(),
                MaxSpeed = int.Parse(reader.ReadLine()),
                MaxFuelQuantity = double.Parse(reader.ReadLine()),
                FuelQuantity = double.Parse(reader.ReadLine()),
            };
        }

        private static Car CreateCar(StreamReader reader)
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

        private static Plane CreatePlane(StreamReader reader)
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

        /// <summary>
        /// Writing to the file.
        /// </summary>
        /// <param name="listOfTransprt">Contains information about the transport.</param>
        private static void FileWriting(List<Transport> listOfTransprt)
        {
            using (var writer = new StreamWriter(DefaultFileForVehicleInformation))
            {
                foreach (var item in listOfTransprt)
                {
                    switch (item.NumberForSearch)
                    {
                        case 1:
                            WriteBoatInformationToFile(writer, item);
                            break;
                        case 2:
                            WriteCarInformationToFile(writer, item);
                            break;
                        case 3:
                            WritePlaneInformationToFile(writer, item);
                            break;
                        default:
                            throw new FormatException();
                    }
                }
            }
        }

        private static void WriteBoatInformationToFile(StreamWriter writer, Transport item)
        {
            writer.WriteLine("Boat");
            writer.WriteLine(item.MaxSpeed);
            writer.WriteLine(item.MaxFuelQuantity);
            writer.WriteLine(item.FuelQuantity);
            writer.WriteLine(item.RegistrationNumber);
        }

        private static void WriteCarInformationToFile(StreamWriter writer, Transport item)
        {
            writer.WriteLine("Car");
            writer.WriteLine(item.MaxSpeed);
            writer.WriteLine(item.MaxFuelQuantity);
            writer.WriteLine(item.FuelQuantity);
            writer.WriteLine(item.NumberOfWheels);
            writer.WriteLine(item.RegistrationNumber);
        }

        private static void WritePlaneInformationToFile(StreamWriter writer, Transport item)
        {
            writer.WriteLine("Plane");
            writer.WriteLine(item.MaxSpeed);
            writer.WriteLine(item.MaxFuelQuantity);
            writer.WriteLine(item.FuelQuantity);
            writer.WriteLine(item.NumberOfWheels);
            writer.WriteLine(item.RegistrationNumber);
        }
    }
}
