using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static JaggedArraySort.Task2;
using JaggedArraySort;
using System.Threading.Tasks;
using System.Collections;

namespace JaggedArrayTests
{
    [TestFixture]
    public class TestTask2
    {
#region NullTest
        [Test]
        public static void OrderBySumAscend_NullTest()
        {
            IComparer<int[]> comp = new OrderBySumAscend();
            Assert.Throws<ArgumentNullException>(() => Sort(null, comp.Compare));
        }

        [Test]
        public static void OrderBySumDescend_NullTest()
        {
            Assert.Throws<ArgumentNullException>(() => Sort(null, new OrderBySumDescend()));
        }

        [Test]
        public void OrderByMaxElemAscend_NullTest()
        {
            Assert.Throws<ArgumentNullException>(() => Sort(null, new OrderByMaxElemAscend()));
        }

        [Test]
        public void OrderByMaxElemDescend_NullTest()
        {
            Assert.Throws<ArgumentNullException>(() => Sort(null, new OrderByMaxElemDescend()));
        }
        #endregion

#region Tests
        [Test]
        public static void OrderBySumAscend_Test()
        {
            int[][] array = {
                new[] { 1, 2, 3, 4, 5, 7 },
                new[] { 1, -2, -3 },
                new[] { 2, 2, -1, -9, 7, -1, 4 } };

            int[][] testArray = {
                new[] { 1, -2, -3 },
                new[] { 2, 2, -1, -9, 7, -1, 4 },
                new[] { 1, 2, 3, 4, 5, 7 } };

            IComparer<int[]> comp = new OrderBySumAscend();
            Sort(array, comp.Compare);
            Assert.AreEqual(array, testArray);
        }

        [Test]
        public static void OrderBySumDescend_Test()
        {
            int[][] array = {
                new[] { 1, 2, 3, 4, 5, 7 },
                new[] { 2, 2, -1, -9, 7, -1, 4 },
                new[] { 1, -2, -3 } };

            int[][] testArray = {
                new[] { 1, 2, 3, 4, 5, 7 },
                new[] { 2, 2, -1, -9, 7, -1, 4 },
                new[] { 1, -2, -3 } };

            Sort(array, new OrderBySumDescend());
            Assert.AreEqual(array, testArray);
        }

        [Test]
        public void OrderByMaxElemAscend_Test()
        {
            int[][] array = {
                new[] { 1, 2, 3, 4, 5, 7 },
                new[] { 2, 2, -1, -9, 7, -1, 10 },
                new[] { 1, -2, -3 } };

            int[][] testArray = {
                new[] { 1, -2, -3 },
                new[] { 1, 2, 3, 4, 5, 7 },
                new[] { 2, 2, -1, -9, 7, -1, 10 } };

            Sort(array, new OrderByMaxElemAscend());
            Assert.AreEqual(array, testArray);
        }

        

        [Test]
        public void OrderByMaxElemDescend_Test()
        {
            int[][] array = {
                new[] { 1, 2, 3, 4, 5, 7 },
                new[] { 2, 2, -1, -9, 7, -1, 10 },
                new[] { 1, -2, -3 } };

            int[][] testArray = {
                new[] { 2, 2, -1, -9, 7, -1, 10 },
                new[] { 1, 2, 3, 4, 5, 7 },
                new[] { 1, -2, -3 } };

            Sort(array, new OrderByMaxElemDescend());
            Assert.AreEqual(array, testArray);
        }

        #endregion
    }
}