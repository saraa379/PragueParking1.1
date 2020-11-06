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

        //constructor
        public ParkingSpot(string regNr, string vehicleType)
        {
            this.regNr = regNr;
            this.vehicleType = vehicleType;
        }

        //getters, setters
        public string RegNr
        { get; set; }

        public string VehicleType
        { get; set; }
    }
}
