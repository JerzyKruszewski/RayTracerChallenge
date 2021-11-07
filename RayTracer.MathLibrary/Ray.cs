using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Ray
    {
        private readonly Point3D _origin;

        private readonly Vector3 _direction;

        private readonly IList<Intersection> _intersections = new List<Intersection>();

        public Ray()
        {

        }

        public Ray(Point3D origin, Vector3 direction)
        {
            _origin = origin;
            _direction = direction;
        }

        public Point3D Origin => _origin;

        public Vector3 Direction => _direction;

        public IList<Intersection> Intersections => _intersections;

        public Point3D Position(double time)
        {
            return _origin + _direction * time;
        }

        public IList<Intersection> IntersectWithSphere(Sphere sphere)
        {
            Ray transformedRay = this.Transform(Matrix4x4.Inverse(sphere.Transformation));

            Vector3 sphereOriginToRayOrigin = transformedRay.Origin - sphere.Origin;

            double a = Vector3.Dot(transformedRay.Direction, transformedRay.Direction);
            double b = 2 * Vector3.Dot(transformedRay.Direction, sphereOriginToRayOrigin);
            double c = Vector3.Dot(sphereOriginToRayOrigin, sphereOriginToRayOrigin) - sphere.Radius * sphere.Radius;

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                AddIntersection(new Intersection((-b + Math.Sqrt(discriminant)) / (2 * a), sphere));
                AddIntersection(new Intersection((-b - Math.Sqrt(discriminant)) / (2 * a), sphere));
            }
            else if (discriminant == 0)
            {
                AddIntersection(new Intersection((-b) / (2 * a), sphere));
                AddIntersection(new Intersection((-b) / (2 * a), sphere));
            }

            return Intersections;
        }

        public void AddIntersection(Intersection intersection)
        {
            Intersections.Add(intersection);
        }

        public double? Hit()
        {
            if (Intersections.Count == 0)
            {
                return null;
            }

            double min = Double.MaxValue;

            foreach (Intersection intersection in Intersections)
            {
                if (intersection.IntersectionTime >= 0.0 && intersection.IntersectionTime < min)
                {
                    min = intersection.IntersectionTime;
                }
            }

            //Only negative numbers
            if (min == Double.MaxValue)
            {
                return null;
            }

            return min;
        }

        public Ray Transform(Matrix4x4 matrix)
        {
            return new Ray(matrix * _origin, matrix * _direction);
        }
    }
}
