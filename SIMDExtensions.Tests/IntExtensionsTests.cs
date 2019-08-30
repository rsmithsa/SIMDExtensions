//-----------------------------------------------------------------------
// <copyright file="IntExtensionsTests.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    public class IntExtensionsTests
    {
        [Fact]
        public void TestAggregate()
        {
            var input = new List<int[]>();

            for (int i = 0; i < 10; i++)
            {
                var vals = new int[10];
                for (int j = 0; j < 10; j++)
                {
                    vals[j] = j + 1;
                }

                input.Add(vals);
            }

            var expected = new int[10];
            var expected2 = new int[10];
            for (int i = 0; i < 10; i++)
            {
                expected[i] = (i + 1) * 10;
                expected2[i] = i + 1;
            }

            var res = input.Aggregate(new int[10], (a, b) => a.AddAssign(b));
            
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
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] + second[i];
            }

            var result = first.Add(second);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestAddScalar()
        {
            var first = this.GetInput();
            var second = 10;
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] + second;
            }

            var result = first.Add(second);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestAddAssign()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new int[first.Length];
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
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] + second[i];
            }

            var result = new int[first.Length];
            IntExtensions.AddFallback(first, second, result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestAddSimd()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] + second[i];
            }

            var result = new int[first.Length];
            IntExtensions.AddSimd(first, second, result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMultiply()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] * second[i];
            }

            var result = first.Multiply(second);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMultiplyScalar()
        {
            var first = this.GetInput();
            var second = 10;
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] * second;
            }

            var result = first.Multiply(second);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMultiplyAssign()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new int[first.Length];
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
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] * second[i];
            }

            var result = new int[first.Length];
            IntExtensions.MultiplyFallback(first, second, result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMultiplySimd()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] * second[i];
            }

            var result = new int[first.Length];
            IntExtensions.MultiplySimd(first, second, result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMax()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] > second[i] ? first[i] : second[i];
            }

            var result = IntExtensions.Max(first, second);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMaxAssign()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new int[first.Length];
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
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] > second[i] ? first[i] : second[i];
            }

            var result = new int[first.Length];
            IntExtensions.MaxFallback(first, second, result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMaxSimd()
        {
            var first = this.GetInput();
            var second = this.GetInput();
            var expected = new int[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                expected[i] = first[i] > second[i] ? first[i] : second[i];
            }

            var result = new int[first.Length];
            IntExtensions.MaxSimd(first, second, result);

            Assert.Equal(expected, result);
        }

        private const int width = 512;

        private int[] GetInput()
        {
            var result = new int[(width / 64) + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i;
            }

            return result;
        }
    }
}
