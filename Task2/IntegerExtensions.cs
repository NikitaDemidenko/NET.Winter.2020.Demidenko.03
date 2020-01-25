using System;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>Provides methods for integer extensions.</summary>
    public static class IntegerExtensions
    {
        /// <summary>
        ///   <para>Gets the GCD of two integer numbers.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when two numbers are zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByEuclidean(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"{int.MinValue} is out of range.");
            }

            int absA = Math.Abs(a);
            int absB = Math.Abs(b);
            return absA >= absB ? EuclideanAlgorithm(absA, absB) : EuclideanAlgorithm(absB, absA);
        }

        /// <summary>
        ///   <para>Gets the GCD of three integer numbers.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when three numbers are zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("Three numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"{int.MinValue} is out of range.");
            }

            int absA = Math.Abs(a);
            int absB = Math.Abs(b);
            int absC = Math.Abs(c);

            int temporaryResult = absA > absB ? EuclideanAlgorithm(absA, absB) : EuclideanAlgorithm(absB, absA);
            return absC > temporaryResult ? EuclideanAlgorithm(absC, temporaryResult) : EuclideanAlgorithm(temporaryResult, absC);
        }

        /// <summary>
        ///   <para>Gets the GCD of several integer numbers.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="numbers">Given numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are zero or less than two numbers was given.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByEuclidean(params int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("There are should be at least two parameters.");
            }

            var gcdsArray = new List<int>(numbers);
            bool hasAllZeroes = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException($"{int.MinValue} is out of range.");
                }

                gcdsArray[i] = Math.Abs(numbers[i]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    hasAllZeroes = false;
                    break;
                }
            }

            if (hasAllZeroes)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            gcdsArray.Sort();
            for (int i = 0; i < gcdsArray.Count - 1; i++)
            {
                if (gcdsArray[i] == 0)
                {
                    continue;
                }

                gcdsArray[i + 1] = EuclideanAlgorithm(gcdsArray[i + 1], gcdsArray[i]);
            }

            return gcdsArray[gcdsArray.Count - 1];
        }

        private static int EuclideanAlgorithm(int absA, int absB)
        {
            if (absA == 0)
            {
                return absB;
            }

            if (absB == 0)
            {
                return absA;
            }

            int remainder = absA - absB;
            while (remainder != 0)
            {
                int tmp = absB;
                absB = absA % absB;
                absA = tmp;
                remainder = absB;
            }

            return absA;
        }
    }
}
