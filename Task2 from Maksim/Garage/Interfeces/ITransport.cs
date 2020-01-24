using System;
using System.Collections.Generic;
using System.Text;
using Garage.Transport;

namespace Garage.Interfeces
{
    public interface ITransport
    {
        public int MaxSpeed { get; set; }

        public double MaxFuelQuantity { get; set; }

        public double FuelQuantity { get; set; }

        public int NumberOfWheels { get;}

        public string RegistrationNumber {get;set;}

        public bool SoundSignal { get; }

        public int NumberForSearchAndSort { get;}

        public double MaintenanceCost();

    }
}