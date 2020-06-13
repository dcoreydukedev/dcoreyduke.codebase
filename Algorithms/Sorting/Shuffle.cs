/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using DCoreyDuke.CodeBase;

namespace DCoreyDuke.CodeBase.Algorithms.Sorting
{
    public sealed class Shuffler
    {
        /// <summary>
        /// Rearranges the elements of the specified array in uniformly random order.
        /// </summary>
        /// <param name="a">a the array to shuffle</param>
        /// <exception cref="ArgumentNullException">if <c>a</c> is <c>null</c></exception>
        public static void Shuffle(Object[] a)
        {
            if (a == null) throw new ArgumentNullException("argument array is null");
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + RandomNumberGenerator.Uniform(n - i);     // between i and n-1
                Object temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        /// <summary>
        /// Rearranges the elements of the specified array in uniformly random order.
        /// </summary>
        /// <param name="a">a the array to shuffle</param>
        /// <exception cref="ArgumentNullException">if <c>a</c> is <c>null</c></exception>
        public static void Shuffle(double[] a)
        {
            if (a == null) throw new ArgumentNullException("argument array is null");
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + RandomNumberGenerator.Uniform(n - i);     // between i and n-1
                double temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        /// <summary>
        /// Rearranges the elements of the specified array in uniformly random order.
        /// </summary>
        /// <param name="a">a the array to shuffle</param>
        /// <exception cref="ArgumentNullException">if <c>a</c> is <c>null</c></exception>
        public static void Shuffle(int[] a)
        {
            if (a == null) throw new ArgumentNullException("argument array is null");
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + RandomNumberGenerator.Uniform(n - i);     // between i and n-1
                int temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        /// <summary>
        /// Rearranges the elements of the specified subarray in uniformly random order.
        /// </summary>
        /// <param name="a">a the array to shuffle</param>
        /// <param name="lo">lo the left endpoint (inclusive)</param>
        /// <param name="hi">hi the right endpoint (inclusive)</param>
        /// <exception cref="ArgumentNullException">if <c>a</c> is <c>null</c></exception>
        /// <exception cref="IndexOutOfRangeException">
        /// unless <c>(0 &lt;= lo) and (lo &lt;= hi) and (hi &lt; a.Length)</c>
        /// </exception>
        public static void Shuffle(Object[] a, int lo, int hi)
        {
            if (a == null) throw new ArgumentNullException("argument array is null");
            if (lo < 0 || lo > hi || hi >= a.Length)
            {
                throw new IndexOutOfRangeException("Illegal subarray range");
            }
            for (int i = lo; i <= hi; i++)
            {
                int r = i + RandomNumberGenerator.Uniform(hi - i + 1);     // between i and hi
                Object temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        /// <summary>
        /// Rearranges the elements of the specified subarray in uniformly random order.
        /// </summary>
        /// <param name="a">a the array to shuffle</param>
        /// <param name="lo">lo the left endpoint (inclusive)</param>
        /// <param name="hi">hi the right endpoint (inclusive)</param>
        /// <exception cref="ArgumentNullException">if <c>a</c> is <c>null</c></exception>
        /// <exception cref="ArgumentNullException">
        /// unless <c>(0 &lt;= lo) and (lo &lt;= hi) and (hi &lt; a.Length)</c>
        /// </exception>
        public static void Shuffle(double[] a, int lo, int hi)
        {
            if (a == null) throw new ArgumentNullException("argument array is null");
            if (lo < 0 || lo > hi || hi >= a.Length)
            {
                throw new ArgumentNullException("Illegal subarray range");
            }
            for (int i = lo; i <= hi; i++)
            {
                int r = i + RandomNumberGenerator.Uniform(hi - i + 1);     // between i and hi
                double temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        /// <summary>
        /// Rearranges the elements of the specified subarray in uniformly random order.
        /// </summary>
        /// <param name="a">a the array to shuffle</param>
        /// <param name="lo">lo the left endpoint (inclusive)</param>
        /// <param name="hi">hi the right endpoint (inclusive)</param>
        /// <exception cref="ArgumentNullException">if <c>a</c> is <c>null</c></exception>
        /// <exception cref="IndexOutOfRangeException">
        /// unless <c>(0 &lt;= lo) and (lo &lt;= hi) and (hi &lt; a.Length)</c>
        /// </exception>
        public static void Shuffle(int[] a, int lo, int hi)
        {
            if (a == null) throw new ArgumentNullException("argument array is null");
            if (lo < 0 || lo > hi || hi >= a.Length)
            {
                throw new IndexOutOfRangeException("Illegal subarray range");
            }
            for (int i = lo; i <= hi; i++)
            {
                int r = i + RandomNumberGenerator.Uniform(hi - i + 1);     // between i and hi
                int temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }
    }
}