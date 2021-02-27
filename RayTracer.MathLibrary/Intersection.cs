using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Intersection
    {
        private readonly double _intersectionTime;

        private readonly IShape _object;

        public Intersection()
        {

        }

        public Intersection(double time, IShape shape)
        {
            _intersectionTime = time;
            _object = shape;
        }

        public double IntersectionTime
        {
            get
            {
                return _intersectionTime;
            }
        }

        public IShape Object
        {
            get
            {
                return _object;
            }
        }
    }
}
