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

        [Test]
        [TestCase(30f, 36f, 42f,
                  66f, 81f, 96f,
                  102f, 126f, 150f,
                  1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 9f,
                  1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 9f)]
        public void MatrixMultiplication_WhenCalledWith2Matrixes_PerformMatrixMultipliaction(float expected00, float expected01, float expected02,
                                                                                             float expected10, float expected11, float expected12,
                                                                                             float expected20, float expected21, float expected22,
                                                                                             float argA00, float argA01, float argA02,
                                                                                             float argA10, float argA11, float argA12,
                                                                                             float argA20, float argA21, float argA22,
                                                                                             float argB00, float argB01, float argB02,
                                                                                             float argB10, float argB11, float argB12,
                                                                                             float argB20, float argB21, float argB22)
        {
            float[,] expected = new float[3, 3]
            {
                { expected00, expected01, expected02 },
                { expected10, expected11, expected12 },
                { expected20, expected21, expected22 }
            };

            Matrix3x3 matrixA = new Matrix3x3(argA00, argA01, argA02,
                                              argA10, argA11, argA12,
                                              argA20, argA21, argA22);

            Matrix3x3 matrixB = new Matrix3x3(argB00, argB01, argB02,
                                              argB10, argB11, argB12,
                                              argB20, argB21, argB22);

            Assert.AreEqual(expected, (matrixA * matrixB)._matrix);
        }

        [Test]
        [TestCase(14f, 32f, 50f,
                  1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 9f,
                  1f, 2f, 3f)]
        public void MatrixMultiplication_WhenCalledWithMatrixAndVector_PerformMatrixMultipliaction(float expectedX, float expectedY, float expectedZ,
                                                                                                   float argA00, float argA01, float argA02,
                                                                                                   float argA10, float argA11, float argA12,
                                                                                                   float argA20, float argA21, float argA22,
                                                                                                   float argX, float argY, float argZ)
        {
            Vector3 expected = new Vector3(expectedX, expectedY, expectedZ);

            Matrix3x3 matrix = new Matrix3x3(argA00, argA01, argA02,
                                              argA10, argA11, argA12,
                                              argA20, argA21, argA22);

            Vector3 vector = new Vector3(argX, argY, argZ);

            Assert.IsTrue(Utilities.AreObjectEquals(expected, (matrix * vector)));
        }

        [Test]
        [TestCase(1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 9f,
                  1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 9f)]
        public void MatrixCompare_WhenCalledWith2SameMatrixes_ReturnIfMatrixesAreSame(float argA00, float argA01, float argA02,
                                                                                      float argA10, float argA11, float argA12,
                                                                                      float argA20, float argA21, float argA22,
                                                                                      float argB00, float argB01, float argB02,
                                                                                      float argB10, float argB11, float argB12,
                                                                                      float argB20, float argB21, float argB22)
        {
            Matrix3x3 matrixA = new Matrix3x3(argA00, argA01, argA02,
                                              argA10, argA11, argA12,
                                              argA20, argA21, argA22);

            Matrix3x3 matrixB = new Matrix3x3(argB00, argB01, argB02,
                                              argB10, argB11, argB12,
                                              argB20, argB21, argB22);

            Assert.IsTrue(matrixA == matrixB);
        }

        [Test]
        [TestCase(1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 9f,
                  1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 9f)]
        public void MatrixCompare_WhenCalledWith2DifferentMatrixes_ReturnIfMatrixesAreDifferent(float argA00, float argA01, float argA02,
                                                                                                float argA10, float argA11, float argA12,
                                                                                                float argA20, float argA21, float argA22,
                                                                                                float argB00, float argB01, float argB02,
                                                                                                float argB10, float argB11, float argB12,
                                                                                                float argB20, float argB21, float argB22)
        {
            Matrix3x3 matrixA = new Matrix3x3(argA00, argA01, argA02,
                                              argA10, argA11, argA12,
                                              argA20, argA21, argA22);

            Matrix3x3 matrixB = new Matrix3x3(argB00, argB01, argB02,
                                              argB10, argB11, argB12,
                                              argB20, argB21, argB22);

            Assert.IsTrue(matrixA != matrixB);
        }

        [Test]
        [TestCase(1f, 4f, 7f,
                  2f, 5f, 8f,
                  3f, 6f, 9f,
                  1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 9f)]
        [TestCase(1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 9f,
                  1f, 4f, 7f,
                  2f, 5f, 8f,
                  3f, 6f, 9f)]
        public void Transpose_WhenCalled_TransposeMatrix(float expected00, float expected01, float expected02,
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

            Assert.AreEqual(expected, Matrix3x3.Transpose(matrix)._matrix);
        }

        [Test]
        [TestCase(5f, 1f, 0f, 0f,
                      0f, 5f, 0f,
                      0f, 0f, 1f)]
        public void Det_WhenCalled_CalculateDet(float expected, float arg00, float arg01, float arg02,
                                                                float arg10, float arg11, float arg12,
                                                                float arg20, float arg21, float arg22)
        {
            Matrix3x3 matrix = new Matrix3x3(arg00, arg01, arg02,
                                             arg10, arg11, arg12,
                                             arg20, arg21, arg22);

            Assert.AreEqual(expected, matrix.Det);
        }
    }
}
