using NUnit.Framework;
using System;

namespace RayTracer.MathLibrary.Tests
{
    public class MathHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0f, 0f, 0f)]
        public void CreateObjectIn3DSpace_WhenCalledWithPointCordinates_DoesCreatePoint(double x, double y, double z)
        {
            Assert.IsInstanceOf<Point3D>(MathHelper.CreateObjectIn3DSpace(Tuple.Create<double, double, double, double>(x, y, z, 1.0f)));
        }

        [Test]
        [TestCase(0f, 0f, 0f)]
        public void CreateObjectIn3DSpace_WhenCalledWithPointCordinates_DoesNotCreateVector(double x, double y, double z)
        {
            Assert.IsNotInstanceOf<Vector3>(MathHelper.CreateObjectIn3DSpace(Tuple.Create<double, double, double, double>(x, y, z, 1.0f)));
        }

        [Test]
        [TestCase(0f, 0f, 0f)]
        public void CreateObjectIn3DSpace_WhenCalledWithVectorCordinates_DoesCreateVector(double x, double y, double z)
        {
            Assert.IsInstanceOf<Vector3>(MathHelper.CreateObjectIn3DSpace(Tuple.Create<double, double, double, double>(x, y, z, 0.0f)));
        }

        [Test]
        [TestCase(0f, 0f, 0f)]
        public void CreateObjectIn3DSpace_WhenCalledWithVectorCordinates_DoesNotCreatePoint(double x, double y, double z)
        {
            Assert.IsNotInstanceOf<Point3D>(MathHelper.CreateObjectIn3DSpace(Tuple.Create<double, double, double, double>(x, y, z, 0.0f)));
        }

        [Test]
        [TestCase(true, 0f, 0.09f, 0.1f)]
        [TestCase(true, 0f, -0.09f, 0.1f)]
        [TestCase(true, 0f, 0.00009f, 0.0001f)]
        [TestCase(true, 0.000009f, 0f, 0.00001f)]
        [TestCase(false, 0f, 0.11f, 0.1f)]
        [TestCase(false, 1f, 0.09f, 0.1f)]
        public void AreNumbersEqual_WhenCalled_ReturnIfNumbersAreEqual(bool expected, double first, double second, double epsilon)
        {
            Assert.AreEqual(expected, MathHelper.AreNumbersEqual(first, second, epsilon));
        }
    }
}