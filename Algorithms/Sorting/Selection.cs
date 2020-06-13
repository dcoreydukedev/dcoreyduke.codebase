/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.Algorithms.Sorting
{
    /// <summary>
    /// The <c>Selection</c> class provides static methods for sorting an array using selection sort.
    /// </summary>
    public class Selection
    {
        // This class should not be instantiated.
        private Selection() { }

        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// </summary>
        /// <param name="a">a the array to be sorted</param>
        public static void Sort(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int min = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (OrderHelper.Less(a[j], a[min])) min = j;
                }
                OrderHelper.Exch(a, i, min);
                Debug.Assert(OrderHelper.IsSorted(a, 0, i));
            }
            Debug.Assert(OrderHelper.IsSorted(a));
        }

        /// <summary>
        /// Rearranges the array in ascending order, using a comparator.
        /// </summary>
        /// <param name="a">a the array</param>
        /// <param name="c">c the comparator specifying the order</param>
        public static void Sort<T>(T[] a, Comparer<T> c)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int min = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (OrderHelper.Less<T>(a[j], a[min], c)) min = j;
                }
                OrderHelper.Exch(a, i, min);
                Debug.Assert(OrderHelper.IsSorted(a, 0, i, c));
            }
            Debug.Assert(OrderHelper.IsSorted(a, c));
        }
    }
}