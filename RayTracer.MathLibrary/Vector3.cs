using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Vector3 : IObjectIn3DSpace
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public static Vector3 operator +(Vector3 origin, Vector3 vector)
        {
            return (Vector3)Utilities.AddCordinates(origin, vector);
        }

        public static Vector3 operator -(Vector3 origin, Vector3 vector)
        {
            return (Vector3)Utilities.SubtractCordinates(origin, vector);
        }

        public static Vector3 operator *(Vector3 origin, float scalar)
        {
            return (Vector3)Utilities.MultiplyCordinatesByScalar(origin, scalar);
        }

        public static Vector3 operator /(Vector3 origin, float scalar)
        {
            return (Vector3)Utilities.DivideCordinatesByScalar(origin, scalar);
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
            float lenght = vector.Magnitude;

            vector.X /= lenght;
            vector.Y /= lenght;
            vector.Z /= lenght;

            return vector;
        }

        public static float Dot(Vector3 arg1, Vector3 arg2)
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
