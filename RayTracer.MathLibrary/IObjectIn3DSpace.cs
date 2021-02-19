using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public interface IObjectIn3DSpace
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }
    }
}
