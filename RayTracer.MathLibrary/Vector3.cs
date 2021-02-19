﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Vector3 : IObjectIn3DSpace
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

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
    }
}
