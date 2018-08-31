//-----------------------------------------------------------------------
// <copyright file="DoubleExtensionsBenchmark.cs" company="Richard Smith">
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

    public class DoubleExtensionsBenchmark
    {
        private double[] first;
        private double[] second;

        private List<double[]> input;

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

            input = new List<double[]>();
            for (int i = 0; i < 10; i++)
            {
                var vals = new double[this.Length];
                for (int j = 0; j < this.Length; j++)
                {
                    vals[j] = j + 1;
                }

                input.Add(vals);
            }
        }

        //[Benchmark(Baseline = true)]
        //public double[] AddFallback()
        //{
        //    DoubleExtensions.AddFallback(this.first, this.second, this.first);
        //    return this.first;
        //}

        //[Benchmark]
        //public double[] AddSimd()
        //{
        //    DoubleExtensions.AddSimd(this.first, this.second, this.first);
        //    return this.first;
        //}

        //[Benchmark]
        //public double[] Add()
        //{
        //    return this.first.Add(this.second);
        //}

        //[Benchmark]
        //public double[] AddAssign()
        //{
        //    return this.first.AddAssign(this.second);
        //}

        [Benchmark(Baseline = true)]
        public double[] SumArrsHand()
        {
            var result = new double[this.Length];
            for (int i = 0; i < this.input.Count; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    result[j] += this.input[i][j];
                }
            }

            return result;
        }

        [Benchmark]
        public double[] SumArrsSimd()
        {
            return this.input.Aggregate((a, b) => a.Add(b));
        }

        [Benchmark]
        public double[] SumArrsAssignSimd()
        {
            return this.input.Aggregate(new double[this.Length], (a, b) => a.AddAssign(b));
        }

        [Benchmark]
        public double[] SumArrsSimdHand()
        {
            var result = new double[this.Length];
            for (int i = 0; i < this.input.Count; i++)
            {
                result.AddAssign(this.input[i]);
            }

            return result;
        }
    }
}
