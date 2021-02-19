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

        public static Vector3 operator+(Vector3 origin, Vector3 vector)
        {
            return (Vector3)Utilities.AddCordinates(origin, vector);
        }
    }
}
