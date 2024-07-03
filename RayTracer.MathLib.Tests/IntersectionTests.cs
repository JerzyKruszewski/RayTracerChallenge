using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests;

public class IntersectionTests
{
    [Fact]
    public void Object_WhenIntersectedWithSphere_ReturnSphereObject()
    {
        Sphere sphere = new Sphere(0);

        Intersection intersection = new Intersection(0.0, sphere);

        intersection.Object.Should().BeOfType<Sphere>();
    }
}
