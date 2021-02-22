﻿using NUnit.Framework;
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
        public void Matrix3x3Constructor_WhenCalled_CreateMatrix(double expected00, double expected01, double expected02,
                                                                 double expected10, double expected11, double expected12,
                                                                 double expected20, double expected21, double expected22,
                                                                 double arg00, double arg01, double arg02,
                                                                 double arg10, double arg11, double arg12,
                                                                 double arg20, double arg21, double arg22)
        {
            double[,] expected = new double[3, 3]
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
        public void MatrixMultiplication_WhenCalledWith2Matrixes_PerformMatrixMultipliaction(double expected00, double expected01, double expected02,
                                                                                             double expected10, double expected11, double expected12,
                                                                                             double expected20, double expected21, double expected22,
                                                                                             double argA00, double argA01, double argA02,
                                                                                             double argA10, double argA11, double argA12,
                                                                                             double argA20, double argA21, double argA22,
                                                                                             double argB00, double argB01, double argB02,
                                                                                             double argB10, double argB11, double argB12,
                                                                                             double argB20, double argB21, double argB22)
        {
            double[,] expected = new double[3, 3]
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
        public void MatrixMultiplication_WhenCalledWithMatrixAndVector_PerformMatrixMultipliaction(double expectedX, double expectedY, double expectedZ,
                                                                                                   double argA00, double argA01, double argA02,
                                                                                                   double argA10, double argA11, double argA12,
                                                                                                   double argA20, double argA21, double argA22,
                                                                                                   double argX, double argY, double argZ)
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
        public void MatrixCompare_WhenCalledWith2SameMatrixes_ReturnIfMatrixesAreSame(double argA00, double argA01, double argA02,
                                                                                      double argA10, double argA11, double argA12,
                                                                                      double argA20, double argA21, double argA22,
                                                                                      double argB00, double argB01, double argB02,
                                                                                      double argB10, double argB11, double argB12,
                                                                                      double argB20, double argB21, double argB22)
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
                  7f, 8f, 10f)]
        public void MatrixCompare_WhenCalledWith2DifferentMatrixes_ReturnIfMatrixesAreDifferent(double argA00, double argA01, double argA02,
                                                                                                double argA10, double argA11, double argA12,
                                                                                                double argA20, double argA21, double argA22,
                                                                                                double argB00, double argB01, double argB02,
                                                                                                double argB10, double argB11, double argB12,
                                                                                                double argB20, double argB21, double argB22)
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
        public void Transpose_WhenCalled_TransposeMatrix(double expected00, double expected01, double expected02,
                                                         double expected10, double expected11, double expected12,
                                                         double expected20, double expected21, double expected22,
                                                         double arg00, double arg01, double arg02,
                                                         double arg10, double arg11, double arg12,
                                                         double arg20, double arg21, double arg22)
        {
            double[,] expected = new double[3, 3]
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
        [TestCase(0f, 1f, 2f, 3f,
                      4f, 5f, 6f,
                      7f, 8f, 9f)]
        [TestCase(0f, 30f, 36f, 42f,
                      66f, 81f, 96f,
                      102f, 126f, 150f)]
        public void Det_WhenCalled_CalculateDet(double expected, double arg00, double arg01, double arg02,
                                                                double arg10, double arg11, double arg12,
                                                                double arg20, double arg21, double arg22)
        {
            Matrix3x3 matrix = new Matrix3x3(arg00, arg01, arg02,
                                             arg10, arg11, arg12,
                                             arg20, arg21, arg22);

            Assert.AreEqual(expected, matrix.Det);
        }

        [Test]
        [TestCase(1f, -2f, 2f,
                  0f, 0f, 1f,
                  -0.5f, 1.5f, -1f,
                  3f, -2f, 4f,
                  1f, 0f, 2f,
                  0f, 1f, 0f)]
        public void Inverse_WhenCalled_InverseMatrix(double expected00, double expected01, double expected02,
                                                     double expected10, double expected11, double expected12,
                                                     double expected20, double expected21, double expected22,
                                                     double arg00, double arg01, double arg02,
                                                     double arg10, double arg11, double arg12,
                                                     double arg20, double arg21, double arg22)
        {
            double[,] expected = new double[3, 3]
            {
                { expected00, expected01, expected02 },
                { expected10, expected11, expected12 },
                { expected20, expected21, expected22 }
            };

            Matrix3x3 matrix = new Matrix3x3(arg00, arg01, arg02,
                                             arg10, arg11, arg12,
                                             arg20, arg21, arg22);

            Assert.AreEqual(expected, Matrix3x3.Inverse(matrix)._matrix);
        }

        [Test]
        [TestCase(3f, -2f, 4f,
                  1f, 0f, 2f,
                  0f, 1f, 0f)]
        [TestCase(1f, 2f, 3f,
                  4f, 5f, 6f,
                  7f, 8f, 10f)]
        [TestCase(30f, 36f, 42f,
                  66f, 81f, 96f,
                  102f, 126f, 151f)]
        public void Inverse_WhenCalledTwice_ReturnOriginalMatrix(double arg00, double arg01, double arg02,
                                                                 double arg10, double arg11, double arg12,
                                                                 double arg20, double arg21, double arg22)
        {
            Matrix3x3 expected = new Matrix3x3(arg00, arg01, arg02, 
                                               arg10, arg11, arg12,
                                               arg20, arg21, arg22);

            Matrix3x3 matrix = new Matrix3x3(arg00, arg01, arg02,
                                             arg10, arg11, arg12,
                                             arg20, arg21, arg22);

            Assert.IsTrue(expected == Matrix3x3.Inverse(Matrix3x3.Inverse(matrix)));
        }
    }
}
