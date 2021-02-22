using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Point3D : IObjectIn3DSpace
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Point3D()
        {

        }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point3D operator +(Point3D origin, Vector3 vector)
        {
            return new Point3D(origin.X + vector.X, origin.Y + vector.Y, origin.Z + vector.Z);
        }

        public static Point3D operator +(Point3D origin, Point3D point)
        {
            return new Point3D(origin.X + point.X, origin.Y + point.Y, origin.Z + point.Z);
        }

        public static Point3D operator -(Point3D origin, Vector3 vector)
        {
            return new Point3D(origin.X - vector.X, origin.Y - vector.Y, origin.Z - vector.Z);
        }

        public static Vector3 operator -(Point3D origin, Point3D point)
        {
            return new Vector3(origin.X - point.X, origin.Y - point.Y, origin.Z - point.Z);
        }

        public static Point3D operator *(Point3D origin, double scalar)
        {
            return new Point3D(origin.X * scalar, origin.Y * scalar, origin.Z * scalar);
        }

        public static Point3D operator /(Point3D origin, double scalar)
        {
            return new Point3D(origin.X / scalar, origin.Y / scalar, origin.Z / scalar);
        }
    }
}
