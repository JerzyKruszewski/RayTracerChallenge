using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RayTracer.MathLibrary.Tests
{
    public class UtilitiesTests
    {
        [Test]
        [TestCase(0f, 0f, 0f)]
        public void CastPointToVector_WhenCalledWithPoint_CastItToVector(double argX, double argY, double argZ)
        {
            Assert.IsInstanceOf<Vector3>(Utilities.CastPointToVector(new Point3D()
            {
                X = argX,
                Y = argY,
                Z = argZ
            }));
        }

        [Test]
        [TestCase(1, 0.9)]
        [TestCase(1, 1.1)]
        [TestCase(-1, -0.9)]
        [TestCase(-1, -1.1)]
        [TestCase(1, 1)]
        [TestCase(-1, -1)]
        [TestCase(1, 0.50001)]
        [TestCase(1, 1.00001)]
        [TestCase(-1, -0.50001)]
        [TestCase(-1, -1.00001)]
        public void CastDoubleToInt_WhenCalledWithDouble_CastToInt(int expected, double number)
        {
            Assert.AreEqual(expected, Utilities.CastDoubleToInt(number));
        }
    }
}
