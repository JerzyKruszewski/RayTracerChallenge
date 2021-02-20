using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public interface IColor
    {
        public float Red { get; set; }

        public float Green { get; set; }

        public float Blue { get; set; }
    }
}
