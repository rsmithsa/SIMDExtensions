//-----------------------------------------------------------------------
// <copyright file="DoubleExtensions.Generated.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public static partial class DoubleExtensions
    {
		public static double[] Abs(this double[] first)
		{
			ValidateParameters(first);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                AbsSimd(first, result);
            }
            else
            {
                AbsFallback(first, result);
            }

            return result;
		}

		public static double[] AbsAssign(this double[] first)
        {
            ValidateParameters(first);

            if (Vector.IsHardwareAccelerated)
            {
                AbsSimd(first, first);
            }
            else
            {
                AbsFallback(first, first);
            }

            return first;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AbsSimd(in double[] first, in double[] result)
		{
			int vectorizedLength = (first.Length / Vector<double>.Count) * Vector<double>.Count;

            ReadOnlySpan<double> sFirst = first;
            ReadOnlySpan<Vector<double>> vFirst = MemoryMarshal.Cast<double, Vector<double>>(sFirst.Slice(0, vectorizedLength));

            Span<double> sResult = result;
            Span<Vector<double>> vResult = MemoryMarshal.Cast<double, Vector<double>>(sResult.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = AbsVectorImplementation(vFirst[i]);
            }

            for (int i = vectorizedLength; i < sFirst.Length; i++)
            {
                sResult[i] = AbsScalarImplementation(sFirst[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AbsFallback(in double[] first, in double[] result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = AbsScalarImplementation(first[i]);
            }
		}
		public static double[] Negate(this double[] first)
		{
			ValidateParameters(first);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                NegateSimd(first, result);
            }
            else
            {
                NegateFallback(first, result);
            }

            return result;
		}

		public static double[] NegateAssign(this double[] first)
        {
            ValidateParameters(first);

            if (Vector.IsHardwareAccelerated)
            {
                NegateSimd(first, first);
            }
            else
            {
                NegateFallback(first, first);
            }

            return first;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NegateSimd(in double[] first, in double[] result)
		{
			int vectorizedLength = (first.Length / Vector<double>.Count) * Vector<double>.Count;

            ReadOnlySpan<double> sFirst = first;
            ReadOnlySpan<Vector<double>> vFirst = MemoryMarshal.Cast<double, Vector<double>>(sFirst.Slice(0, vectorizedLength));

            Span<double> sResult = result;
            Span<Vector<double>> vResult = MemoryMarshal.Cast<double, Vector<double>>(sResult.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = NegateVectorImplementation(vFirst[i]);
            }

            for (int i = vectorizedLength; i < sFirst.Length; i++)
            {
                sResult[i] = NegateScalarImplementation(sFirst[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NegateFallback(in double[] first, in double[] result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = NegateScalarImplementation(first[i]);
            }
		}
		public static double[] Sqrt(this double[] first)
		{
			ValidateParameters(first);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                SqrtSimd(first, result);
            }
            else
            {
                SqrtFallback(first, result);
            }

            return result;
		}

		public static double[] SqrtAssign(this double[] first)
        {
            ValidateParameters(first);

            if (Vector.IsHardwareAccelerated)
            {
                SqrtSimd(first, first);
            }
            else
            {
                SqrtFallback(first, first);
            }

            return first;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SqrtSimd(in double[] first, in double[] result)
		{
			int vectorizedLength = (first.Length / Vector<double>.Count) * Vector<double>.Count;

            ReadOnlySpan<double> sFirst = first;
            ReadOnlySpan<Vector<double>> vFirst = MemoryMarshal.Cast<double, Vector<double>>(sFirst.Slice(0, vectorizedLength));

            Span<double> sResult = result;
            Span<Vector<double>> vResult = MemoryMarshal.Cast<double, Vector<double>>(sResult.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = SqrtVectorImplementation(vFirst[i]);
            }

            for (int i = vectorizedLength; i < sFirst.Length; i++)
            {
                sResult[i] = SqrtScalarImplementation(sFirst[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SqrtFallback(in double[] first, in double[] result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = SqrtScalarImplementation(first[i]);
            }
		}

		public static double[] Add(this double[] first, in double[] second)
		{
			ValidateParameters(first, second);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                AddSimd(first, second, result);
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
                AddSimd(first, second, first);
            }
            else
            {
                AddFallback(first, second, first);
            }

            return first;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSimd(in double[] first, in double[] second, in double[] result)
		{
			int vectorizedLength = (first.Length / Vector<double>.Count) * Vector<double>.Count;

            ReadOnlySpan<double> sFirst = first;
            ReadOnlySpan<Vector<double>> vFirst = MemoryMarshal.Cast<double, Vector<double>>(sFirst.Slice(0, vectorizedLength));

            ReadOnlySpan<double> sSecond = second;
            ReadOnlySpan<Vector<double>> vSecond = MemoryMarshal.Cast<double, Vector<double>>(sSecond.Slice(0, vectorizedLength));

            Span<double> sResult = result;
            Span<Vector<double>> vResult = MemoryMarshal.Cast<double, Vector<double>>(sResult.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = AddVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < sFirst.Length; i++)
            {
                sResult[i] = AddScalarImplementation(sFirst[i], sSecond[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFallback(in double[] first, in double[] second, in double[] result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = AddScalarImplementation(first[i], second[i]);
            }
		}
		public static double[] Subtract(this double[] first, in double[] second)
		{
			ValidateParameters(first, second);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                SubtractSimd(first, second, result);
            }
            else
            {
                SubtractFallback(first, second, result);
            }

            return result;
		}

		public static double[] SubtractAssign(this double[] first, in double[] second)
        {
            ValidateParameters(first, second);

            if (Vector.IsHardwareAccelerated)
            {
                SubtractSimd(first, second, first);
            }
            else
            {
                SubtractFallback(first, second, first);
            }

            return first;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SubtractSimd(in double[] first, in double[] second, in double[] result)
		{
			int vectorizedLength = (first.Length / Vector<double>.Count) * Vector<double>.Count;

            ReadOnlySpan<double> sFirst = first;
            ReadOnlySpan<Vector<double>> vFirst = MemoryMarshal.Cast<double, Vector<double>>(sFirst.Slice(0, vectorizedLength));

            ReadOnlySpan<double> sSecond = second;
            ReadOnlySpan<Vector<double>> vSecond = MemoryMarshal.Cast<double, Vector<double>>(sSecond.Slice(0, vectorizedLength));

            Span<double> sResult = result;
            Span<Vector<double>> vResult = MemoryMarshal.Cast<double, Vector<double>>(sResult.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = SubtractVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < sFirst.Length; i++)
            {
                sResult[i] = SubtractScalarImplementation(sFirst[i], sSecond[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SubtractFallback(in double[] first, in double[] second, in double[] result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = SubtractScalarImplementation(first[i], second[i]);
            }
		}
		public static double[] Multiply(this double[] first, in double[] second)
		{
			ValidateParameters(first, second);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                MultiplySimd(first, second, result);
            }
            else
            {
                MultiplyFallback(first, second, result);
            }

            return result;
		}

		public static double[] MultiplyAssign(this double[] first, in double[] second)
        {
            ValidateParameters(first, second);

            if (Vector.IsHardwareAccelerated)
            {
                MultiplySimd(first, second, first);
            }
            else
            {
                MultiplyFallback(first, second, first);
            }

            return first;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MultiplySimd(in double[] first, in double[] second, in double[] result)
		{
			int vectorizedLength = (first.Length / Vector<double>.Count) * Vector<double>.Count;

            ReadOnlySpan<double> sFirst = first;
            ReadOnlySpan<Vector<double>> vFirst = MemoryMarshal.Cast<double, Vector<double>>(sFirst.Slice(0, vectorizedLength));

            ReadOnlySpan<double> sSecond = second;
            ReadOnlySpan<Vector<double>> vSecond = MemoryMarshal.Cast<double, Vector<double>>(sSecond.Slice(0, vectorizedLength));

            Span<double> sResult = result;
            Span<Vector<double>> vResult = MemoryMarshal.Cast<double, Vector<double>>(sResult.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = MultiplyVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < sFirst.Length; i++)
            {
                sResult[i] = MultiplyScalarImplementation(sFirst[i], sSecond[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MultiplyFallback(in double[] first, in double[] second, in double[] result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = MultiplyScalarImplementation(first[i], second[i]);
            }
		}
		public static double[] Divide(this double[] first, in double[] second)
		{
			ValidateParameters(first, second);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                DivideSimd(first, second, result);
            }
            else
            {
                DivideFallback(first, second, result);
            }

            return result;
		}

		public static double[] DivideAssign(this double[] first, in double[] second)
        {
            ValidateParameters(first, second);

            if (Vector.IsHardwareAccelerated)
            {
                DivideSimd(first, second, first);
            }
            else
            {
                DivideFallback(first, second, first);
            }

            return first;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DivideSimd(in double[] first, in double[] second, in double[] result)
		{
			int vectorizedLength = (first.Length / Vector<double>.Count) * Vector<double>.Count;

            ReadOnlySpan<double> sFirst = first;
            ReadOnlySpan<Vector<double>> vFirst = MemoryMarshal.Cast<double, Vector<double>>(sFirst.Slice(0, vectorizedLength));

            ReadOnlySpan<double> sSecond = second;
            ReadOnlySpan<Vector<double>> vSecond = MemoryMarshal.Cast<double, Vector<double>>(sSecond.Slice(0, vectorizedLength));

            Span<double> sResult = result;
            Span<Vector<double>> vResult = MemoryMarshal.Cast<double, Vector<double>>(sResult.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = DivideVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < sFirst.Length; i++)
            {
                sResult[i] = DivideScalarImplementation(sFirst[i], sSecond[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DivideFallback(in double[] first, in double[] second, in double[] result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = DivideScalarImplementation(first[i], second[i]);
            }
		}
		public static double[] Max(this double[] first, in double[] second)
		{
			ValidateParameters(first, second);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                MaxSimd(first, second, result);
            }
            else
            {
                MaxFallback(first, second, result);
            }

            return result;
		}

		public static double[] MaxAssign(this double[] first, in double[] second)
        {
            ValidateParameters(first, second);

            if (Vector.IsHardwareAccelerated)
            {
                MaxSimd(first, second, first);
            }
            else
            {
                MaxFallback(first, second, first);
            }

            return first;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MaxSimd(in double[] first, in double[] second, in double[] result)
		{
			int vectorizedLength = (first.Length / Vector<double>.Count) * Vector<double>.Count;

            ReadOnlySpan<double> sFirst = first;
            ReadOnlySpan<Vector<double>> vFirst = MemoryMarshal.Cast<double, Vector<double>>(sFirst.Slice(0, vectorizedLength));

            ReadOnlySpan<double> sSecond = second;
            ReadOnlySpan<Vector<double>> vSecond = MemoryMarshal.Cast<double, Vector<double>>(sSecond.Slice(0, vectorizedLength));

            Span<double> sResult = result;
            Span<Vector<double>> vResult = MemoryMarshal.Cast<double, Vector<double>>(sResult.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = MaxVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < sFirst.Length; i++)
            {
                sResult[i] = MaxScalarImplementation(sFirst[i], sSecond[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MaxFallback(in double[] first, in double[] second, in double[] result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = MaxScalarImplementation(first[i], second[i]);
            }
		}
		public static double[] Min(this double[] first, in double[] second)
		{
			ValidateParameters(first, second);

            var result = new double[first.Length];

            if (Vector.IsHardwareAccelerated)
            {
                MinSimd(first, second, result);
            }
            else
            {
                MinFallback(first, second, result);
            }

            return result;
		}

		public static double[] MinAssign(this double[] first, in double[] second)
        {
            ValidateParameters(first, second);

            if (Vector.IsHardwareAccelerated)
            {
                MinSimd(first, second, first);
            }
            else
            {
                MinFallback(first, second, first);
            }

            return first;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MinSimd(in double[] first, in double[] second, in double[] result)
		{
			int vectorizedLength = (first.Length / Vector<double>.Count) * Vector<double>.Count;

            ReadOnlySpan<double> sFirst = first;
            ReadOnlySpan<Vector<double>> vFirst = MemoryMarshal.Cast<double, Vector<double>>(sFirst.Slice(0, vectorizedLength));

            ReadOnlySpan<double> sSecond = second;
            ReadOnlySpan<Vector<double>> vSecond = MemoryMarshal.Cast<double, Vector<double>>(sSecond.Slice(0, vectorizedLength));

            Span<double> sResult = result;
            Span<Vector<double>> vResult = MemoryMarshal.Cast<double, Vector<double>>(sResult.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = MinVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < sFirst.Length; i++)
            {
                sResult[i] = MinScalarImplementation(sFirst[i], sSecond[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MinFallback(in double[] first, in double[] second, in double[] result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = MinScalarImplementation(first[i], second[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void ValidateParameters<T>(in T[] first)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
        }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void ValidateParameters<T>(in T[] first, in T[] second)
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