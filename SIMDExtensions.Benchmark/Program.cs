//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Richard Smith">
//     Copyright (c) Richard Smith. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SIMDExtensions.Benchmark
{
    using System;

    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Environments;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;
    using BenchmarkDotNet.Toolchains.CsProj;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //BenchmarkRunner.Run<DoubleExtensionsBenchmark>();

            BenchmarkRunner.Run<DoubleExtensionsBenchmark>(ManualConfig.Create(DefaultConfig.Instance)
                //.With(Job.ShortRun.With(Platform.X64).With(CsProjCoreToolchain.NetCoreApp20))
                .With(Job.ShortRun.With(Platform.X64).With(CsProjCoreToolchain.NetCoreApp21))
                //.With(DisassemblyDiagnoser.Create(DisassemblyDiagnoserConfig.Asm))
                .With(MemoryDiagnoser.Default)
            );
        }
    }
}
