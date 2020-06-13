/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCoreyDuke.CodeBase.Objects.Geometry
{
    [ComplexType, Serializable]
    public class LineSegment
    {
        public Point EndingPoint { get; set; }

        public Point StartingPoint { get; set; }
    }
}