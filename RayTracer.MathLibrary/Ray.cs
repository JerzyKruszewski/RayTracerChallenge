using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Ray
    {
        public readonly Point3D _origin;

        public readonly Vector3 _direction;

        public Ray()
        {

        }

        public Ray(Point3D origin, Vector3 direction)
        {
            _origin = origin;
            _direction = direction;
        }

        public Point3D Position(double time)
        {
            return _origin + _direction * time;
        }
    }
}
