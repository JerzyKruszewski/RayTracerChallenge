using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLib.Benchmarks.ExperimentalClasses._32Bit;

public class MathHelper
{
    public static IObjectIn3DSpace CreateObjectIn3DSpace(Tuple<float, float, float, float> tuple)
    {
        if (tuple.Item4 == 1.0)
        {
            return new Point3D()
            {
                X = tuple.Item1,
                Y = tuple.Item2,
                Z = tuple.Item3
            };
        }
        if (tuple.Item4 == 0.0)
        {
            return new Vector3()
            {
                X = tuple.Item1,
                Y = tuple.Item2,
                Z = tuple.Item3
            };
        }

        return null;
    }

    public static bool AreNumbersEqual(float firstNumber, float secondNumber, float epsilon = 0.00001f)
    {
        return Math.Abs(firstNumber - secondNumber) < epsilon;
    }
}
