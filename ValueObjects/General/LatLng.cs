/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCoreyDuke.CodeBase.ValueObjects.General
{
    [ComplexType, Serializable]
    public class LatLng<TLattitude, TLongitude> : IValueObject
    {
        public LatLng(TLattitude lattitude, TLongitude longitude) : this()
        {
            Lattitude = lattitude;
            Longitude = longitude;
        }

        private LatLng()
        {
        }

        public TLattitude Lattitude { get; set; }

        public TLongitude Longitude { get; set; }
    }

    [ComplexType, Serializable]
    public class LatLngDbl : LatLng<double, double>
    {
        public LatLngDbl(double lattitude, double longitude) : base(lattitude, longitude)
        {
        }
    }

    [ComplexType, Serializable]
    public class LatLngFlt : LatLng<float, float>
    {
        public LatLngFlt(float lattitude, float longitude) : base(lattitude, longitude)
        {
        }
    }

    [ComplexType, Serializable]
    public class LatLngStr : LatLng<string, string>
    {
        public LatLngStr(string lattitude, string longitude) : base(lattitude, longitude)
        {
        }
    }
}