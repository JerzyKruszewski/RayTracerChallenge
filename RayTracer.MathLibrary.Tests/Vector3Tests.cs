using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RayTracer.MathLibrary.Tests
{
    public class Vector3Tests
    {
        [Test]
        [TestCase(1f, -1f, 0f, 0f, 0f, 1f, 1f, -1f, -1f)]
        public void AdditionOperator_WhenCalledWithTwoPoints_ReturnPointWithCombinedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                               float arg1X, float arg1Y, float arg1Z,
                                                                                               float arg2X, float arg2Y, float arg2Z)
        {
            Vector3 vector1 = new Vector3()
            {
                X = arg1X,
                Y = arg1Y,
                Z = arg1Z
            };

            Vector3 vector2 = new Vector3()
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

            Assert.AreEqual(true, Utilities.AreObjectEquals(expected, vector1 + vector2));
        }

        [Test]
        [TestCase(-1f, 1f, 2f, 0f, 0f, 1f, 1f, -1f, -1f)]
        public void SubtractionOperator_WhenCalledWithTwoPoints_ReturnPointWithSubtractedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                                    float arg1X, float arg1Y, float arg1Z,
                                                                                                    float arg2X, float arg2Y, float arg2Z)
        {
            Vector3 vector1 = new Vector3()
            {
                X = arg1X,
                Y = arg1Y,
                Z = arg1Z
            };

            Vector3 vector2 = new Vector3()
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

            Assert.AreEqual(true, Utilities.AreObjectEquals(expected, vector1 - vector2));
        }

        [Test]
        [TestCase(2f, 2f, 2f, 1f, 1f, 1f, 2f)]
        [TestCase(3f, 3f, 3f, 2f, 2f, 2f, 1.5f)]
        public void MultiplyOperator_WhenCalledWithPointAndScalar_ReturnMultipliedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                             float argX, float argY, float argZ, float scalar)
        {
            Vector3 expected = new Vector3()
            {
                X = expectedX,
                Y = expectedY,
                Z = expectedZ
            };

            Vector3 vector = new Vector3()
            {
                X = argX,
                Y = argY,
                Z = argZ
            };

            Assert.AreEqual(true, Utilities.AreObjectEquals(expected, vector * scalar));
        }

        [Test]
        [TestCase(1f, 1f, 1f, 2f, 2f, 2f, 2f)]
        [TestCase(2f, 2f, 2f, 3f, 3f, 3f, 1.5f)]
        public void DivideOperator_WhenCalledWithPointAndScalar_ReturnMultipliedCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                           float argX, float argY, float argZ, float scalar)
        {
            Vector3 expected = new Vector3()
            {
                X = expectedX,
                Y = expectedY,
                Z = expectedZ
            };

            Vector3 vector = new Vector3()
            {
                X = argX,
                Y = argY,
                Z = argZ
            };

            Assert.AreEqual(true, Utilities.AreObjectEquals(expected, vector / scalar));
        }
    }
}
