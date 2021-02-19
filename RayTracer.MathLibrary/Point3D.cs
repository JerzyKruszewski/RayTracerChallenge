using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Point3D : IObjectIn3DSpace
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public static Point3D operator+(Point3D origin, Vector3 vector)
        {
            return (Point3D)Utilities.AddCordinates(origin, vector);
        }

        public static Point3D operator+(Point3D origin, Point3D point)
        {
            return (Point3D)Utilities.AddCordinates(origin, point);
        }

        public static bool ArePointsEqual(Point3D point1, Point3D point2)
        {
            return MathHelper.AreNumbersEqual(point1.X, point2.X) 
                && MathHelper.AreNumbersEqual(point1.Y, point2.Y) 
                && MathHelper.AreNumbersEqual(point1.Z, point2.Z);
        }
    }
}
