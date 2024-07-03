using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLib;

public interface IObjectIn3DSpace
{
    public double X { get; set; }

    public double Y { get; set; }

    public double Z { get; set; }

    public double W { get; set; }
}
