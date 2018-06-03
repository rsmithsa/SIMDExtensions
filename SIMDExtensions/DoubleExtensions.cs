//-----------------------------------------------------------------------
// <copyright file="DoubleExtensions.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Runtime.CompilerServices;
    using System.Text;

    public static class DoubleExtensions
    {
        public static double[] Add(this double[] first, in double[] second)
        {
            ValidateParameters(first, second);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                AddSimdUnsafe(first, second, result);
            }
            else
            {
                AddFallback(first, second, result);
            }

            return result;
        }

        public static double[] AddAssign(this double[] first, in double[] second)
        {
            ValidateParameters(first, second);

            if (Vector.IsHardwareAccelerated)
            {
                AddSimdUnsafe(first, second, first);
            }
            else
            {
                AddFallback(first, second, first);
            }

            return first;
        }

        public static void AddFallback(in double[] first, in double[] second, in double[] result)
        {
            for (int i = 0; i < first.Length; i++)
            {
                result[i] = first[i] + second[i];
            }
        }

        public static void AddSimd(in double[] first, in double[] second, in double[] result)
        {
            int i = 0;
            int vectorizedLength = first.Length - Vector<double>.Count;

            for (; i <= vectorizedLength; i += Vector<double>.Count)
            {
                var sum = new Vector<double>(first, i) + new Vector<double>(second, i);
                sum.CopyTo(result, i);
            }

            for (; i < first.Length; i++)
            {
                result[i] = first[i] + second[i];
            }
        }

        public static unsafe void AddSimdUnsafe(in double[] first, in double[] second, in double[] result)
        {
            int i = 0;
            int vectorizedLength = first.Length - Vector<double>.Count;

            fixed (double* pFirst = first, pSecond = second, pResult = result)
            {
                for (; i <= vectorizedLength; i += Vector<double>.Count)
                {
                    var sum = Unsafe.Read<Vector<double>>(pFirst + i) + Unsafe.Read<Vector<double>>(pSecond + i);
                    Unsafe.Write(pResult + i, sum);
                }
            }

            for (; i < first.Length; i++)
            {
                result[i] = first[i] + second[i];
            }
        }

        private static void ValidateParameters<T>(T[] first, T[] second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            if (first.Length != second.Length)
            {
                throw new ArgumentException("Array length's must be the same.");
            }
        }
    }
}
