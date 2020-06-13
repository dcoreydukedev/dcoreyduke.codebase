/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DCoreyDuke.CodeBase.Algorithms.Sorting
{
    /// <summary> The <c>Insertion</c> class provides static methods for sorting an array using
    /// insertion sort. This implementation makes ~ 1/2 N^2 compares and OrderHelper.Exchanges in
    /// the worst case, so it is not suitable for sorting large arbitrary arrays. More precisely,
    /// the number of OrderHelper.Exchanges is exactly equal to the number of inversions. So, for
    /// example, it sorts a partially-sorted array in linear time. The sorting algorithm is stable
    /// and uses O(1) extra memory.
    public class Insertion
    {
        // This class should not be instantiated.
        private Insertion() { }

        /// <summary>
        /// Returns a permutation that gives the elements in the array in ascending order, while not
        /// changing the original array a[]
        /// </summary>
        /// <param name="a">a the array</param>
        /// <returns>
        /// a permutation <c>p[]</c> such that <c>a[p[0]]</c>, <c>a[p[1]]</c>, ..., <c>a[p[N-1]]</c>
        /// are in ascending order
        /// </returns>
        public static int[] IndexSort(int[] a)
        {
            int N = a.Length;
            int[] index = new int[N];
            for (int i = 0; i < N; i++)
                index[i] = i;

            for (int i = 0; i < N; i++)
                for (int j = i; j > 0 && OrderHelper.Less(a[index[j]], a[index[j - 1]]); j--)
                    OrderHelper.Exch(index, j, j - 1);

            return index;
        }

        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// </summary>
        /// <param name="a">a the array to be sorted</param>
        public static void Sort(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                for (int j = i; j > 0 && OrderHelper.Less(a[j], a[j - 1]); j--)
                {
                    OrderHelper.Exch(a, j, j - 1);
                }
                Debug.Assert(OrderHelper.IsSorted(a, 0, i));
            }
            Debug.Assert(OrderHelper.IsSorted(a));
        }

        /// <summary>
        /// Rearranges the subarray a[lo..hi] in ascending order, using the natural order.
        /// </summary>
        /// <param name="a">a the array to be sorted</param>
        /// <param name="lo">lo left endpoint</param>
        /// <param name="hi">hi right endpoint</param>
        public static void Sort(IComparable[] a, int lo, int hi)
        {
            for (int i = lo; i <= hi; i++)
            {
                for (int j = i; j > lo && OrderHelper.Less(a[j], a[j - 1]); j--)
                {
                    OrderHelper.Exch(a, j, j - 1);
                }
            }
            Debug.Assert(OrderHelper.IsSorted(a, lo, hi));
        }

        /// <summary>
        /// Rearranges the array in ascending order, using a comparator.
        /// </summary>
        /// <param name="a">a the array</param>
        /// <param name="comparator">comparator the comparator specifying the order</param>
        public static void Sort(object[] a, System.Collections.Comparer comparator)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                for (int j = i; j > 0 && OrderHelper.Less(a[j], a[j - 1], comparator); j--)
                {
                    OrderHelper.Exch(a, j, j - 1);
                }
                Debug.Assert(OrderHelper.IsSorted(a, 0, i, comparator));
            }
            Debug.Assert(OrderHelper.IsSorted(a, comparator));
        }

        /// <summary>
        /// Rearranges the subarray a[lo..hi] in ascending order, using a generic comparator.
        /// </summary>
        /// <param name="a">a the array</param>
        /// <param name="lo">lo left endpoint</param>
        /// <param name="hi">hi right endpoint</param>
        /// <param name="comparator">comparator the comparator specifying the order</param>
        public static void Sort<T>(T[] a, int lo, int hi, Comparer<T> comparator)
        {
            for (int i = lo; i <= hi; i++)
            {
                for (int j = i; j > lo && OrderHelper.Less(a[j], a[j - 1], comparator); j--)
                {
                    OrderHelper.Exch<T>(a, j, j - 1);
                }
            }
            Debug.Assert(OrderHelper.IsSorted(a, lo, hi, comparator));
        }
    }
}