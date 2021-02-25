using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RayTracer.MathLibrary.Tests
{
    public class RayTests
    {
        [Test]
        [TestCase(2, 3, 4,
                  2, 3, 4,
                  1, 0, 0,
                  0)]
        [TestCase(3, 3, 4,
                  2, 3, 4,
                  1, 0, 0,
                  1)]
        [TestCase(1, 3, 4,
                  2, 3, 4,
                  1, 0, 0,
                  -1)]
        [TestCase(4.5, 3, 4,
                  2, 3, 4,
                  1, 0, 0,
                  2.5)]
        public void Position_WhenCalled_ReturnPointRepresentingPositionOfRay(double expectedX, double expectedY, double expectedZ,
                                                                             double originX, double originY, double originZ,
                                                                             double directionX, double directionY, double directionZ,
                                                                             double time)
        {
            Point3D expected = new Point3D(expectedX, expectedY, expectedZ);

            Ray ray = new Ray(new Point3D(originX, originY, originZ), new Vector3(directionX, directionY, directionZ));

            Assert.IsTrue(Utilities.AreObjectEquals(expected, ray.Position(time)));
        }
    }
}
