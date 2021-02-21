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

        public Point3D()
        {

        }

        public Point3D(float x, float y, float z)
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

        public static Point3D operator *(Point3D origin, float scalar)
        {
            return new Point3D(origin.X * scalar, origin.Y * scalar, origin.Z * scalar);
        }

        public static Point3D operator /(Point3D origin, float scalar)
        {
            return new Point3D(origin.X / scalar, origin.Y / scalar, origin.Z / scalar);
        }
    }
}
