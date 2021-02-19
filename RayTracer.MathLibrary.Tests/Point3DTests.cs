using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests
{
    public class Point3DTests
    {
        [Test]
        [TestCase(1f, -1f, 0f, 0f, 0f, 1f, 1f, -1f, -1f)]
        [TestCase(1f, 1f, 6f, 3f, -2f, 5f, -2f, 3f, 1f)]
        public void AdditionOperator_WhenCalledWithTwoPoints_ReturnPointWithCombinedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                               float arg1X, float arg1Y, float arg1Z,
                                                                                               float arg2X, float arg2Y, float arg2Z)
        {
            Point3D point1 = new Point3D()
            {
                X = arg1X,
                Y = arg1Y,
                Z = arg1Z
            };

            Point3D point2 = new Point3D()
            {
                X = arg2X,
                Y = arg2Y,
                Z = arg2Z
            };

            Point3D expected = new Point3D()
            {
                X = expectedX,
                Y = expectedY,
                Z = expectedZ
            };

            Assert.IsTrue(Utilities.AreObjectEquals(expected, point1 + point2));
        }

        [Test]
        [TestCase(1f, -1f, 0f, 0f, 0f, 1f, 1f, -1f, -1f)]
        [TestCase(1f, 1f, 6f, 3f, -2f, 5f, -2f, 3f, 1f)]
        public void AdditionOperator_WhenCalledWithPointAndVector_ReturnPointWithCombinedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                                    float arg1X, float arg1Y, float arg1Z,
                                                                                                    float arg2X, float arg2Y, float arg2Z)
        {
            Point3D point = new Point3D()
            {
                X = arg1X,
                Y = arg1Y,
                Z = arg1Z
            };

            Vector3 vector = new Vector3()
            {
                X = arg2X,
                Y = arg2Y,
                Z = arg2Z
            };

            Point3D expected = new Point3D()
            {
                X = expectedX,
                Y = expectedY,
                Z = expectedZ
            };

            Assert.IsTrue(Utilities.AreObjectEquals(expected, point + vector));
        }

        [Test]
        [TestCase(-1f, 1f, 2f, 0f, 0f, 1f, 1f, -1f, -1f)]
        [TestCase(-2f, -4f, -6f, 3f, 2f, 1f, 5f, 6f, 7f)]
        public void SubtractionOperator_WhenCalledWithTwoPoints_ReturnPointWithSubtractedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                                    float arg1X, float arg1Y, float arg1Z,
                                                                                                    float arg2X, float arg2Y, float arg2Z)
        {
            Point3D point1 = new Point3D()
            {
                X = arg1X,
                Y = arg1Y,
                Z = arg1Z
            };

            Point3D point2 = new Point3D()
            {
                X = arg2X,
                Y = arg2Y,
                Z = arg2Z
            };

            Vector3 expected = new Vector3()
            {
                X = expectedX,
                Y = expectedY,
                Z = expectedZ
            };

            Assert.IsTrue(Utilities.AreObjectEquals(expected, point1 - point2));
        }

        [Test]
        [TestCase(-1f, 1f, 2f, 0f, 0f, 1f, 1f, -1f, -1f)]
        [TestCase(-2f, -4f, -6f, 3f, 2f, 1f, 5f, 6f, 7f)]
        public void SubtractionOperator_WhenCalledWithPointAndVector_ReturnPointWithSubtractedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                                         float arg1X, float arg1Y, float arg1Z,
                                                                                                         float arg2X, float arg2Y, float arg2Z)
        {
            Point3D point = new Point3D()
            {
                X = arg1X,
                Y = arg1Y,
                Z = arg1Z
            };

            Vector3 vector = new Vector3()
            {
                X = arg2X,
                Y = arg2Y,
                Z = arg2Z
            };

            Point3D expected = new Point3D()
            {
                X = expectedX,
                Y = expectedY,
                Z = expectedZ
            };

            Assert.IsTrue(Utilities.AreObjectEquals(expected, point - vector));
        }

        [Test]
        [TestCase(2f, 2f, 2f, 1f, 1f, 1f, 2f)]
        [TestCase(3f, 3f, 3f, 2f, 2f, 2f, 1.5f)]
        [TestCase(3.5f, -7f, 10.5f, 1f, -2f, 3f, 3.5f)]
        [TestCase(0.5f, -1f, 1.5f, 1f, -2f, 3f, 0.5f)]
        public void MultiplyOperator_WhenCalledWithPointAndScalar_ReturnMultipliedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                             float argX, float argY, float argZ, float scalar)
        {
            Point3D expected = new Point3D()
            {
                X = expectedX,
                Y = expectedY,
                Z = expectedZ
            };

            Point3D point = new Point3D()
            {
                X = argX,
                Y = argY,
                Z = argZ
            };

            Assert.IsTrue(Utilities.AreObjectEquals(expected, point * scalar));
        }

        [Test]
        [TestCase(1f, 1f, 1f, 2f, 2f, 2f, 2f)]
        [TestCase(2f, 2f, 2f, 3f, 3f, 3f, 1.5f)]
        [TestCase(0.5f, -1f, 1.5f, 1f, -2f, 3f, 2f)]
        public void DivideOperator_WhenCalledWithPointAndScalar_ReturnMultipliedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                           float argX, float argY, float argZ, float scalar)
        {
            Point3D expected = new Point3D()
            {
                X = expectedX,
                Y = expectedY,
                Z = expectedZ
            };

            Point3D point = new Point3D()
            {
                X = argX,
                Y = argY,
                Z = argZ
            };

            Assert.IsTrue(Utilities.AreObjectEquals(expected, point / scalar));
        }
    }
}
