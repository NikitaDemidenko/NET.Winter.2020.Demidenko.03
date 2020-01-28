using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using NUnit.Framework;
using static NumbersExtensions.NumbersExtension;

namespace NumbersExtensions.Tests
{
    public class NumbersExtensionTests
    {
        private static IConfigurationRoot ConfigurationRoot { get; } =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        [SetUp]
        public void Setup()
        {
            try
            {
                AppSettings.Epsilon = double.Parse(ConfigurationRoot["Epsilon"]);
            }
            catch
            {
                AppSettings.Epsilon = 0.1;
            }
        }

        #region InsertNumberIntoAnotherTests

        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(-7, 2, 31,31, ExpectedResult = 2147483641)]
        public int InsertNumberIntoAnother_WithAllValidParameters(int numberSource, int numberIn, int i, int j) =>
            InsertNumberIntoAnother(numberSource, numberIn, i, j);

        [Test]
        public void InsertNumberIntoAnother_I_GreaterThan_J_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => InsertNumberIntoAnother(123, 12, 13, 8), "i cannot be greater than j.");

        [Test]
        public void InsertNumberIntoAnother_I_Or_J_OutOfRange_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumberIntoAnother(12, 2, 0, 32));

        #endregion

        #region IsPalindromeTests

        [Test]
        public void IsPalindrome_NumberLessThanZero_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => IsPalindrome(-12321));

        [TestCase(123021, ExpectedResult = false)]
        [TestCase(345543, ExpectedResult = true)]
        [TestCase(1615201561, ExpectedResult = false)]
        [TestCase(int.MaxValue, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = true)]
        [TestCase(33333333, ExpectedResult = true)]
        [TestCase(909909, ExpectedResult = true)]
        public bool IsPalindromeTests(int number) => IsPalindrome(number);

        [Test]
        [Order(2)]
        [Timeout(500)]
        public void PossiblyVerySlowCode_WithTimeLessThan1000Milliseconds()
        {
            for (int source = 0; source < 1_000_000; source++)
            {
                IsPalindrome(source);
            }
        }

        [Test]
        [Order(1)]
        [Timeout(2_000)]
        public void PossiblyVerySlowCode_WithTimeLessThan25000Milliseconds()
        {
            for (int source = 0; source < 10_000_000; source++)
            {
                IsPalindrome(source);
            }
        }

        #endregion

        #region FindNthRootTests

        [Test]
        public void FindNthRoot_NegativeNumberAndEvenDegree_ThrowArgumentException() => 
            Assert.Throws<ArithmeticException>(() => FindNthRoot(-14.4, 2, 0.001));

        [Test]
        public void FindNthRoot_N_Is_Zero_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => FindNthRoot(16, 0, 0.001));

        [Test]
        public void FindNthRoot_N_LessThanZero_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => FindNthRoot(198, -2, 0.001));

        [Test]
        public void FindNthRoot_AccuracyOutOfRange_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => FindNthRoot(2048, 11, 1));

        [TestCase(0, 234, 0.00001, 0)]
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.064, 3, 0.1, 0.4)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        [TestCase(0.00000001, 2, 0.0000001, 0.0001)]
        public void FindNthRoot_WithAllValidParameters(double number, int n, double accuracy, double result)
        {
            Assert.AreEqual(result, FindNthRoot(number, n, accuracy), accuracy);
        }

        #endregion
    }
}