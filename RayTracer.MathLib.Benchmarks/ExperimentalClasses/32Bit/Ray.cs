using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracer.MathLib.Benchmarks.ExperimentalClasses._32Bit;

public class Ray
{
    private readonly Point3D _origin;

    private readonly Vector3 _direction;

    private readonly List<Intersection> _intersections = [];

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

    public Point3D Position(float time)
    {
        return _origin + (_direction * time);
    }

    public IList<Intersection> IntersectWithSphere(Sphere sphere)
    {
        Ray transformedRay = Transform(Matrix4x4.Inverse(sphere.Transformation));

        Vector3 sphereOriginToRayOrigin = transformedRay.Origin - sphere.Origin;

        float a = Vector3.Dot(transformedRay.Direction, transformedRay.Direction);
        float b = 2 * Vector3.Dot(transformedRay.Direction, sphereOriginToRayOrigin);
        float c = Vector3.Dot(sphereOriginToRayOrigin, sphereOriginToRayOrigin) - (sphere.Radius * sphere.Radius);

        float discriminant = (b * b) - (4 * a * c);

        if (discriminant > 0)
        {
            AddIntersection(new Intersection((-b + MathF.Sqrt(discriminant)) / (2 * a), sphere));
            AddIntersection(new Intersection((-b - MathF.Sqrt(discriminant)) / (2 * a), sphere));
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
        _intersections.Add(intersection);
    }

    public float? Hit()
    {
        if (Intersections.Count == 0)
        {
            return null;
        }

        float min = Single.MaxValue;

        foreach (Intersection intersection in Intersections)
        {
            if (intersection.IntersectionTime >= 0.0 && intersection.IntersectionTime < min)
            {
                min = intersection.IntersectionTime;
            }
        }

        //Only negative numbers
        if (min == Single.MaxValue)
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
