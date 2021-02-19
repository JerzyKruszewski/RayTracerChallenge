using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Utilities
    {
        public static bool AreObjectEquals(IObjectIn3DSpace arg1, IObjectIn3DSpace arg2)
        {
            return MathHelper.AreNumbersEqual(arg1.X, arg2.X)
                && MathHelper.AreNumbersEqual(arg1.Y, arg2.Y)
                && MathHelper.AreNumbersEqual(arg1.Z, arg2.Z);
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

        public static IObjectIn3DSpace MultiplyCordinatesByScalar(IObjectIn3DSpace origin, float scalar)
        {
            origin.X *= scalar;
            origin.Y *= scalar;
            origin.Z *= scalar;

            return origin;
        }

        public static IObjectIn3DSpace DivideCordinatesByScalar(IObjectIn3DSpace origin, float scalar)
        {
            origin.X /= scalar;
            origin.Y /= scalar;
            origin.Z /= scalar;

            return origin;
        }
    }
}
