``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]   : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  ShortRun : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                  Method |         Mean |       Error |     StdDev |
|------------------------ |-------------:|------------:|-----------:|
|          SwitchRequest1 |   177.936 ns |   2.7435 ns |  0.1504 ns |
|        SwitchRequest100 |   537.292 ns |  63.2024 ns |  3.4643 ns |
|        SwitchRequest200 |   868.002 ns |   6.9180 ns |  0.3792 ns |
|        SwitchRequest300 | 1,213.257 ns |  12.0224 ns |  0.6590 ns |
|        SwitchRequest400 | 1,570.105 ns | 505.7319 ns | 27.7209 ns |
|        SwitchRequest500 | 1,954.081 ns | 333.3473 ns | 18.2719 ns |
|        SwitchRequest600 | 2,296.974 ns | 380.4903 ns | 20.8560 ns |
|        SwitchRequest700 | 2,614.459 ns | 375.7176 ns | 20.5944 ns |
|        SwitchRequest800 | 3,001.314 ns |  55.9098 ns |  3.0646 ns |
|        SwitchRequest900 | 3,542.332 ns |  81.5554 ns |  4.4703 ns |
|       SwitchRequest1000 | 3,964.454 ns |  55.4060 ns |  3.0370 ns |
|    StaticSwitchRequest1 |     4.188 ns |   0.2662 ns |  0.0146 ns |
|  StaticSwitchRequest100 |     4.837 ns |   1.7584 ns |  0.0964 ns |
|  StaticSwitchRequest200 |     4.529 ns |   0.0561 ns |  0.0031 ns |
|  StaticSwitchRequest300 |     4.963 ns |   0.1827 ns |  0.0100 ns |
|  StaticSwitchRequest400 |     4.530 ns |   0.0132 ns |  0.0007 ns |
|  StaticSwitchRequest500 |     4.658 ns |   0.3519 ns |  0.0193 ns |
|  StaticSwitchRequest600 |     4.533 ns |   0.6353 ns |  0.0348 ns |
|  StaticSwitchRequest700 |     4.593 ns |   0.3906 ns |  0.0214 ns |
|  StaticSwitchRequest800 |     4.511 ns |   0.0095 ns |  0.0005 ns |
|  StaticSwitchRequest900 |     4.511 ns |   0.0425 ns |  0.0023 ns |
| StaticSwitchRequest1000 |     4.511 ns |   0.0292 ns |  0.0016 ns |
