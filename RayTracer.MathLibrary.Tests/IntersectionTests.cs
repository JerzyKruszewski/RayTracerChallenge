using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests
{
    [TestFixture]
    public class IntersectionTests
    {
        [Test]
        public void Object_WhenIntersectedWithSphere_ReturnSphereObject()
        {
            Sphere sphere = new Sphere(0);

            Intersection intersection = new Intersection(0.0, sphere);

            Assert.IsInstanceOf<Sphere>(intersection.Object);
        }
    }
}
