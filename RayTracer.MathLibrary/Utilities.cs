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
                && MathHelper.AreNumbersEqual(arg1.Z, arg2.Z, epsilon);
        }

        public static IObjectIn3DSpace AddCordinates(IObjectIn3DSpace origin, IObjectIn3DSpace arg)
        {
            origin.X += arg.X;
            origin.Y += arg.Y;
            origin.Z += arg.Z;

            return origin;
        }

        public static IObjectIn3DSpace SubtractCordinates(IObjectIn3DSpace origin, IObjectIn3DSpace arg)
        {
            origin.X -= arg.X;
            origin.Y -= arg.Y;
            origin.Z -= arg.Z;

            return origin;
        }

        public static IObjectIn3DSpace MultiplyCordinatesByScalar(IObjectIn3DSpace origin, double scalar)
        {
            origin.X *= scalar;
            origin.Y *= scalar;
            origin.Z *= scalar;

            return origin;
        }

        public static IObjectIn3DSpace DivideCordinatesByScalar(IObjectIn3DSpace origin, double scalar)
        {
            origin.X /= scalar;
            origin.Y /= scalar;
            origin.Z /= scalar;

            return origin;
        }

        public static Vector3 CastPointToVector(Point3D point)
        {
            return new Vector3()
            {
                X = point.X,
                Y = point.Y,
                Z = point.Z
            };
        }
    }
}
