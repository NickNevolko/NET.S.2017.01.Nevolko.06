using System;
using JaggedArraySort;
using static JaggedArraySort.Task2;
using System.Linq;

namespace JaggedArrayTests
{

    public class OrderBySumAscend : IComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Sum() > array2.Sum()) return 1;
            else return -1;

        }
    }

    public class OrderBySumDescend : IComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Sum() < array2.Sum()) return 1;
            else return -1;
        }
    }

    public class OrderByMaxElemAscend : IComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Max() > array2.Max()) return 1;
            else return -1;
        }
    }

    public class OrderByMaxElemDescend : IComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Max() < array2.Max()) return 1;
            else return -1;
        }
    }

}