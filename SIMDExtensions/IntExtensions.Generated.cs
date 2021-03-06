﻿//-----------------------------------------------------------------------
// <copyright file="IntExtensions.Generated.cs" company="Richard Smith">
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

    public static partial class IntExtensions
    {
		public static Span<int> Abs(this ReadOnlySpan<int> first)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static int[] Abs(this int[] first)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static Span<int> AbsAssign(this Span<int> first)
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

		public static int[] AbsAssign(this int[] first)
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
		public static void AbsSimd(in ReadOnlySpan<int> first, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = AbsVectorImplementation(vFirst[i]);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = AbsScalarImplementation(first[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AbsFallback(in ReadOnlySpan<int> first, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = AbsScalarImplementation(first[i]);
            }
		}
		public static Span<int> Negate(this ReadOnlySpan<int> first)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static int[] Negate(this int[] first)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static Span<int> NegateAssign(this Span<int> first)
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

		public static int[] NegateAssign(this int[] first)
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
		public static void NegateSimd(in ReadOnlySpan<int> first, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = NegateVectorImplementation(vFirst[i]);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = NegateScalarImplementation(first[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NegateFallback(in ReadOnlySpan<int> first, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = NegateScalarImplementation(first[i]);
            }
		}
		public static Span<int> Sqrt(this ReadOnlySpan<int> first)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static int[] Sqrt(this int[] first)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static Span<int> SqrtAssign(this Span<int> first)
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

		public static int[] SqrtAssign(this int[] first)
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
		public static void SqrtSimd(in ReadOnlySpan<int> first, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = SqrtVectorImplementation(vFirst[i]);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = SqrtScalarImplementation(first[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SqrtFallback(in ReadOnlySpan<int> first, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = SqrtScalarImplementation(first[i]);
            }
		}

		public static Span<int> Add(this ReadOnlySpan<int> first, in ReadOnlySpan<int> second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static int[] Add(this int[] first, in int[] second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static Span<int> AddAssign(this Span<int> first, in ReadOnlySpan<int> second)
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

		public static int[] AddAssign(this int[] first, in int[] second)
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
		public static void AddSimd(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            ReadOnlySpan<Vector<int>> vSecond = MemoryMarshal.Cast<int, Vector<int>>(second.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = AddVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = AddScalarImplementation(first[i], second[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFallback(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = AddScalarImplementation(first[i], second[i]);
            }
		}
		public static Span<int> Subtract(this ReadOnlySpan<int> first, in ReadOnlySpan<int> second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static int[] Subtract(this int[] first, in int[] second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static Span<int> SubtractAssign(this Span<int> first, in ReadOnlySpan<int> second)
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

		public static int[] SubtractAssign(this int[] first, in int[] second)
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
		public static void SubtractSimd(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            ReadOnlySpan<Vector<int>> vSecond = MemoryMarshal.Cast<int, Vector<int>>(second.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = SubtractVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = SubtractScalarImplementation(first[i], second[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SubtractFallback(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = SubtractScalarImplementation(first[i], second[i]);
            }
		}
		public static Span<int> Multiply(this ReadOnlySpan<int> first, in ReadOnlySpan<int> second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static int[] Multiply(this int[] first, in int[] second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static Span<int> MultiplyAssign(this Span<int> first, in ReadOnlySpan<int> second)
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

		public static int[] MultiplyAssign(this int[] first, in int[] second)
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
		public static void MultiplySimd(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            ReadOnlySpan<Vector<int>> vSecond = MemoryMarshal.Cast<int, Vector<int>>(second.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = MultiplyVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = MultiplyScalarImplementation(first[i], second[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MultiplyFallback(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = MultiplyScalarImplementation(first[i], second[i]);
            }
		}
		public static Span<int> Divide(this ReadOnlySpan<int> first, in ReadOnlySpan<int> second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static int[] Divide(this int[] first, in int[] second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static Span<int> DivideAssign(this Span<int> first, in ReadOnlySpan<int> second)
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

		public static int[] DivideAssign(this int[] first, in int[] second)
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
		public static void DivideSimd(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            ReadOnlySpan<Vector<int>> vSecond = MemoryMarshal.Cast<int, Vector<int>>(second.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = DivideVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = DivideScalarImplementation(first[i], second[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DivideFallback(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = DivideScalarImplementation(first[i], second[i]);
            }
		}
		public static Span<int> Max(this ReadOnlySpan<int> first, in ReadOnlySpan<int> second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static int[] Max(this int[] first, in int[] second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static Span<int> MaxAssign(this Span<int> first, in ReadOnlySpan<int> second)
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

		public static int[] MaxAssign(this int[] first, in int[] second)
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
		public static void MaxSimd(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            ReadOnlySpan<Vector<int>> vSecond = MemoryMarshal.Cast<int, Vector<int>>(second.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = MaxVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = MaxScalarImplementation(first[i], second[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MaxFallback(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = MaxScalarImplementation(first[i], second[i]);
            }
		}
		public static Span<int> Min(this ReadOnlySpan<int> first, in ReadOnlySpan<int> second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static int[] Min(this int[] first, in int[] second)
		{
			ValidateParameters(first, second);

            var result = new int[first.Length];

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

		public static Span<int> MinAssign(this Span<int> first, in ReadOnlySpan<int> second)
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

		public static int[] MinAssign(this int[] first, in int[] second)
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
		public static void MinSimd(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            ReadOnlySpan<Vector<int>> vSecond = MemoryMarshal.Cast<int, Vector<int>>(second.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = MinVectorImplementation(vFirst[i], vSecond[i]);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = MinScalarImplementation(first[i], second[i]);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MinFallback(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = MinScalarImplementation(first[i], second[i]);
            }
		}

		public static Span<int> Add(this ReadOnlySpan<int> first, in int second)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static int[] Add(this int[] first, in int second)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static Span<int> AddAssign(this Span<int> first, in int second)
        {
            ValidateParameters(first);

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

		public static int[] AddAssign(this int[] first, in int second)
        {
            ValidateParameters(first);

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
		public static void AddSimd(in ReadOnlySpan<int> first, in int second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = AddVectorImplementation(vFirst[i], second);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = AddScalarImplementation(first[i], second);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFallback(in ReadOnlySpan<int> first, in int second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = AddScalarImplementation(first[i], second);
            }
		}
		public static Span<int> Subtract(this ReadOnlySpan<int> first, in int second)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static int[] Subtract(this int[] first, in int second)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static Span<int> SubtractAssign(this Span<int> first, in int second)
        {
            ValidateParameters(first);

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

		public static int[] SubtractAssign(this int[] first, in int second)
        {
            ValidateParameters(first);

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
		public static void SubtractSimd(in ReadOnlySpan<int> first, in int second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = SubtractVectorImplementation(vFirst[i], second);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = SubtractScalarImplementation(first[i], second);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SubtractFallback(in ReadOnlySpan<int> first, in int second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = SubtractScalarImplementation(first[i], second);
            }
		}
		public static Span<int> Multiply(this ReadOnlySpan<int> first, in int second)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static int[] Multiply(this int[] first, in int second)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static Span<int> MultiplyAssign(this Span<int> first, in int second)
        {
            ValidateParameters(first);

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

		public static int[] MultiplyAssign(this int[] first, in int second)
        {
            ValidateParameters(first);

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
		public static void MultiplySimd(in ReadOnlySpan<int> first, in int second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = MultiplyVectorImplementation(vFirst[i], second);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = MultiplyScalarImplementation(first[i], second);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MultiplyFallback(in ReadOnlySpan<int> first, in int second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = MultiplyScalarImplementation(first[i], second);
            }
		}
		public static Span<int> Divide(this ReadOnlySpan<int> first, in int second)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static int[] Divide(this int[] first, in int second)
		{
			ValidateParameters(first);

            var result = new int[first.Length];

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

		public static Span<int> DivideAssign(this Span<int> first, in int second)
        {
            ValidateParameters(first);

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

		public static int[] DivideAssign(this int[] first, in int second)
        {
            ValidateParameters(first);

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
		public static void DivideSimd(in ReadOnlySpan<int> first, in int second, in Span<int> result)
		{
			int vectorizedLength = (first.Length / Vector<int>.Count) * Vector<int>.Count;

            ReadOnlySpan<Vector<int>> vFirst = MemoryMarshal.Cast<int, Vector<int>>(first.Slice(0, vectorizedLength));

            Span<Vector<int>> vResult = MemoryMarshal.Cast<int, Vector<int>>(result.Slice(0, vectorizedLength));

            for (int i = 0; i < vFirst.Length; i++)
            {
                vResult[i] = DivideVectorImplementation(vFirst[i], second);
            }

            for (int i = vectorizedLength; i < first.Length; i++)
            {
                result[i] = DivideScalarImplementation(first[i], second);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DivideFallback(in ReadOnlySpan<int> first, in int second, in Span<int> result)
		{
			for (int i = 0; i < first.Length; i++)
            {
                result[i] = DivideScalarImplementation(first[i], second);
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void ValidateParameters(in ReadOnlySpan<int> first)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
        }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void ValidateParameters(in ReadOnlySpan<int> first, in ReadOnlySpan<int> second)
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