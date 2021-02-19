using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests
{
    public class Point3DTests
    {
        [Test]
        public void AdditionOperator_WhenCalledWithTwoPoints_ReturnPointWithCombinedCordinates()
        {
            Point3D point1 = new Point3D()
            {
                X = 0,
                Y = 0,
                Z = 1
            };

            Point3D point2 = new Point3D()
            {
                X = 1,
                Y = -1,
                Z = -1
            };

            Point3D expected = new Point3D()
            {
                X = 1,
                Y = -1,
                Z = 0
            };

            Assert.AreEqual(true, Point3D.ArePointsEqual(expected, point1 + point2));
        }

        [Test]
        public void AdditionOperator_WhenCalledWithPointAndVector_ReturnPointWithCombinedCordinates()
        {
            Point3D point = new Point3D()
            {
                X = 0,
                Y = 0,
                Z = 1
            };

            Vector3 vector = new Vector3()
            {
                X = 1,
                Y = -1,
                Z = -1
            };

            Point3D expected = new Point3D()
            {
                X = 1,
                Y = -1,
                Z = 0
            };

            Assert.AreEqual(true, Point3D.ArePointsEqual(expected, point + vector));
        }
    }
}
