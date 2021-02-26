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

        [Test]
        //Stright through
        [TestCase(0, 0, -5,
                  0, 0, 1,
                  0, 0, 0,
                  2)]
        //At a tangent
        [TestCase(0, 1, -5,
                  0, 0, 1,
                  0, 0, 0,
                  2)]
        //Miss a sphere
        [TestCase(0, 2, -5,
                  0, 0, 1,
                  0, 0, 0,
                  0)]
        //Ray inside sphere
        [TestCase(0, 0, 0,
                  0, 0, 1,
                  0, 0, 0,
                  2)]
        //Sphere behind ray
        [TestCase(0, 0, 5,
                  0, 0, 1,
                  0, 0, 0,
                  2)]
        public void IntersectWithSphere_WhenCalled_ReturnIntersectionsCountWithSphere(double rayOriginX, double rayOriginY, double rayOriginZ,
                                                                                      double directionX, double directionY, double directionZ,
                                                                                      double sphereOriginX, double sphereOriginY, double sphereOriginZ,
                                                                                      int expectedIntersections)
        {
            Ray ray = new Ray(new Point3D(rayOriginX, rayOriginY, rayOriginZ), new Vector3(directionX, directionY, directionZ));
            Sphere sphere = new Sphere(new Point3D(sphereOriginX, sphereOriginY, sphereOriginZ));

            Assert.AreEqual(expectedIntersections, ray.IntersectWithSphere(sphere).Count);
        }

        [Test]
        //Stright through
        [TestCase(0, 0, -5,
                  0, 0, 1,
                  0, 0, 0,
                  4)]
        [TestCase(0, 0, -5,
                  0, 0, 1,
                  0, 0, 0,
                  6)]
        //At a tangent
        [TestCase(0, 1, -5,
                  0, 0, 1,
                  0, 0, 0,
                  5)]
        //Ray inside sphere
        [TestCase(0, 0, 0,
                  0, 0, 1,
                  0, 0, 0,
                  1)]
        [TestCase(0, 0, 0,
                  0, 0, 1,
                  0, 0, 0,
                  -1)]
        //Sphere behind ray
        [TestCase(0, 0, 5,
                  0, 0, 1,
                  0, 0, 0,
                  -4)]
        [TestCase(0, 0, 5,
                  0, 0, 1,
                  0, 0, 0,
                  -6)]
        public void IntersectWithSphere_WhenCalled_CheckIfIntersectionWasFound(double rayOriginX, double rayOriginY, double rayOriginZ,
                                                                               double directionX, double directionY, double directionZ,
                                                                               double sphereOriginX, double sphereOriginY, double sphereOriginZ,
                                                                               double expectedIntersection)
        {
            Ray ray = new Ray(new Point3D(rayOriginX, rayOriginY, rayOriginZ), new Vector3(directionX, directionY, directionZ));
            Sphere sphere = new Sphere(new Point3D(sphereOriginX, sphereOriginY, sphereOriginZ));

            Assert.IsTrue(ray.IntersectWithSphere(sphere).Contains(expectedIntersection));
        }
    }
}
