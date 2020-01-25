using System;

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
        public static int GetGcd(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"{int.MinValue} is out of range.");
            }

            if (a == 0)
            {
                return Math.Abs(b);
            }

            if (b == 0)
            {
                return Math.Abs(a);
            }

            int absA = Math.Abs(a);
            int absB = Math.Abs(b);
            return absA >= absB ? EuclideanAlgorithm(absA, absB) : EuclideanAlgorithm(absB, absA);
        }

        private static int EuclideanAlgorithm(int absA, int absB)
        {
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
