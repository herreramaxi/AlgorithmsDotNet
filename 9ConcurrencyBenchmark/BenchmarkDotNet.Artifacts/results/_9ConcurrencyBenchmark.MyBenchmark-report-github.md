```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1355U, 1 CPU, 12 logical and 10 physical cores
.NET SDK 8.0.100
  [Host]        : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT AVX2
  .NET Core 3.1 : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT AVX2

Job=.NET Core 3.1  Runtime=.NET Core 3.1  

```
| Method                          | MAX_VALUES | MAX_PRODUCERS | MAX_CONSUMERS | Mean     | Error     | StdDev    | Ratio        | RatioSD | Gen0     | Gen1    | Gen2    | Allocated | Alloc Ratio |
|-------------------------------- |----------- |-------------- |-------------- |---------:|----------:|----------:|-------------:|--------:|---------:|--------:|--------:|----------:|------------:|
| ProducerConsumer_LockAndMonitor | 1000       | 2             | 2             | 2.251 ms | 0.0438 ms | 0.1075 ms |     baseline |         | 121.0938 | 54.6875 | 23.4375 |  731.7 KB |             |
| ProducerConsumer_Dataflow       | 1000       | 2             | 2             | 1.918 ms | 0.0383 ms | 0.0484 ms | 1.17x faster |   0.07x | 128.9063 | 54.6875 | 23.4375 | 775.46 KB |  1.06x more |
| ProducerConsumer_Channel        | 1000       | 2             | 2             | 1.967 ms | 0.0392 ms | 0.0947 ms | 1.15x faster |   0.09x | 132.8125 | 68.3594 | 17.5781 | 736.13 KB |  1.01x more |
