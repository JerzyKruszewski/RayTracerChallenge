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
            return (Point3D)Utilities.AddCordinates(origin, vector);
        }

        public static Point3D operator +(Point3D origin, Point3D point)
        {
            return (Point3D)Utilities.AddCordinates(origin, point);
        }

        public static Point3D operator -(Point3D origin, Vector3 vector)
        {
            return (Point3D)Utilities.SubtractCordinates(origin, vector);
        }

        public static Vector3 operator -(Point3D origin, Point3D point)
        {
            return Utilities.CastPointToVector((Point3D)Utilities.SubtractCordinates(origin, point));
        }

        public static Point3D operator *(Point3D origin, float scalar)
        {
            return (Point3D)Utilities.MultiplyCordinatesByScalar(origin, scalar);
        }

        public static Point3D operator /(Point3D origin, float scalar)
        {
            return (Point3D)Utilities.DivideCordinatesByScalar(origin, scalar);
        }
    }
}
