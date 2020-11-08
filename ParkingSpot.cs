using System;
using System.Collections.Generic;
using System.Text;

namespace PragueParking1._1
{
    class ParkingSpot
    {
        //field
        private string regNr;
        private string vehicleType;
        private int nrOfVehicle;

        //constructor
        public ParkingSpot(string regNr, string vehicleType, int nrOfVehicle)
        {
            this.regNr = regNr;
            this.vehicleType = vehicleType;
            this.nrOfVehicle = nrOfVehicle;
    }

        //getters, setters
        public string RegNr
        {
            get { return this.regNr; }
            set { this.regNr = value; }
        }

        public string VehicleType
        {
            get { return this.vehicleType; }
            set { this.vehicleType = value; }
        }

        public int NrOfVehicle
        {
            get { return this.nrOfVehicle; }
            set { this.nrOfVehicle = value; }
        }
    }
}
