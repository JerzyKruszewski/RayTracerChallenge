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

        public int Id => _id;

        public Point3D Origin => _origin;

        public double Radius => _radius;

        public Matrix4x4 Transformation { get; set; } = Matrix4x4.IdentityMatrix;
    }
}
