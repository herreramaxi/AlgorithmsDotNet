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
| ProducerConsumer_LockAndMonitor | 1000       | 2             | 2             | 2.269 ms | 0.0450 ms | 0.1193 ms |     baseline |         | 121.0938 | 50.7813 | 23.4375 | 731.96 KB |             |
| ProducerConsumer_Dataflow       | 1000       | 2             | 2             | 1.887 ms | 0.0329 ms | 0.0323 ms | 1.18x faster |   0.05x | 128.9063 | 56.6406 | 27.3438 | 767.84 KB |  1.05x more |
| ProducerConsumer_Channel        | 1000       | 2             | 2             | 1.966 ms | 0.0388 ms | 0.0916 ms | 1.16x faster |   0.08x | 144.5313 | 60.5469 | 19.5313 | 736.24 KB |  1.01x more |
