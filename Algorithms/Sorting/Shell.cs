/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Diagnostics;

namespace DCoreyDuke.CodeBase.Algorithms.Sorting
{
    /// <summary>
    /// The <c>Shell</c> class provides static methods for sorting an array using ShellSort with
    /// Knuth's increment sequence (1, 4, 13, 40, ...).
    /// </summary>
    public class Shell
    {
        // This class should not be instantiated.
        private Shell() { }

        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// </summary>
        /// <param name="a">a the array to be sorted</param>
        public static void Sort(IComparable[] a)
        {
            int N = a.Length;

            // 3x+1 increment sequence: 1, 4, 13, 40, 121, 364, 1093, ...
            int h = 1;
            while (h < N / 3) h = 3 * h + 1;

            while (h >= 1)
            {
                // h-sort the array
                for (int i = h; i < N; i++)
                {
                    for (int j = i; j >= h && OrderHelper.Less(a[j], a[j - h]); j -= h)
                    {
                        OrderHelper.Exch(a, j, j - h);
                    }
                }
                Debug.Assert(IsHsorted(a, h));
                h /= 3;
            }
            Debug.Assert(OrderHelper.IsSorted(a));
        }

        /***************************************************************************
         *  Check if array is H sorted - useful for debugging.
         ***************************************************************************/

        // is the array h-sorted?
        private static bool IsHsorted(IComparable[] a, int h)
        {
            for (int i = h; i < a.Length; i++)
                if (OrderHelper.Less(a[i], a[i - h])) return false;
            return true;
        }
    }
}