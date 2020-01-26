using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task2
{
    /// <summary>Provides methods for integer extensions.</summary>
    public static class IntegerExtensions
    {
        /// <summary>
        ///   <para>Gets the GCD of two integer numbers using Euclidian algorithm.</para>
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
            return EuclideanAlgorithm(absA, absB);
        }

        /// <summary>
        ///   <para>Gets the GCD of three integer numbers using Euclidian algorithm.</para>
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

            int temporaryResult = EuclideanAlgorithm(absA, absB);
            return EuclideanAlgorithm(temporaryResult, absC);
        }

        /// <summary>
        ///   <para>Gets the GCD of several integer numbers using Euclidian algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="numbers">Given numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are zero or less than two numbers was given.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByEuclidean(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

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

        /// <summary>
        ///   <para>Gets the GCD of two integer numbers using Euclidian algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="time">Method's execution time in ticks.</param>
        /// <returns>Returns GCD of two numbers and method's execution time.</returns>
        /// <exception cref="ArgumentException">Thrown when two numbers are zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByEuclidean(int a, int b, out long time)
        {
            var timer = new Stopwatch();
            timer.Start();
            int result = GetGcdByEuclidean(a, b);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        ///   <para>Gets the GCD of three integer numbers using Euclidian algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <param name="time">Method's execution time in ticks.</param>
        /// <returns>Returns GCD of three numbers and method's execution time.</returns>
        /// <exception cref="ArgumentException">Thrown when three numbers are zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c, out long time)
        {
            var timer = new Stopwatch();
            timer.Start();
            int result = GetGcdByEuclidean(a, b, c);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        ///   <para>Gets the GCD of several integer numbers using Euclidian algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="time">Method's execution time in ticks.</param>
        /// <param name="numbers">Given numbers.</param>
        /// <returns>Returns GCD of several numbers and method's execution time.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are zero or less than two numbers was given.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByEuclidean(out long time, params int[] numbers)
        {
            var timer = new Stopwatch();
            timer.Start();
            int result = GetGcdByEuclidean(numbers);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        ///   <para>Gets the GCD of two integer numbers using Stein's algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Returns GCD of two numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when two numbers are zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByStein(int a, int b)
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
            return SteinsAlgorithm(absA, absB);
        }

        /// <summary>
        ///   <para>Gets the GCD of three integer numbers using Stein's algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>Returns GCD of three numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when three numbers are zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByStein(int a, int b, int c)
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

            int temporaryResult = SteinsAlgorithm(absA, absB);
            return SteinsAlgorithm(temporaryResult, absC);
        }

        /// <summary>
        ///   <para>Gets the GCD of several integer numbers using Stein's algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="numbers">Given numbers.</param>
        /// <returns>Returns GCD of several numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are zero or less than two numbers was given.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByStein(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

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

        /// <summary>
        ///   <para>Gets the GCD of two integer numbers using Stein's algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="time">Method's execution time in ticks.</param>
        /// <returns>Returns GCD of two numbers and method's execution time.</returns>
        /// <exception cref="ArgumentException">Thrown when two numbers are zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByStein(int a, int b, out long time)
        {
            var timer = new Stopwatch();
            timer.Start();
            int result = GetGcdByStein(a, b);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        ///   <para>Gets the GCD of three integer numbers using Stein's algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <param name="time">Method's execution time in ticks.</param>
        /// <returns>Returns GCD of three numbers and method's execution time.</returns>
        /// <exception cref="ArgumentException">Thrown when three numbers are zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByStein(int a, int b, int c, out long time)
        {
            var timer = new Stopwatch();
            timer.Start();
            int result = GetGcdByStein(a, b, c);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        ///   <para>Gets the GCD of several integer numbers using Stein's algorithm.</para>
        ///   <para>Valid interval (<em>int.MinValue, int.MaxValue</em>].</para>
        /// </summary>
        /// <param name="time">Method's execution time in ticks.</param>
        /// <param name="numbers">Given numbers.</param>
        /// <returns>Returns GCD of several numbers and method's execution time.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are zero or less than two numbers was given.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one argument is equals to <em>int.Minvalue</em>.</exception>
        public static int GetGcdByStein(out long time, params int[] numbers)
        {
            var timer = new Stopwatch();
            timer.Start();
            int result = GetGcdByStein(numbers);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
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

        private static int SteinsAlgorithm(int absA, int absB)
        {
            if (absA == 0)
            {
                return absB;
            }

            if (absB == 0)
            {
                return absA;
            }

            int shift;
            for (shift = 0; ((absA | absB) & 1) == 0; ++shift)
            {
                absA >>= 1;
                absB >>= 1;
            }

            while ((absA & 1) == 0)
            {
                absA >>= 1;
            }

            do
            {
                while ((absB & 1) == 0)
                {
                    absB >>= 1;
                }

                if (absA > absB)
                {
                    int t = absB;
                    absB = absA;
                    absA = t;
                }

                absB = absB - absA;
            }
            while (absB != 0);
            return absA << shift;
        }
    }
}
