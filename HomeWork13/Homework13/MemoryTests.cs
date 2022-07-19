using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace Homework13;

[MemoryDiagnoser]
[MedianColumn]
[MinColumn]
[MaxColumn]
[MeanColumn]
[StdDevColumn]
[ExcludeFromCodeCoverage]
public class MemoryTests
{
    
}