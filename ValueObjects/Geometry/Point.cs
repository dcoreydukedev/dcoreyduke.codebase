/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCoreyDuke.CodeBase.ValueObjects.Geometry
{
    /// <summary>
    /// Represents a 2d Point (x, y)
    /// </summary>
    [ComplexType, Serializable]
    public class Point : IValueObject
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}