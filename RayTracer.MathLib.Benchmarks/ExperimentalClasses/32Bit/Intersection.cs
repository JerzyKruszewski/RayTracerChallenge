using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLib.Benchmarks.ExperimentalClasses._32Bit;

public class Intersection(float time, IShape shape)
{
    private readonly float _intersectionTime = time;

    private readonly IShape _object = shape;

    public float IntersectionTime
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
