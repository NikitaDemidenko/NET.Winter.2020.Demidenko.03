using System;
using NUnit.Framework;
using static Task2.IntegerExtensions;

namespace Task2.Tests
{
    public class IntegerExtensionsTests
    {
        #region GDC Euclidian algorithm tests

        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(12, 60, ExpectedResult = 12)]
        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(2672, 5678, ExpectedResult = 334)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        [TestCase(10927782, 6902514, ExpectedResult = 846)]
        [TestCase(-10234562, -7872334, ExpectedResult = 2)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        [TestCase(1590771464, -1590771620, ExpectedResult = 4)]
        [TestCase(-1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        public int GcdByEuclideanTests_WithTwoNumbers(int a, int b) => GetGcdByEuclidean(a, b);

        
        [Timeout(3000)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(0, 0, -1, ExpectedResult = 1)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        public int GcdByEuclideanTests_WithThreeNumbers(int a, int b, int c) => GetGcdByEuclidean(a, b, c);

        [Timeout(3000)]
        [TestCase(0, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 0, ExpectedResult = 1)]
        [TestCase(18, 3, 9, 6, ExpectedResult = 3)]
        [TestCase(-10, 35, 90, 55, -105, ExpectedResult = 5)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue, ExpectedResult = 1)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue, ExpectedResult = 1)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue, ExpectedResult = 1)]
        public int GcdByEuclideanTests_ManyNumbers(params int[] numbers) => GetGcdByEuclidean(numbers);

        [Property("Mark", 2)]
        [Timeout(10000)]
        [TestCase(int.MaxValue, int.MinValue + 1, ExpectedResult = int.MaxValue)]
        public int GcdByEuclideanTest_WithMaxAndMinIntegerNumbers(int a, int b) => GetGcdByEuclidean(a, b);

        [Test]
        public void GcdByEuclideanTest_WithTwoZeroNumbers_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetGcdByEuclidean(0, 0),
                "Two numbers cannot be 0 at the same time.");

        [Test]
        public void GcdByEuclideanTest_WithAllZeroNumbers_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetGcdByEuclidean(0, 0, 0, 0, 0, 0, 0),
                "All numbers cannot be 0 at the same time.");

        [Test]
        public void GcdByEuclideanTest_WithOneParameter_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetGcdByEuclidean(24));

        [Test]
        public void GcdByEuclideanTest_WithIntMinValue_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GetGcdByEuclidean(25, int.MinValue));

        [Timeout(3000)]
        [TestCase(0, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 0, ExpectedResult = 1)]
        [TestCase(18, 3, 9, 6, ExpectedResult = 3)]
        [TestCase(-10, 35, 90, 55, -105, ExpectedResult = 5)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue, ExpectedResult = 1)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue, ExpectedResult = 1)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue, ExpectedResult = 1)]
        public void GcdByEuclideanTests_WithTime(params int[] numbers)
        {
            _ = GetGcdByEuclidean(out long time, numbers);
            Assert.That(time > 1);
        }

        #endregion

        #region GDC Euclidian algorithm tests

        [Test]
        public void GcdBySteinTest_WithAllZeroNumbers_ThrowArgumentException() =>
           Assert.Throws<ArgumentException>(() => GetGcdByStein(0, 0),
               "All numbers cannot be 0 at the same time.");

        [Test]
        public void GcdBySteinTest_WithOneParameter_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetGcdByStein(24));

        [Test]
        public void GcdBySteinTest_WithIntMinValue_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GetGcdByStein(25, int.MinValue));

        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        [TestCase(-10234562, -7872334, ExpectedResult = 2)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        [TestCase(1590771464, -1590771620, ExpectedResult = 4)]
        [TestCase(-1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        public int GcdBySteinTests_WithTwoNumbers(int a, int b) => GetGcdByEuclidean(a, b);

        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        public int GcdBySteinTests_WithThreeNumbers(int a, int b, int c) => GetGcdByEuclidean(a, b, c);

        [Timeout(3000)]
        [TestCase(0, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 0, ExpectedResult = 1)]
        [TestCase(18, 3, 9, 6, ExpectedResult = 3)]
        [TestCase(-10, 35, 90, 55, -105, ExpectedResult = 5)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue, ExpectedResult = 1)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue, ExpectedResult = 1)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue, ExpectedResult = 1)]
        public int GcdBySteinTests_ManyNumbers(params int[] numbers) => GetGcdByEuclidean(numbers);

        [Timeout(3000)]
        [TestCase(0, 1, 0, 0)]
        [TestCase(0, 0, 1, 0)]
        [TestCase(18, 3, 9, 6)]
        [TestCase(-10, 35, 90, 55, -105)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        public void GcdBySteinTests_WithTime(params int[] numbers)
        {
            _ = GetGcdByEuclidean(out long time, numbers);
            Assert.That(time > 1);
        }

        #endregion
    }
}