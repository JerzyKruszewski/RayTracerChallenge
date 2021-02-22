using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public interface IColor
    {
        public double Red { get; set; }

        public double Green { get; set; }

        public double Blue { get; set; }
    }
}
