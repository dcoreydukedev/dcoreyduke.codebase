/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;

namespace DCoreyDuke.CodeBase.Interfaces
{
    public interface IArraySerializable
    {
        public Array ToArray();
        public string ToJsonArray();
    }
}
