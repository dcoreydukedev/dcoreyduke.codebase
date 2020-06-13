/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DCoreyDuke.CodeBase.DataStructures.LinkedListBased
{
    /// <summary>
    /// The <c>Queue</c> class represents a first-in-first-out (FIFO) queue of generic items. It
    /// supports the usual <c>Enqueue</c> and <c>Dequeue</c> operations, along with methods for
    /// peeking at the first item, testing if the queue is empty, and iterating through the items in
    /// FIFO order. This implementation uses a singly-linked list with a nested, non-static class
    /// Node. The <c>Enqueue</c>, <c>Dequeue</c>, <c>Peek</c>, <c>Count</c>, and <c>IsEmpty</c>
    /// operations all take constant time in the worst case.
    /// </summary>
    public class Queue<Item> : System.Collections.Generic.Queue<Item>, IEnumerable<Item>, IQueue<Item>
    {
        private Node _First;

        // beginning of queue
        private Node _Last;

        private int _N;         // number of elements on queue
                                // end of queue

        /// <summary>
        /// Initializes an empty queue.
        /// </summary>
        public Queue()
        {
            _First = null;
            _Last = null;
            _N = 0;
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
            get { return _First == null; }
        }

        /// <summary>
        /// Removes and returns the item on this queue that was least recently added.
        /// </summary>
        /// <returns>the item on this queue that was least recently added</returns>
        /// <exception cref="InvalidOperationException">if this queue is empty</exception>
        public new Item Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue underflow");
            Item item = _First.item;
            _First = _First.next;
            _N--;
            if (IsEmpty) _Last = null;   // to avoid loitering
            Debug.Assert(Check());
            return item;
        }

        /// <summary>
        /// Adds the item to this queue.
        /// </summary>
        /// <param name="item">item the item to add</param>
        public new void Enqueue(Item item)
        {
            Node oldlast = _Last;
            _Last = new Node
            {
                item = item,
                next = null
            };
            if (IsEmpty) _First = _Last;
            else oldlast.next = _Last;
            _N++;
            Debug.Assert(Check());
        }

        /// <summary>
        /// Returns an iterator that iterates over the items in this queue in FIFO order.
        /// </summary>
        /// <returns>an iterator that iterates over the items in this queue in FIFO order</returns>
        public new IEnumerator<Item> GetEnumerator()
        {
            return new ListIEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns the item least recently added to this queue.
        /// </summary>
        /// <returns>the item least recently added to this queue</returns>
        /// <exception cref="InvalidOperationException">if this queue is empty</exception>
        public new Item Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue underflow");
            return _First.item;
        }

        /// <summary>
        /// Returns a string representation of this queue.
        /// </summary>
        /// <returns>the sequence of items in FIFO order, separated by spaces</returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (Item item in this)
                s.Append(item + " ");
            return s.ToString();
        }

        // check internal invariants
        private bool Check()
        {
            if (_N < 0)
            {
                return false;
            }
            else if (_N == 0)
            {
                if (_First != null) return false;
                if (_Last != null) return false;
            }
            else if (_N == 1)
            {
                if (_First == null || _Last == null) return false;
                if (_First != _Last) return false;
                if (_First.next != null) return false;
            }
            else
            {
                if (_First == null || _Last == null) return false;
                if (_First == _Last) return false;
                if (_First.next == null) return false;
                if (_Last.next != null) return false;

                // check internal consistency of instance variable N
                int numberOfNodes = 0;
                for (Node x = _First; x != null && numberOfNodes <= _N; x = x.next)
                {
                    numberOfNodes++;
                }
                if (numberOfNodes != _N) return false;

                // check internal consistency of instance variable last
                Node lastNode = _First;
                while (lastNode.next != null)
                {
                    lastNode = lastNode.next;
                }
                if (_Last != lastNode) return false;
            }

            return true;
        }

        // an iterator, doesn't implement remove() since it's optional
        private class ListIEnumerator : IEnumerator<Item>
        {
            private readonly Queue<Item> _Queue = null;
            private Node _Current = null;
            private bool _FirstCall = true;

            public ListIEnumerator(Queue<Item> collection)
            {
                _Queue = collection;
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
                    _Current = _Queue._First;
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