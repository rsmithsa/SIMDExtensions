//-----------------------------------------------------------------------
// <copyright file="DoubleExtensionsTests.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions.Tests
{
    using System;

    using Xunit;

    public class DoubleExtensionsTests
    {
        [Fact]
        public void TestAdd()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] + second[i];
            }

            var sum = first.Add(second);

            Assert.Equal(expected, sum);
        }

        [Fact]
        public void TestAddAssign()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] + second[i];
            }

            first.AddAssign(second);

            Assert.Equal(expected, first);
        }

        [Fact]
        public void TestAddFallback()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] + second[i];
            }

            var sum = new double[first.Length];
            DoubleExtensions.AddFallback(first, second, sum);

            Assert.Equal(expected, sum);
        }

        [Fact]
        public void TestAddSimd()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] + second[i];
            }

            var sum = new double[first.Length];
            DoubleExtensions.AddSimd(first, second, sum);

            Assert.Equal(expected, sum);
        }

        [Fact]
        public void TestAddSimdUnsafe()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] + second[i];
            }

            var sum = new double[first.Length];
            DoubleExtensions.AddSimdUnsafe(first, second, sum);

            Assert.Equal(expected, sum);
        }

        private const int width = 512;

        private double[] GetInput()
        {
            var result = new double[(width / 64) + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i;
            }

            return result;
        }
    }
}
