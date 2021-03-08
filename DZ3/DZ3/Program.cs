using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace DZ3
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }
    }

    public class PointClass
    {
        public int X;
        public int Y;
    }

    public class PointStruct
    {
        public int X;
        public int Y;
    }

    public class BencmarkClass1
        {

            public float PointDistance(PointStruct pointOne, PointStruct pointTwo)
            {
                float x = pointOne.X - pointTwo.X;
                float y = pointOne.Y - pointTwo.Y;
                return MathF.Sqrt((x * x) + (y * y));
            }

            public static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
            {
                 double x = pointOne.X - pointTwo.X;
                 double y = pointOne.Y - pointTwo.Y;
                 return Math.Sqrt((x * x) + (y * y));
            }

        [Benchmark]
            
            public void CalculationOfDistanceReferenceFloat()
            {
                PointStruct startPoint = new PointStruct { X = 10, Y = 20 };
                PointStruct endPoint = new PointStruct { X = 120, Y = 220 };
                PointDistance(startPoint, endPoint);
            }

              [Benchmark]

             public void CalculatingDistanceSignificantFloat()
            {
            PointStruct pointOne = new PointStruct { X = 10, Y = 20 };
            var array = new PointStruct[1];

            array[0] = pointOne;
            array[0].Y = 33;

            PointStruct pointTwo = new PointStruct { X = 120, Y = 220 };
            PointDistance(pointOne, pointTwo);
            }

        [Benchmark]

        public void CalculationOfDistanceReferenceDouble()
        {
            PointStruct startPoint = new PointStruct { X = 10, Y = 20 };
            PointStruct endPoint = new PointStruct { X = 120, Y = 220 };
            PointDistanceDouble(startPoint, endPoint);
        }

        [Benchmark]

        public void CalculatingDistanceSignificantDouble()
        {
            PointStruct pointOne = new PointStruct { X = 10, Y = 20 };
            var array = new PointStruct[1];

            array[0] = pointOne;
            array[0].Y = 33;

            PointStruct pointTwo = new PointStruct { X = 120, Y = 220 };
            PointDistanceDouble(pointOne, pointTwo);
        }

    }
        
}

