using System;
using System.Globalization;

namespace NumbersExtensions
{
    /// <summary>Provides number extensions methods.</summary>
    public static class NumbersExtension
    {
        private const int MinValueOfIndex = 0;
        private const int MaxValueOfIndex = 31;
        private const double Epsilon = 0.1;

        /// <summary>Inserts the number into another.</summary>
        /// <param name="numberSource">The source number.</param>
        /// <param name="numberIn">Number to insert.</param>
        /// <param name="rightIndex">Right position.</param>
        /// <param name="leftIndex">Left position.</param>
        /// <returns>Returns new number.</returns>
        /// <exception cref="ArgumentException">Thrown when rightIndex index is greater than leftIndex index.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when rightIndex index or leftIndex index are out of range.</exception>
        public static int InsertNumberIntoAnother(int numberSource, int numberIn, int rightIndex, int leftIndex)
        {
            if (rightIndex > leftIndex)
            {
                throw new ArgumentException($"Invalid arguments.");
            }

            if (rightIndex > MaxValueOfIndex || rightIndex < MinValueOfIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(rightIndex), "Invalid value.");
            }

            if (leftIndex > MaxValueOfIndex || leftIndex < MinValueOfIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(leftIndex), "Invalid value.");
            }

            if (rightIndex == MinValueOfIndex && leftIndex == MaxValueOfIndex)
            {
                return numberIn;
            }

            int mask = int.MaxValue;

            if (leftIndex == MaxValueOfIndex)
            {
                numberSource &= mask;
            }

            int numberSourceCopy = numberSource;
            numberSource >>= leftIndex + 1;
            numberSource <<= leftIndex + 1;
            int multiplierForZeroingLeftPart = mask >> (31 - rightIndex);
            numberSourceCopy &= multiplierForZeroingLeftPart;
            numberSource |= numberSourceCopy;
            multiplierForZeroingLeftPart = mask >> (31 - (leftIndex - rightIndex + 1));
            numberIn &= multiplierForZeroingLeftPart;
            numberIn <<= rightIndex;
            return numberSource | numberIn;
        }

        /// <summary>Determines whether the specified number is palindrome.</summary>
        /// <param name="number">Number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is palindrome; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when number is less than zero.</exception>
        public static bool IsPalindrome(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            string numberString = Convert.ToString(number, CultureInfo.InvariantCulture);
            int firstDigitIndex = 0;
            int lastDigitIndex = numberString.Length - 1;
            return IsPalindromeString(numberString, firstDigitIndex, lastDigitIndex);
        }

        /// <summary>Finds the Nth root.</summary>
        /// <param name="number">The number.</param>
        /// <param name="n">Root index.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns>Returns Nth root of given number.</returns>
        /// <exception cref="ArgumentException">Trown when <em>n </em>is less or equals zero<em>, accuracy </em>is out of range.</exception>
        /// <exception cref="ArithmeticException">Thrown when root index <em>n</em> is even and <em>number</em> is less than zero.</exception>
        public static double FindNthRoot(double number, int n, double accuracy)
        {
            if (number < 0 && n % 2 == 0)
            {
                throw new ArithmeticException($"Number should be greater or equals zero if {n} is even.");
            }

            if (n <= 0)
            {
                throw new ArgumentException($"{nameof(n)} should be positive.");
            }

            if (accuracy < 0 || accuracy > Epsilon)
            {
                throw new ArgumentException($"{nameof(accuracy)} should be in the range [0; {Epsilon}].");
            }

            if (number == 0.0)
            {
                return 0.0;
            }

            double current = number / 2;
            bool hasFound = false;
            while (!hasFound)
            {
                double next = (1.0 / n) * (((n - 1) * current) + (number / Math.Pow(current, n - 1)));
                if (Math.Abs(current - next) < accuracy)
                {
                    break;
                }

                current = next;
            }

            return current;
        }

        private static bool IsPalindromeString(string numberString, int leftIndex, int rightIndex)
        {
            return leftIndex >= rightIndex ?
                true : numberString[leftIndex] != numberString[rightIndex] ?
                    false : IsPalindromeString(numberString, leftIndex + 1, rightIndex - 1);
        }
    }
}
