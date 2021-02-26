using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Intersection
    {
        private static readonly IList<Intersection> _intersections = new List<Intersection>();

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

        public static void AddIntersection(Intersection intersection)
        {
            _intersections.Add(intersection);
        }

        public static IEnumerable<Intersection> GetIntersections()
        {
            return _intersections;
        }
    }
}
