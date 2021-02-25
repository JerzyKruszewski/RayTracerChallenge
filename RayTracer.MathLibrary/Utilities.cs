using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Utilities
    {
        public static bool AreObjectEquals(IObjectIn3DSpace arg1, IObjectIn3DSpace arg2, double epsilon = 0.00001f)
        {
            return MathHelper.AreNumbersEqual(arg1.X, arg2.X, epsilon)
                && MathHelper.AreNumbersEqual(arg1.Y, arg2.Y, epsilon)
                && MathHelper.AreNumbersEqual(arg1.Z, arg2.Z, epsilon)
                && MathHelper.AreNumbersEqual(arg1.W, arg2.W, epsilon);
        }

        public static Vector3 CastPointToVector(Point3D point)
        {
            return new Vector3()
            {
                X = point.X,
                Y = point.Y,
                Z = point.Z,
                W = point.W
            };
        }

        public static int CastDoubleToInt(double number)
        {
            if (number - (int)number >= 0.5f && number > 0)
            {
                return (int)number + 1;
            }

            if (number - (int)number < -0.5f && number <= 0)
            {
                return (int)number - 1;
            }

            return (int)number;
        }
    }
}
