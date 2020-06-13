/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCoreyDuke.CodeBase.Algorithms.Sorting
{
    /// <summary> The <c>Knuth</c> class provides a client for reading in a sequence of strings and
    /// <c>Shuffling</c> them using the Knuth (or Fisher-Yates) shuffling algorithm. This algorithm
    /// guarantees to rearrange the elements in uniformly random order, under the assumption that
    /// Math.random() generates independent and uniformly distributed numbers between 0 and 1.
    public class Knuth
    {
        // this class should not be instantiated
        private Knuth() { }

        /// <summary>
        /// Rearranges an array of objects in uniformly random order (under the assumption that
        /// <c>Math.random()</c> generates independent and uniformly distributed numbers between 0
        /// and 1).
        /// </summary>
        /// <param name="a">the array to be shuffled</param>
        public static void Shuffle(object[] a)
        {
            int N = a.Length;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < N; i++)
            {
                // choose index uniformly in [i, N-1]
                int r = rnd.Next(i, N);
                object swap = a[r];
                a[r] = a[i];
                a[i] = swap;
            }
        }
    }
}