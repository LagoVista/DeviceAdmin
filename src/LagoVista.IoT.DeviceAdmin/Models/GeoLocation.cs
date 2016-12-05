using LagoVista.Core.Geo;
using LagoVista.Core.Models;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class GeoLocation : ModelBase, IGeoLocation
    {
        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set { Set(ref _latitude, value); }
        }

        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                Set(ref _longitude, value);
            }
        }

        private double _altitude;
        public double Altitude
        {
            get { return _altitude; }
            set
            {
                Set(ref _altitude, value);
            }
        }

        private String _lastUpdated;
        public string LastUpdated
        {
            get { return _lastUpdated; }
            set
            {
                Set(ref _lastUpdated, value);
            }
        }

    }
}
