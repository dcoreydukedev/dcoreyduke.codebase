/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.DataStructures.ResizingArrayBased
{
    /// <summary> The <c>Stack</c> class represents a (LIFO) stack of generic items. It supports the
    /// usual <c>Push</c> and <c>Pop</c> operations, along with methods for peeking at the top item,
    /// testing if the stack is empty, and iterating through the items in LIFO order.</para>
    /// <para>This implementation uses a resizing array, which double the underlying array when it
    /// is full and halves the underlying array when it is one-quarter full. The <c>Push</c> and
    /// <c>Pop</c> operations take constant amortized time, whereas he <c>Count</c>, <c>Peek</c>,
    /// and <c>IsEmpty</c> operations takes constant time in the worst case. </summary>
    public class Stack<Item> : System.Collections.Generic.Stack<Item>, IEnumerable<Item>, IStack<Item>
    {
        private Item[] _A;         // array of items
        private int _N;            // number of elements on stack

        /// <summary>
        /// Initializes an empty stack.
        /// </summary>
        public Stack()
        {
            _A = new Item[2];
            _N = 0;
        }

        /// <summary>
        /// Returns the number of items in the stack.
        /// </summary>
        public new int Count
        {
            get { return _N; }
        }

        /// <summary>
        /// Is this stack empty?
        /// </summary>
        /// <returns>true if this stack is empty; false otherwise</returns>
        public bool IsEmpty
        {
            get { return _N == 0; }
        }

        /// <summary>
        /// Returns an iterator to this stack that iterates through the items in LIFO order.
        /// </summary>
        /// <returns>the iterator in LIFO order</returns>
        public new IEnumerator<Item> GetEnumerator()
        {
            int i;
            for (i = _N - 1; i >= 0; i--) yield return _A[i];
        }

        // place holder method to comply to interface implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            int i;
            for (i = _N - 1; i >= 0; i--) yield return _A[i];
        }

        /// <summary>
        /// Returns (but does not remove) the item most recently added to this stack.
        /// </summary>
        /// <returns>the item most recently added</returns>
        /// <exception cref="InvalidOperationException">if the stack is empty</exception>
        public new Item Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Stack underflow");
            return _A[_N - 1];
        }

        /// <summary>
        /// Removes and returns the item most recently added to this stack.
        /// </summary>
        /// <returns>the item most recently added</returns>
        /// <exception cref="InvalidOperationException">if the stack is empty</exception>
        public new Item Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Stack underflow");
            Item item = _A[_N - 1];
            // to avoid loitering for reference types
            _A[_N - 1] = default;
            _N--;
            // shrink size of array if necessary
            if (_N > 0 && _N == _A.Length / 4) Resize(_A.Length / 2);
            return item;
        }

        /// <summary>
        /// Adds the item to this stack.
        /// </summary>
        /// <param name="item">the item to add</param>
        public new void Push(Item item)
        {
            if (_N == _A.Length) Resize(2 * _A.Length);  // double size of array if necessary
            _A[_N++] = item;                            // add item
        }

        // resize the underlying array holding the elements
        private void Resize(int capacity)
        {
            System.Diagnostics.Debug.Assert(capacity >= _N);

            Item[] temp = new Item[capacity];
            for (int i = 0; i < _N; i++)
            {
                temp[i] = _A[i];
            }
            _A = temp;
        }
    }
}