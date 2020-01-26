using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using static ArrayManipulation.ArrayExtension;

namespace ArrayManipulation.Tests
{
    public class ArrayExtensionTestsDataSource : IEnumerable
    {
        public int[] GetRandomArray(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            int[] array = Enumerable.Range(0, length - 1).ToArray();
            return array;
        }

        public IEnumerator GetEnumerator()
        {
            yield return GetRandomArray(557576);
            yield return GetRandomArray(1000000);
            yield return GetRandomArray(20000000);
        }
    }

    [TestFixture]
    public class ArrayExtensionTests
    {
        #region FindBalanceIndexTests

        [Test]
        public void FindBalanceIndex_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FindBalanceIndex(null));
        }

        [TestCase(new int[] { 1, 2, 5, 8, 0, 2, 4, 6, 4 }, ExpectedResult = 4)]
        [TestCase(new int[] { -32, 8, 1, 2, 4, 5, 12, -3, 0 }, ExpectedResult = 7)]
        [TestCase(new int[] { 2, 0, 5, 14, 3 }, ExpectedResult = null)]
        [TestCase(new int[] { }, ExpectedResult = null)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { -1, 1, -1, 1, -1, 1, 32 }, ExpectedResult = null)]
        [TestCase(new int[] { 1 }, ExpectedResult = null)]
        [TestCase(new int[] { 1, 2, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = null)]
        [TestCase(new int[] { -1, 2, 3, 1 }, ExpectedResult = 2)]
        [TestCase(new int[] { 100, -1, 50, -1, 100 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = 5)]
        [TestCase(new int[] { 1, 2, 1, 50000 }, ExpectedResult = null)]
        [TestCase(new int[] { int.MinValue, int.MinValue, 50, int.MinValue, int.MinValue }, ExpectedResult = 2)]
        public int? FindBalanceIndexTests(int[] array)
        {
            return FindBalanceIndex(array);
        }

        #endregion

        #region FindMaximumItemTests

        [Test]
        public void FindMaximumItem_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((() => FindMaximumItem(null)));
        }

        [Test]
        public void FindMaximumItem_ArrayIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>((() => FindMaximumItem(new int[] { })));
        }

        [TestCase(new int[] {1, 2, 5, 8, 0, 2, 4, 6, 4}, ExpectedResult = 8)]
        [TestCase(new int[] {-32, 8, 1, 2, 4, 5, 12, -3, 0}, ExpectedResult = 12)]
        [TestCase(new int[] {2, 0, 5, 14, 3}, ExpectedResult = 14)]
        [TestCase(new int[] {0, 0, 0, 0, 0, 0}, ExpectedResult = 0)]
        [TestCase(new int[] {-1, 1, -1, 1, -1, 1, 32}, ExpectedResult = 32)]
        [TestCase(new int[] {1}, ExpectedResult = 1)]
        public int FindMaximumItemTests(int[] array)
        {
            return FindMaximumItem(array);
        }

        [TestCaseSource(typeof(ArrayExtensionTestsDataSource))]
        [Timeout(1000)]
        public void FindMaximumItem_BigArraysTests(int[] array)
        {
            int expected = array[array.Length - 1];

            int actual = FindMaximumItem(array);

            Assert.That(actual == expected);
        }
        #endregion
    }
}