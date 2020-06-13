/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.DataStructures
{
    public interface IQueue<Item>
    {
        int Count { get; }

        bool IsEmpty { get; }

        Item Dequeue();

        void Enqueue(Item item);

        IEnumerator<Item> GetEnumerator();

        Item Peek();
    }
}