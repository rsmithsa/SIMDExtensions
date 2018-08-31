//-----------------------------------------------------------------------
// <copyright file="DoubleExtensionsTests.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    public class DoubleExtensionsTests
    {
        [Fact]
        public void TestAggregate()
        {
            var input = new List<double[]>();

            for (int i = 0; i < 10; i++)
            {
                var vals = new double[10];
                for (int j = 0; j < 10; j++)
                {
                    vals[j] = j + 1;
                }

                input.Add(vals);
            }

            var expected = new double[10];
            var expected2 = new double[10];
            for (int i = 0; i < 10; i++)
            {
                expected[i] = (i + 1) * 10;
                expected2[i] = i + 1;
            }

            var res = input.Aggregate(new double[10], (a, b) => a.AddAssign(b));
            
            Assert.Equal(expected, res);
            foreach (var arr in input)
            {
                Assert.Equal(expected2, arr);
            }
        }

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

            var result = first.Add(second);

            Assert.Equal(expected, result);
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

            var result = new double[first.Length];
            DoubleExtensions.AddFallback(first, second, result);

            Assert.Equal(expected, result);
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

            var result = new double[first.Length];
            DoubleExtensions.AddSimd(first, second, result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMultiply()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] * second[i];
            }

            var result = first.Multiply(second);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMultiplyAssign()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] * second[i];
            }

            first.MultiplyAssign(second);

            Assert.Equal(expected, first);
        }

        [Fact]
        public void TestMultiplyFallback()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] * second[i];
            }

            var result = new double[first.Length];
            DoubleExtensions.MultiplyFallback(first, second, result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMultiplySimd()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] * second[i];
            }

            var result = new double[first.Length];
            DoubleExtensions.MultiplySimd(first, second, result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMax()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] > second[i] ? first[i] : second[i];
            }

            var result = DoubleExtensions.Max(first, second);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMaxAssign()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] > second[i] ? first[i] : second[i];
            }

            first.MaxAssign(second);

            Assert.Equal(expected, first);
        }

        [Fact]
        public void TestMaxFallback()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] > second[i] ? first[i] : second[i];
            }

            var result = new double[first.Length];
            DoubleExtensions.MaxFallback(first, second, result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMaxSimd()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new double[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] > second[i] ? first[i] : second[i];
            }

            var result = new double[first.Length];
            DoubleExtensions.MaxSimd(first, second, result);

            Assert.Equal(expected, result);
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
