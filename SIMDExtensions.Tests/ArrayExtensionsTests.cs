//-----------------------------------------------------------------------
// <copyright file="ArrayExtensionsTests.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Xunit;

    public class ArrayExtensionsTests
    {
        [Fact]
        public void TestDoubleSum()
        {
            var array = this.GetDoubleInput();
            var expected = array.Sum();

            var result = array.SIMDSum();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestDoubleAverage()
        {
            var array = this.GetDoubleInput();
            var expected = array.Average();

            var result = array.SIMDAverage();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIntSum()
        {
            var array = this.GetIntInput();
            var expected = array.Sum();

            var result = array.SIMDSum();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIntAverage()
        {
            var array = this.GetIntInput();
            var expected = array.Average();

            var result = array.SIMDAverage();

            Assert.Equal(expected, result);
        }

        private const int width = 512;

        private double[] GetDoubleInput()
        {
            var result = new double[width + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i;
            }

            return result;
        }

        private int[] GetIntInput()
        {
            var result = new int[width + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i;
            }

            return result;
        }
    }
}
