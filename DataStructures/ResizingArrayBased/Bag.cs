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
    /// The <c>Bag</c> class represents a bag of generic items. It supports insertion and iterating
    /// over the items in arbitrary order. This implementation uses a resizing array. The <c>Add</c>
    /// operation takes constant amortized time; the <c>IsEmpty</c>, and <c>Count</c> operations
    /// take constant time. Iteration takes time proportional to the number of items.
    /// </summary>
    public class Bag<Item> : IEnumerable<Item>, IBag<Item>
    {
        private Item[] _A;         // array of items
        private int _N;            // number of elements on stack

        /// <summary>
        /// Initializes an empty bag.
        /// </summary>
        public Bag()
        {
            _A = new Item[2];
            _N = 0;
        }

        /// <summary>
        /// Returns the number of items in this bag.
        /// </summary>
        /// <returns>the number of items in this bag</returns>
        public int Count
        {
            get { return _N; }
        }

        /// <summary>
        /// Is this bag empty?
        /// </summary>
        /// <returns>true if this bag is empty; false otherwise</returns>
        public bool IsEmpty
        {
            get { return _N == 0; }
        }

        /// <summary>
        /// Adds the item to this bag.
        /// </summary>
        /// <param name="item">item the item to add to this bag</param>
        public void Add(Item item)
        {
            if (_N == _A.Length) Resize(2 * _A.Length);  // double size of array if necessary
            _A[_N++] = item;                            // add item
        }

        /// <summary>
        /// Clears the Bag
        /// </summary>
        public void Clear()
        {
            _A = new Item[2];
            _N = 0;
        }

        /// <summary>
        /// Returns an iterator that iterates over the items in the bag in arbitrary order.
        /// </summary>
        /// <returns>an iterator that iterates over the items in the bag in arbitrary order</returns>
        public IEnumerator<Item> GetEnumerator()
        {
            int i;
            for (i = 0; i < _N; i++) yield return _A[i];
        }

        // place holder method to comply to interface implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            int i;
            for (i = 0; i < _N; i++) yield return _A[i];
        }

        // resize the underlying array holding the elements
        private void Resize(int capacity)
        {
            Debug.Assert(capacity >= _N);
            Item[] temp = new Item[capacity];
            for (int i = 0; i < _N; i++)
                temp[i] = _A[i];
            _A = temp;
        }
    }
}