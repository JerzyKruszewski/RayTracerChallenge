using BenchmarkDotNet.Running;
using RayTracer.MathLib.Benchmarks.Benchmarks;

namespace RayTracer.MathLib.Benchmarks;

internal class Program
{
    private static void Main()
    {
        BenchmarkRunner.Run<Matrix4x4Benchmarks>();
        Console.ReadLine();
    }
}
