//-----------------------------------------------------------------------
// <copyright file="DoubleExtensionsBenchmark.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions.Benchmark
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Jobs;

    [ShortRunJob]
    public class DoubleExtensionsBenchmark
    {
        private double[] first;
        private double[] second;

        [Params(10, 100, 1000)]
        public int Length { get; set; } = 100;

        [GlobalSetup]
        public void Setup()
        {
            this.first = new double[this.Length];
            this.second = new double[this.Length];

            for (int i = 0; i < this.Length; i++)
            {
                this.first[i] = i;
                this.second[i] = i * 2;
            }
        }

        [Benchmark(Baseline = true)]
        public double[] AddFallback()
        {
            DoubleExtensions.AddFallback(this.first, this.second, this.first);
            return this.first;
        }

        [Benchmark]
        public double[] AddSimd()
        {
            DoubleExtensions.AddSimd(this.first, this.second, this.first);
            return this.first;
        }

        [Benchmark]
        public double[] AddSimdUnsafe()
        {
            DoubleExtensions.AddSimdUnsafe(this.first, this.second, this.first);
            return this.first;
        }

        [Benchmark]
        public double[] AddAssign()
        {
            return this.first.AddAssign(this.second);
        }
    }
}
