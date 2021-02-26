using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Sphere
    {
        private readonly Point3D _origin;

        private readonly double _radius;

        public Sphere()
        {

        }

        public Sphere(Point3D origin, double radius = 1.0)
        {
            _origin = origin;
            _radius = radius;
        }

        public Point3D Origin
        {
            get
            {
                return _origin;
            }
        }

        public double Radius
        {
            get
            {
                return _radius;
            }
        }
    }
}
