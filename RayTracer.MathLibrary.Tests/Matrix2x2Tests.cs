using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace RayTracer.MathLibrary.Tests
{
    public class Matrix2x2Tests
    {
        [Test]
        [TestCase(1f, 0f,
                  0f, 1f,
                  1f, 0f,
                  0f, 1f)]
        public void Matrix2x2Constructor_WhenCalled_CreateMatrix(double expected00, double expected01,
                                                                 double expected10, double expected11,
                                                                 double arg00, double arg01,
                                                                 double arg10, double arg11)
        {
            double[,] expected = new double[2, 2]
            {
                { expected00, expected01 },
                { expected10, expected11 }
            };

            Matrix2x2 matrix = new Matrix2x2(arg00, arg01,
                                             arg10, arg11);

            Assert.AreEqual(expected, matrix._matrix);
        }

        [Test]
        [TestCase(19, 22,
                  43, 50,
                  1f, 2f,
                  3f, 4f,
                  5f, 6f,
                  7f, 8f)]
        public void MatrixMultiplication_WhenCalledWith2Matrixes_PerformMatrixMultipliaction(double expected00, double expected01,
                                                                                             double expected10, double expected11,
                                                                                             double argA00, double argA01,
                                                                                             double argA10, double argA11,
                                                                                             double argB00, double argB01,
                                                                                             double argB10, double argB11)
        {
            double[,] expected = new double[2, 2]
            {
                { expected00, expected01 },
                { expected10, expected11 }
            };

            Matrix2x2 matrixA = new Matrix2x2(argA00, argA01,
                                              argA10, argA11);

            Matrix2x2 matrixB = new Matrix2x2(argB00, argB01,
                                              argB10, argB11);

            Assert.AreEqual(expected, (matrixA * matrixB)._matrix);
        }

        [Test]
        [TestCase(1f, 2f,
                  4f, 5f,
                  1f, 2f,
                  4f, 5f)]
        public void MatrixCompare_WhenCalledWith2SameMatrixes_ReturnIfMatrixesAreSame(double argA00, double argA01,
                                                                                      double argA10, double argA11,
                                                                                      double argB00, double argB01,
                                                                                      double argB10, double argB11)
        {
            Matrix2x2 matrixA = new Matrix2x2(argA00, argA01,
                                              argA10, argA11);

            Matrix2x2 matrixB = new Matrix2x2(argB00, argB01,
                                              argB10, argB11);

            Assert.IsTrue(matrixA == matrixB);
        }

        [Test]
        [TestCase(1f, 2f,
                  4f, 5f,
                  1f, 2f,
                  4f, 6f)]
        public void MatrixCompare_WhenCalledWith2DifferentMatrixes_ReturnIfMatrixesAreDifferent(double argA00, double argA01,
                                                                                                double argA10, double argA11,
                                                                                                double argB00, double argB01,
                                                                                                double argB10, double argB11)
        {
            Matrix2x2 matrixA = new Matrix2x2(argA00, argA01,
                                              argA10, argA11);

            Matrix2x2 matrixB = new Matrix2x2(argB00, argB01,
                                              argB10, argB11);

            Assert.IsTrue(matrixA != matrixB);
        }

        [Test]
        [TestCase(1f, 4f,
                  2f, 5f,
                  1f, 2f,
                  4f, 5f)]
        public void Transpose_WhenCalled_TransposeMatrix(double expected00, double expected01,
                                                         double expected10, double expected11,
                                                         double arg00, double arg01,
                                                         double arg10, double arg11)
        {
            double[,] expected = new double[2, 2]
            {
                { expected00, expected01 },
                { expected10, expected11 }
            };

            Matrix2x2 matrix = new Matrix2x2(arg00, arg01,
                                             arg10, arg11);

            Assert.AreEqual(expected, Matrix2x2.Transpose(matrix)._matrix);
        }

        [Test]
        [TestCase(5f, 1f, 0f,
                      0f, 5f)]
        public void Det_WhenCalled_CalculateDet(double expected, double arg00, double arg01,
                                                                 double arg10, double arg11)
        {
            Matrix2x2 matrix = new Matrix2x2(arg00, arg01,
                                             arg10, arg11);

            Assert.AreEqual(expected, matrix.Det);
        }

        [Test]
        [TestCase(4, 3,
                  3, 2,
                  -2, 3,
                  3, -4)]
        public void Inverse_WhenCalled_InverseMatrix(double expected00, double expected01,
                                                     double expected10, double expected11,
                                                     double arg00, double arg01,
                                                     double arg10, double arg11)
        {
            double[,] expected = new double[2, 2]
            {
                { expected00, expected01 },
                { expected10, expected11 }
            };

            Matrix2x2 matrix = new Matrix2x2(arg00, arg01,
                                             arg10, arg11);

            Assert.AreEqual(expected, Matrix2x2.Inverse(matrix)._matrix);
        }

        [Test]
        [TestCase(30f, 36f,
                  66f, 81f)]
        public void Inverse_WhenCalledTwice_ReturnOriginalMatrix(double arg00, double arg01,
                                                                 double arg10, double arg11)
        {
            Matrix2x2 expected = new Matrix2x2(arg00, arg01,
                                               arg10, arg11);

            Matrix2x2 matrix = new Matrix2x2(arg00, arg01,
                                             arg10, arg11);

            Assert.IsTrue(expected == Matrix2x2.Inverse(Matrix2x2.Inverse(matrix)));
        }
    }
}
