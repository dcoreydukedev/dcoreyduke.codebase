/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCoreyDuke.CodeBase.ValueObjects.Geometry
{
    [ComplexType, Serializable]
    public class LineSegment : IValueObject
    {
        public Point EndingPoint { get; set; }

        public Point StartingPoint { get; set; }
    }
}