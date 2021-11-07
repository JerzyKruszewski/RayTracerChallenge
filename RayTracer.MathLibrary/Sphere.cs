using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Sphere : IShape
    {
        private readonly int _id;

        private readonly Point3D _origin;

        private readonly double _radius;

        public Sphere(int id)
        {
            _id = id;
        }

        public Sphere(int id, Point3D origin, double radius = 1.0)
            : this(id)
        { 
            _origin = origin;
            _radius = radius;
        }

        public int Id 
        { 
            get
            {
                return _id;
            }
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
