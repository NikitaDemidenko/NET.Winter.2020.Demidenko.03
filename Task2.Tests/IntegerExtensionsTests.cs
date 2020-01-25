using System;
using NUnit.Framework;
using static Task2.IntegerExtensions;

namespace Task2.Tests
{
    public class IntegerExtensionsTests
    {
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(12, 60, ExpectedResult = 12)]
        [TestCase(2672, 5678, ExpectedResult = 334)]
        [TestCase(10927782, 6902514, ExpectedResult = 846)]
        [TestCase(1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(-1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-10234562, -7872334, ExpectedResult = 2)]
        [TestCase(1590771464, -1590771620, ExpectedResult = 4)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        [Order(1)]
        public int GcdByEuclideanTests_WithTwoNumbers(int a, int b) => GetGcdByEuclidean(a, b);

        
        [Timeout(3000)]
        [Order(3)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        [TestCase(0, 0, -1, ExpectedResult = 1)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(100, 60, 40, ExpectedResult = 20)]
        public int GcdByEuclideanTests_WithThreeNumbers(int a, int b, int c) => GetGcdByEuclidean(a, b, c);

        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue, ExpectedResult = 1)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue, ExpectedResult = 1)]
        [TestCase(-10, 35, 90, 55, -105, ExpectedResult = 5)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue, ExpectedResult = 1)]
        [TestCase(0, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(18, 3, 9, 6, ExpectedResult = 3)]
        [TestCase(0, 0, 1, 0, ExpectedResult = 1)]
        [Timeout(3000)]
        [Order(4)]
        public int GcdByEuclideanTests_ManyNumbers(params int[] numbers) => GetGcdByEuclidean(numbers);

        [TestCase(int.MaxValue, int.MinValue + 1, ExpectedResult = int.MaxValue)]
        [Property("Mark", 2)]
        [Timeout(10000)]
        [Order(5)]
        public int GcdByEuclideanTest_WithMaxAndMinIntegerNumbers(int a, int b) => GetGcdByEuclidean(a, b);

        [Test, Order(2)]
        public void GcdByEuclideanTest_WithAllZeroNumbers_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetGcdByEuclidean(0, 0),
                "All numbers cannot be 0 at the same time.");

        [Test]
        public void GcdByEuclideanTest_WithOneParameter_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetGcdByEuclidean(24));

        [Test]
        public void GcdByEuclideanTest_WithIntMinValue_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GetGcdByEuclidean(25, int.MinValue));

        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue)]
        [TestCase(-10, 35, 90, 55, -105)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(0, 1, 0, 0)]
        [TestCase(18, 3, 9, 6)]
        [TestCase(0, 0, 1, 0)]
        [Timeout(3000)]
        public void GcdByEuclideanTests_WithTime(params int[] numbers)
        {
            _ = GetGcdByEuclidean(out long time, numbers);
            Assert.That(time > 1);
        }
    }
}