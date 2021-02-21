using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RayTracer.MathLibrary.Tests
{
    public class Vector3Tests
    {
        [Test]
        [TestCase(1f, -1f, 0f, 0f, 0f, 1f, 1f, -1f, -1f)]
        [TestCase(1f, 1f, 6f, 3f, -2f, 5f, -2f, 3f, 1f)]
        [TestCase(0f, -4f, 0f, 0f, 0f, 0f, 0f, -4f, 0f)]
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

            Assert.IsTrue(Utilities.AreObjectEquals(expected, vector1 + vector2));
        }

        [Test]
        [TestCase(2f, -2f, -1f, 0f, 0f, 1f, 1f, -1f, -1f)]
        [TestCase(-1f, 4f, 7f, 3f, -2f, 5f, -2f, 3f, 1f)]
        [TestCase(0f, -8f, 0f, 0f, 0f, 0f, 0f, -4f, 0f)]
        //[TestCase()]
        public void DoubleAdditionOperator_WhenCalledWithTwoPoints_ReturnPointWithCombinedCordinates(float expectedX, float expectedY, float expectedZ,
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

            Assert.IsTrue(Utilities.AreObjectEquals(expected, (vector1 + vector2) + vector2));
        }

        [Test]
        [TestCase(-1f, 1f, 2f, 0f, 0f, 1f, 1f, -1f, -1f)]
        [TestCase(-2f, -4f, -6f, 3f, 2f, 1f, 5f, 6f, 7f)]
        [TestCase(0f, -4f, 0f, 0f, 0f, 0f, 0f, 4f, 0f)]
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

            Assert.IsTrue(Utilities.AreObjectEquals(expected, vector1 - vector2));
        }

        [Test]
        [TestCase(2f, 2f, 2f, 1f, 1f, 1f, 2f)]
        [TestCase(3f, 3f, 3f, 2f, 2f, 2f, 1.5f)]
        [TestCase(3.5f, -7f, 10.5f, 1f, -2f, 3f, 3.5f)]
        [TestCase(0.5f, -1f, 1.5f, 1f, -2f, 3f, 0.5f)]
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

            Assert.IsTrue(Utilities.AreObjectEquals(expected, vector * scalar));
        }

        [Test]
        [TestCase(1f, 1f, 1f, 2f, 2f, 2f, 2f)]
        [TestCase(2f, 2f, 2f, 3f, 3f, 3f, 1.5f)]
        [TestCase(0.5f, -1f, 1.5f, 1f, -2f, 3f, 2f)]
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

            Assert.IsTrue(Utilities.AreObjectEquals(expected, vector / scalar));
        }

        [Test]
        [TestCase(1f, 1f, 1f, -1f, -1f, -1f)]
        [TestCase(-2f, -2f, -2f, 2f, 2f, 2f)]
        [TestCase(1f, -2f, 3f, -1f, 2f, -3f)]
        public void NegateVector_WhenCalledWithVector_ReturnVectorWithOppositeCordinates(float expectedX, float expectedY, float expectedZ,
                                                                                         float argX, float argY, float argZ)
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

            Assert.IsTrue(Utilities.AreObjectEquals(expected, Vector3.NegateVector(vector)));
        }

        [Test]
        [TestCase(1f, 1f, 0f, 0f, 0f)]
        [TestCase(1f, 0f, -1f, 0f, 0f)]
        [TestCase(1f, 0f, 0f, 1f, 0f)]
        [TestCase(1.414f, 1f, 1f, 0f, 0.002f)]
        [TestCase(1.414f, 1f, 0f, -1f, 0.002f)]
        [TestCase(1.75f, 1f, 1f, 1f, 0.03f)]
        [TestCase(5f, 4f, 0f, 3f, 0f)]
        [TestCase(3.74165f, -1f, -2f, -3f, 0.00001f)]
        [TestCase(3.74165f, 1f, 2f, 3f, 0.00001f)]
        public void Magnitude_WhenCalled_ReturnLenghtOfVector(float expected, float argX, float argY, float argZ, float epsilon)
        {
            Vector3 vector = new Vector3()
            {
                X = argX,
                Y = argY,
                Z = argZ
            };

            Assert.AreEqual(expected, vector.Magnitude, epsilon);
        }

        [Test]
        [TestCase(-0.707f, -0.707f, 0f, -1f, -1f, 0f, 0.001f)]
        [TestCase(0f, 0.707f, 0.707f, 0f, 2f, 2f, 0.001f)]
        [TestCase(1f, 0f, 0f, 4f, 0f, 0f, 0.00001f)]
        [TestCase(0.26726f, 0.53452f, 0.80178f, 1f, 2f, 3f, 0.00001f)]
        public void Normalize_WhenCalledWithVector_ReturnNormalizedVector(float expectedX, float expectedY, float expectedZ,
                                                                          float argX, float argY, float argZ, float epsilon)
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

            Assert.IsTrue(Utilities.AreObjectEquals(expected, Vector3.Normalize(vector), epsilon));
        }

        [Test]
        [TestCase(-1f, -1f, 0f, 0.001f)]
        [TestCase(0f, 2f, 2f, 0.001f)]
        [TestCase(4f, 0f, 0f, 0f)]
        [TestCase(1f, 2f, 3f, 0.00001f)]
        public void Normalize_WhenCalledWithVector_ChecksIfItsMagnitudeIs1(float argX, float argY, float argZ, float epsilon)
        {
            Vector3 vector = new Vector3()
            {
                X = argX,
                Y = argY,
                Z = argZ
            };

            Assert.AreEqual(1f, Vector3.Normalize(vector).Magnitude, epsilon);
        }

        [Test]
        [TestCase(20f, 1f, 2f, 3f, 2f, 3f, 4f)]
        [TestCase(20f, 2f, 3f, 4f, 1f, 2f, 3f)]
        public void Dot_WhenCalledWithTwoVectors_ReturnDotProduct(float expected,
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

            Assert.AreEqual(expected, Vector3.Dot(vector1, vector2));
        }

        [Test]
        [TestCase(-1f, 2f, -1f, 1f, 2f, 3f, 2f, 3f, 4f)]
        [TestCase(1f, -2f, 1f, 2f, 3f, 4f, 1f, 2f, 3f)]
        public void Cross_WhenCalledWithTwoVectors_ReturnCrossProduct(float expectedX, float expectedY, float expectedZ,
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

            Assert.IsTrue(Utilities.AreObjectEquals(expected, Vector3.Cross(vector1, vector2)));
        }
    }
}
