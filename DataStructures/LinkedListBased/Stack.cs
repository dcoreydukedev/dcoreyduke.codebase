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
    /// The <c>Stack</c> class represents a last-in-first-out (LIFO) stack of generic items. It
    /// supports the usual <c>Push</c> and <c>Pop</c> operations, along with methods for peeking at
    /// the top item, testing if the stack is empty, and iterating through the items in LIFO order.
    /// This implementation uses a singly-linked list with a nested, non-static class Node and hence
    /// is the same as the <c>Stack</c> class in algs4.jar. The <c>Push</c>, <c>Pop</c>,
    /// <c>Peek</c>, <c>Count</c>, and <c>IsEmpty</c> operations all take constant time in the worst case.
    /// </summary>
    public class Stack<Item> : System.Collections.Generic.Stack<Item>, IEnumerable<Item>, IStack<Item>
    {
        private Node _First;
        private int _N;          // size of the stack
                                 // top of stack

        /// <summary>
        /// Initializes an empty stack.
        /// </summary>
        public Stack()
        {
            _First = null;
            _N = 0;
            Debug.Assert(Check());
        }

        /// <summary>
        /// Returns the number of items in the stack.
        /// </summary>
        /// <returns>the number of items in the stack</returns>
        public new int Count
        {
            get { return _N; }
        }

        /// <summary>
        /// Is this stack empty?
        /// </summary>
        /// <returns>true if this queue is empty; false otherwise</returns>
        public bool IsEmpty
        {
            get { return _First == null; }
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
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns (but does not remove) the item most recently added to this stack.
        /// </summary>
        /// <returns>the item most recently added to this stack</returns>
        /// <exception cref="InvalidOperationException">if this stack is empty</exception>
        public new Item Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Stack Underflow");
            return _First.item;
        }

        /// <summary>
        /// Removes and returns the item most recently added to this stack.
        /// </summary>
        /// <returns>the item most recently added</returns>
        /// <exception cref="InvalidOperationException">if this stack is empty</exception>
        public new Item Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Stack Underflow");
            Item item = _First.item;
            _First = _First.next;
            _N--;
            Debug.Assert(Check());
            return item;
        }

        /// <summary>
        /// Adds the item to this stack.
        /// </summary>
        /// <param name="item">item the item to add</param>
        public new void Push(Item item)
        {
            Node oldfirst = _First;
            _First = new Node
            {
                item = item,
                next = oldfirst
            };
            _N++;
            Debug.Assert(Check());
        }

        /// <summary>
        /// Returns a string representation of this stack.
        /// </summary>
        /// <returns>the sequence of items in the stack in LIFO order, separated by spaces</returns>
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
            // check a few properties of instance variable 'first'
            if (_N < 0)
            {
                return false;
            }
            if (_N == 0)
            {
                if (_First != null) return false;
            }
            else if (_N == 1)
            {
                if (_First == null) return false;
                if (_First.next != null) return false;
            }
            else
            {
                if (_First == null) return false;
                if (_First.next == null) return false;
            }

            // check internal consistency of instance variable N
            int numberOfNodes = 0;
            for (Node x = _First; x != null && numberOfNodes <= _N; x = x.next)
            {
                numberOfNodes++;
            }
            if (numberOfNodes != _N) return false;

            return true;
        }

        // an iterator, doesn't implement remove() since it's optional
        private class ListIEnumerator : IEnumerator<Item>
        {
            private readonly Stack<Item> _Stack = null;
            private Node _Current = null;
            private bool _FirstCall = true;

            public ListIEnumerator(Stack<Item> collection)
            {
                _Stack = collection;
            }

            public Item Current
            {
                get
                {
                    if (_Current == null)
                        throw new InvalidOperationException("Out of Bounds!");
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
                    _Current = _Stack._First;
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