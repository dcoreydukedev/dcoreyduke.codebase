/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace DCoreyDuke.CodeBase.DataStructures
{
    public interface IBag<Item>
    {
        int Count { get; }

        bool IsEmpty { get; }

        void Add(Item item);

        void Clear();

        IEnumerator<Item> GetEnumerator();
    }
}