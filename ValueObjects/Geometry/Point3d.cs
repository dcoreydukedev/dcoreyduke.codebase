/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCoreyDuke.CodeBase.ValueObjects.Geometry
{
    /// <summary>
    /// Represents a 3d Point (x, y, z)
    /// </summary>
    [ComplexType, Serializable]
    public class Point3d : IValueObject
    {
        public Point3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }
    }
}