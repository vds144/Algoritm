using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            int x = 42;
            object ox = x; // boxing
            int y = (int)ox; // unboxing

         //   Console.WriteLine($"x : {x}, ox : {ox}, y : {y}");
        }

        [Benchmark]
        public static float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
           float x = pointOne.X - pointTwo.X;
           float y = pointOne.Y - pointTwo.Y;
           return MathF.Sqrt((x * x) + (y * y));
        }


    }
}