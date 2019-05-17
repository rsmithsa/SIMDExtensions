//-----------------------------------------------------------------------
// <copyright file="IntExtensions.cs" company="Richard Smith">
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

    public static partial class IntExtensions
    {
        public static string[] UnaryFunctions = new[] { "Abs", "Negate", "Sqrt" };
        public static string[] BinaryFunctions = new[] { "Add", "Subtract", "Multiply", "Divide", "Max", "Min" };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<int> AbsVectorImplementation(Vector<int> left)
        {
            return Vector.Abs(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int AbsScalarImplementation(int left)
        {
            return Math.Abs(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<int> NegateVectorImplementation(Vector<int> left)
        {
            return Vector.Negate(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int NegateScalarImplementation(int left)
        {
            return -1 * left;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<int> SqrtVectorImplementation(Vector<int> left)
        {
            return Vector.SquareRoot(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int SqrtScalarImplementation(int left)
        {
            return (int)Math.Sqrt(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<int> AddVectorImplementation(Vector<int> left, Vector<int> right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int AddScalarImplementation(int left, int right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<int> SubtractVectorImplementation(Vector<int> left, Vector<int> right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int SubtractScalarImplementation(int left, int right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<int> MultiplyVectorImplementation(Vector<int> left, Vector<int> right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int MultiplyScalarImplementation(int left, int right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<int> DivideVectorImplementation(Vector<int> left, Vector<int> right)
        {
            return left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int DivideScalarImplementation(int left, int right)
        {
            return left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<int> MaxVectorImplementation(Vector<int> left, Vector<int> right)
        {
            return Vector.Max(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int MaxScalarImplementation(int left, int right)
        {
            return Math.Max(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<int> MinVectorImplementation(Vector<int> left, Vector<int> right)
        {
            return Vector.Min(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int MinScalarImplementation(int left, int right)
        {
            return Math.Min(left, right);
        }
    }
}
