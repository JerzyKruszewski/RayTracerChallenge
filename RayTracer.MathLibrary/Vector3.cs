using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Vector3 : IObjectIn3DSpace
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double W { get; set; } = 0;

        public double Magnitude
        {
            get
            {
                return (double)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector3()
        {

        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Vector3 operator +(Vector3 origin, Vector3 vector)
        {
            return new Vector3(origin.X + vector.X, origin.Y + vector.Y, origin.Z + vector.Z);
        }

        public static Vector3 operator -(Vector3 origin, Vector3 vector)
        {
            return new Vector3(origin.X - vector.X, origin.Y - vector.Y, origin.Z - vector.Z);
        }

        public static Vector3 operator *(Vector3 origin, double scalar)
        {
            return new Vector3(origin.X * scalar, origin.Y * scalar, origin.Z * scalar);
        }

        public static Vector3 operator /(Vector3 origin, double scalar)
        {
            return new Vector3(origin.X / scalar, origin.Y / scalar, origin.Z / scalar);
        }

        public static bool operator ==(Vector3 arg1, Vector3 arg2)
        {
            return arg1.X == arg2.X &&
                   arg1.Y == arg2.Y &&
                   arg1.Z == arg2.Z &&
                   arg1.W == arg2.W;
        }

        public static bool operator !=(Vector3 arg1, Vector3 arg2)
        {
            return arg1.X != arg2.X ||
                   arg1.Y != arg2.Y ||
                   arg1.Z != arg2.Z ||
                   arg1.W != arg2.W;
        }

        public static Vector3 NegateVector(Vector3 vector)
        {
            return new Vector3()
            {
                X = -vector.X,
                Y = -vector.Y,
                Z = -vector.Z
            };
        }

        public static Vector3 Normalize(Vector3 vector)
        {
            double lenght = vector.Magnitude;

            vector.X /= lenght;
            vector.Y /= lenght;
            vector.Z /= lenght;

            return vector;
        }

        public static double Dot(Vector3 arg1, Vector3 arg2)
        {
            return arg1.X * arg2.X + arg1.Y * arg2.Y + arg1.Z * arg2.Z;
        }

        public static Vector3 Cross(Vector3 arg1, Vector3 arg2)
        {
            return new Vector3()
            {
                X = arg1.Y * arg2.Z - arg1.Z * arg2.Y,
                Y = arg1.Z * arg2.X - arg1.X * arg2.Z,
                Z = arg1.X * arg2.Y - arg1.Y * arg2.X
            };
        }
    }
}
