using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLib;

public class MathHelper
{
    public static IObjectIn3DSpace CreateObjectIn3DSpace(Tuple<double, double, double, double> tuple)
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

    public static bool AreNumbersEqual(double firstNumber, double secondNumber, double epsilon = 0.00001f)
    {
        return Math.Abs(firstNumber - secondNumber) < epsilon;
    }
}
