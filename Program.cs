// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using StaticTypeDictionaryBenchmark;

StaticSwitchHelper.Switch(new Request500());

BenchmarkRunner.Run<SwitchBenchmark>();