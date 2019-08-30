//-----------------------------------------------------------------------
// <copyright file="ArrayExtensionsBenchmark.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions.Benchmark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BenchmarkDotNet.Attributes;

    public class ArrayExtensionsBenchmark
    {
        private double[] input;

        [Params(10, 100, 10000, 100000)]
        public int Length { get; set; } = 100;

        [GlobalSetup]
        public void Setup()
        {
            this.input = new double[this.Length];

            for (int i = 0; i < this.Length; i++)
            {
                this.input[i] = i;
            }
        }

        [Benchmark(Baseline = true)]
        public double SumLinq()
        {
            var result = this.input.Sum();

            return result;
        }

        [Benchmark]
        public double SumSimd()
        {
            var result = this.input.SIMDSum();

            return result;
        }

        [Benchmark]
        public double AverageLinq()
        {
            var result = this.input.Average();

            return result;
        }

        [Benchmark]
        public double AverageSimd()
        {
            var result = this.input.SIMDAverage();

            return result;
        }
    }
}
