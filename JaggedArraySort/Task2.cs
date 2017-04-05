using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySort
{
    /// <summary>
    /// Class for sorting jagged arrays
    /// using different comparising rules
    /// </summary>
    public static class Task2
    {
        /// <summary>
        /// method for sorting a jagged array
        /// using a bubble sort algorythm
        /// </summary>
        /// <param name="jaggedArray">Jagged array for sorting</param>
        /// <param name="comparer">Rule for comparison</param>
        public static void Sort(int[][] jaggedArray, IComparer comparer)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException(nameof(jaggedArray));

            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            for (int i = 0; i < jaggedArray.Length; i++)
                for (int j = 1; j < jaggedArray.Length - i; j++)
                    if (comparer.Compare(jaggedArray[j - 1], jaggedArray[j]) > 0)
                    {
                        Swap(ref jaggedArray[j - 1], ref jaggedArray[j]);                      
                    }            
        }

        /// <summary>
        /// swap elems
        /// </summary>
        /// <param name="first">first array</param>
        /// <param name="second">second array</param>
        private static void Swap(ref int[] first, ref int[] second)
        {
            int[] buff = first;
            first = second;
            second = buff;
        }
    }
}
