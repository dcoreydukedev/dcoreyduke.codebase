/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DCoreyDuke.CodeBase.DataStructures.LinkedListBased
{
    /// <summary>
    /// The Bag class represents a bag of generic items. It supports insertion and iterating over
    /// the items in arbitrary order. This implementation uses a singly-linked list with a nested,
    /// non-static class Node. The Add, IsEmpty, and Count operations take constant time. Iteration
    /// takes time proportional to the number of items.
    /// </summary>
    public class Bag<Item> : IEnumerable<Item>, IBag<Item>
    {
        private Node _First;    // beginning of bag
        private int _N;         // number of elements in bag

        /// <summary>
        /// Initializes an empty bag.
        /// </summary>
        public Bag()
        {
            _First = null;
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
        /// Returns true if this bag is empty.
        /// </summary>
        /// <returns><c>true</c> if this bag is empty; <c>false</c> otherwise</returns>
        public bool IsEmpty
        {
            get { return _First == null; }
        }

        /// <summary>
        /// Adds the item to this bag.
        /// </summary>
        /// <param name="item">item the item to add to this bag</param>
        public void Add(Item item)
        {
            Node oldFirst = _First;
            _First = new Node
            {
                item = item,
                next = oldFirst
            };
            _N++;
        }

        /// <summary>
        /// Clears the Bag
        /// </summary>
        public void Clear()
        {
            _First = null;
            _N = 0;
        }

        /// <summary>
        /// Returns an enumerator that iterates over the items in this bag in arbitrary order.
        /// </summary>
        /// <returns>an enumerator that iterates over the items in this bag in arbitrary order</returns>
        public IEnumerator<Item> GetEnumerator()
        {
            return new ListIEnumerator(_First);
        }

        /// <summary>
        /// Returns an iterator that iterates over the items in this queue in FIFO order.
        /// </summary>
        /// <returns>an iterator that iterates over the items in this queue in FIFO order</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns a string representation in the format "it1 it2 it3 ... itn" (LIFO order)
        /// </summary>
        /// <returns>the format string</returns>
        public override string ToString()
        {
            if (IsEmpty) return string.Empty;

            StringBuilder sb = new StringBuilder();
            Node current = _First;
            while (current != null)
            {
                sb.Append(string.Format("{0} ", current.item));
                current = current.next;
            }
            sb.Remove(sb.Length - 1, 1); // remove last space
            return sb.ToString();
        }

        // an iterator, doesn't implement Dispose() since it's optional
        private class ListIEnumerator : IEnumerator<Item>
        {
            private readonly Node _First;
            private Node _Current = null;
            private bool _FirstCall = true;

            public ListIEnumerator(Node first)
            {
                this._First = first;
            }

            public Item Current
            {
                get
                {
                    if (_Current == null)
                        throw new InvalidOperationException("Out of Bounds");
                    return _Current.item;
                }
            }

            object IEnumerator.Current
            {
                get { return Current as object; }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_FirstCall)
                {
                    _Current = _First;
                    _FirstCall = false;
                    return _Current != null;
                }
                if (_Current != null)
                {
                    _Current = _Current.next;
                    return _Current != null;
                }
                return false;
            }

            public void Reset()
            {
                _Current = null;
                _FirstCall = true;
            }
        }

        // helper linked list class
        private class Node
        {
            public Item item;
            public Node next;
        }
    }
}