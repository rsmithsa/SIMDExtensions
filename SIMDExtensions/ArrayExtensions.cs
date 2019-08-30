//-----------------------------------------------------------------------
// <copyright file="ArrayExtensions.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public static class ArrayExtensions
    {
        public static double SIMDSum(this double[] array)
        {
            ReadOnlySpan<double> sArray = array;
            return SIMDSum(sArray);
        }

        public static double SIMDSum(this ReadOnlySpan<double> array)
        {
            int length = Vector<double>.Count * 32;
            int vectorizedLength = (array.Length / length) * length;

            Span<double> temp = stackalloc double[length];
            double result = 0.0;

            for (int i = 0; i < vectorizedLength; i += length)
            {
                temp.AddAssign(array.Slice(i, length));
            }

            for (int i = 0; i < length; i++)
            {
                result += temp[i];
            }

            for (int i = vectorizedLength; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }

        public static int SIMDSum(this int[] array)
        {
            ReadOnlySpan<int> sArray = array;
            return SIMDSum(sArray);
        }

        public static int SIMDSum(this ReadOnlySpan<int> array)
        {
            int length = Vector<int>.Count * 32;
            int vectorizedLength = (array.Length / length) * length;

            Span<int> temp = stackalloc int[length];
            int result = 0;

            for (int i = 0; i < vectorizedLength; i += length)
            {
                temp.AddAssign(array.Slice(i, length));
            }

            for (int i = 0; i < length; i++)
            {
                result += temp[i];
            }

            for (int i = vectorizedLength; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }

        public static double SIMDAverage(this double[] array)
        {
            ReadOnlySpan<double> sArray = array;
            return SIMDAverage(sArray);
        }

        public static double SIMDAverage(this ReadOnlySpan<double> array)
        {
            return SIMDSum(array) / array.Length;
        }

        public static double SIMDAverage(this int[] array)
        {
            ReadOnlySpan<int> sArray = array;
            return SIMDAverage(sArray);
        }

        public static double SIMDAverage(this ReadOnlySpan<int> array)
        {
            return SIMDSum(array) / array.Length;
        }
    }
}
