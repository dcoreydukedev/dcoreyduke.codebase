/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.DataStructures
{
    public interface IStack<Item>
    {
        int Count { get; }

        bool IsEmpty { get; }

        IEnumerator<Item> GetEnumerator();

        Item Peek();

        Item Pop();

        void Push(Item item);
    }
}