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

    public static partial class DoubleExtensions
    {
        public static string[] UnaryFunctions = new[] { "Abs", "Negate", "Sqrt" };
        public static string[] BinaryFunctions = new[] { "Add", "Subtract", "Multiply", "Divide", "Max", "Min" };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<double> AbsVectorImplementation(Vector<double> left)
        {
            return Vector.Abs(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double AbsScalarImplementation(double left)
        {
            return Math.Abs(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<double> NegateVectorImplementation(Vector<double> left)
        {
            return Vector.Negate(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double NegateScalarImplementation(double left)
        {
            return -1 * left;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<double> SqrtVectorImplementation(Vector<double> left)
        {
            return Vector.SquareRoot(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double SqrtScalarImplementation(double left)
        {
            return Math.Sqrt(left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<double> AddVectorImplementation(Vector<double> left, Vector<double> right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double AddScalarImplementation(double left, double right)
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<double> SubtractVectorImplementation(Vector<double> left, Vector<double> right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double SubtractScalarImplementation(double left, double right)
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<double> MultiplyVectorImplementation(Vector<double> left, Vector<double> right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double MultiplyScalarImplementation(double left, double right)
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<double> DivideVectorImplementation(Vector<double> left, Vector<double> right)
        {
            return left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double DivideScalarImplementation(double left, double right)
        {
            return left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<double> MaxVectorImplementation(Vector<double> left, Vector<double> right)
        {
            return Vector.Max(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double MaxScalarImplementation(double left, double right)
        {
            return Math.Max(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector<double> MinVectorImplementation(Vector<double> left, Vector<double> right)
        {
            return Vector.Min(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double MinScalarImplementation(double left, double right)
        {
            return Math.Min(left, right);
        }
    }
}
