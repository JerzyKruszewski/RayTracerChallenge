using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLib;

public class Intersection(double time, IShape shape)
{
    private readonly double _intersectionTime = time;

    private readonly IShape _object = shape;

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
