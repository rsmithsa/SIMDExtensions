//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions.Benchmark
{
    using System;

    using BenchmarkDotNet.Running;

    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<DoubleExtensionsBenchmark>();
        }
    }
}
