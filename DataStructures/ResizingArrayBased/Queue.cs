/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DCoreyDuke.CodeBase.DataStructures.ResizingArrayBased
{
    /// <summary>
    /// The <c>Queue</c> class represents a first-in-first-out (FIFO) queue of generic items. It
    /// supports the usual <c>Enqueue</c> and <c>Dequeue</c> operations, along with methods for
    /// peeking at the first item, testing if the queue is empty, and iterating through the items in
    /// FIFO order. This implementation uses a resizing array, which double the underlying array
    /// when it is full and halves the underlying array when it is one-quarter full. The
    /// <c>Enqueue</c> and <c>Dequeue</c> operations take constant amortized time. The <c>Count</c>,
    /// <c>Peek</c>, and <c>IsEmpty</c> operations takes constant time in the worst case.
    /// </summary>
    public class Queue<Item> : System.Collections.Generic.Queue<Item>, IEnumerable<Item>, IQueue<Item>
    {
        private int _First;

        // index of first element of queue
        private int _Last;

        private int _N;
        private Item[] _Q;       // queue elements
                                 // number of elements on queue index of next available slot

        /// <summary>
        /// Initializes an empty queue.
        /// </summary>
        public Queue()
        {
            _Q = new Item[2];
            _N = 0;
            _First = 0;
            _Last = 0;
        }

        /// <summary>
        /// Returns the number of items in this queue.
        /// </summary>
        /// <returns>the number of items in this queue</returns>
        public new int Count
        {
            get { return _N; }
        }

        /// <summary>
        /// Is this queue empty?
        /// </summary>
        /// <returns>true if this queue is empty; false otherwise</returns>
        public bool IsEmpty
        {
            get { return _N == 0; }
        }

        /// <summary>
        /// Removes and returns the item on this queue that was least recently added.
        /// </summary>
        /// <returns>the item on this queue that was least recently added</returns>
        /// <exception cref="InvalidOperationException">if this queue is empty</exception>
        public new Item Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue underflow");
            Item item = _Q[_First];
            _Q[_First] = default;     // to avoid loitering
            _N--;
            _First++;
            if (_First == _Q.Length) _First = 0;           // wrap-around
                                                           // shrink size of array if necessary
            if (_N > 0 && _N == _Q.Length / 4) Resize(_Q.Length / 2);
            return item;
        }

        /// <summary>
        /// Adds the item to this queue.
        /// </summary>
        /// <param name="item">the item to add</param>
        public new void Enqueue(Item item)
        {
            // double size of array if necessary and recopy to front of array
            if (_N == _Q.Length) Resize(2 * _Q.Length);   // double size of array if necessary
            _Q[_Last++] = item;                        // add item
            if (_Last == _Q.Length) _Last = 0;          // wrap-around
            _N++;
        }

        /// <summary>
        /// Returns an iterator that iterates over the items in this queue in FIFO order.
        /// </summary>
        /// <returns>an iterator that iterates over the items in this queue in FIFO order</returns>
        public new IEnumerator<Item> GetEnumerator()
        {
            int i;
            for (i = 0; i < _N; i++) yield return _Q[(i + _First) % _Q.Length];
        }

        // place holder method to comply to interface implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            int i;
            for (i = 0; i < _N; i++) yield return _Q[(i + _First) % _Q.Length];
        }

        /// <summary>
        /// Returns the item least recently added to this queue.
        /// </summary>
        /// <returns>the item least recently added to this queue</returns>
        /// <exception cref="InvalidOperationException">if this queue is empty</exception>
        public new Item Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue underflow");
            return _Q[_First];
        }

        // resize the underlying array
        private void Resize(int max)
        {
            Debug.Assert(max >= _N);
            Item[] temp = new Item[max];
            for (int i = 0; i < _N; i++)
            {
                temp[i] = _Q[(_First + i) % _Q.Length];
            }
            _Q = temp;
            _First = 0;
            _Last = _N;
        }
    }
}