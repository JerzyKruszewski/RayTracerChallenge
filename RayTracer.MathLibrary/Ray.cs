using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Ray
    {
        private readonly Point3D _origin;

        private readonly Vector3 _direction;

        private static IList<Intersection> _intersections = new List<Intersection>();

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

        public IList<Intersection> IntersectWithSphere(Sphere sphere)
        {
            Vector3 sphereOriginToRayOrigin = _origin - sphere.Origin;

            double a = Vector3.Dot(_direction, _direction);
            double b = 2 * Vector3.Dot(_direction, sphereOriginToRayOrigin);
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

            return GetIntersections();
        }

        public static void AddIntersection(Intersection intersection)
        {
            _intersections.Add(intersection);
        }

        public static IList<Intersection> GetIntersections()
        {
            return _intersections;
        }
    }
}
