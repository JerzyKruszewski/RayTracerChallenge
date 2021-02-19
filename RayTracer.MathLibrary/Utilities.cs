using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Utilities
    {
        public static IObjectIn3DSpace AddCordinates(IObjectIn3DSpace origin, IObjectIn3DSpace arg)
        {
            origin.X += arg.X;
            origin.Y += arg.Y;
            origin.Z += arg.Z;

            return origin;
        }
    }
}
