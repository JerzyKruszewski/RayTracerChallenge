using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests
{
    public class Matrix3x3Tests
    {
        [Test]
        [TestCase(1f, 0f, 0f,
                  0f, 1f, 0f,
                  0f, 0f, 1f,
                  1f, 0f, 0f,
                  0f, 1f, 0f,
                  0f, 0f, 1f)]
        public void Matrix3x3Constructor_WhenCalled_CreateMatrix(float expected00, float expected01, float expected02,
                                                                 float expected10, float expected11, float expected12,
                                                                 float expected20, float expected21, float expected22,
                                                                 float arg00, float arg01, float arg02,
                                                                 float arg10, float arg11, float arg12,
                                                                 float arg20, float arg21, float arg22)
        {
            float[,] expected = new float[3, 3]
            {
                { expected00, expected01, expected02 },
                { expected10, expected11, expected12 },
                { expected20, expected21, expected22 }
            };

            Matrix3x3 matrix = new Matrix3x3(arg00, arg01, arg02,
                                             arg10, arg11, arg12,
                                             arg20, arg21, arg22);

            Assert.AreEqual(expected, matrix._matrix);
        }
    }
}
