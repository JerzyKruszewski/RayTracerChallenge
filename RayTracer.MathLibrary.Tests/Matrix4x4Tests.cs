using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests
{
    public class Matrix4x4Tests
    {
        [Test]
        [TestCase(1f, 0f, 0f, 0f,
                  0f, 1f, 0f, 0f,
                  0f, 0f, 1f, 0f,
                  0f, 0f, 0f, 1f, 
                  1f, 0f, 0f, 0f,
                  0f, 1f, 0f, 0f,
                  0f, 0f, 1f, 0f,
                  0f, 0f, 0f, 1f)]
        public void Matrix4x4Constructor_WhenCalled_CreateMatrix(double expected00, double expected01, double expected02, double expected03,
                                                                 double expected10, double expected11, double expected12, double expected13,
                                                                 double expected20, double expected21, double expected22, double expected23,
                                                                 double expected30, double expected31, double expected32, double expected33,
                                                                 double arg00, double arg01, double arg02, double arg03,
                                                                 double arg10, double arg11, double arg12, double arg13,
                                                                 double arg20, double arg21, double arg22, double arg23,
                                                                 double arg30, double arg31, double arg32, double arg33)
        {
            double[,] expected = new double[4, 4]
            {
                { expected00, expected01, expected02, expected03 },
                { expected10, expected11, expected12, expected13 },
                { expected20, expected21, expected22, expected23 },
                { expected30, expected31, expected32, expected33 }
            };

            Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                             arg10, arg11, arg12, arg13,
                                             arg20, arg21, arg22, arg23,
                                             arg30, arg31, arg32, arg33);

            Assert.AreEqual(expected, matrix._matrix);
        }

        [Test]
        [TestCase(20f, 22f, 50f, 48f,
                  44f, 54f, 114f, 108f,
                  40f, 58f, 110f, 102f,
                  16f, 26f, 46f, 42f,
                  1f, 2f, 3f, 4f,
                  5f, 6f, 7f, 8f,
                  9f, 8f, 7f, 6f,
                  5f, 4f, 3f, 2f,
                  -2f, 1f, 2f, 3f,
                  3f, 2f, 1f, -1f,
                  4f, 3f, 6f, 5f,
                  1f, 2f, 7f, 8f)]
        public void MatrixMultiplication_WhenCalledWith2Matrixes_PerformMatrixMultipliaction(double expected00, double expected01, double expected02, double expected03,
                                                                                             double expected10, double expected11, double expected12, double expected13,
                                                                                             double expected20, double expected21, double expected22, double expected23,
                                                                                             double expected30, double expected31, double expected32, double expected33,
                                                                                             double argA00, double argA01, double argA02, double argA03,
                                                                                             double argA10, double argA11, double argA12, double argA13,
                                                                                             double argA20, double argA21, double argA22, double argA23,
                                                                                             double argA30, double argA31, double argA32, double argA33,
                                                                                             double argB00, double argB01, double argB02, double argB03,
                                                                                             double argB10, double argB11, double argB12, double argB13,
                                                                                             double argB20, double argB21, double argB22, double argB23,
                                                                                             double argB30, double argB31, double argB32, double argB33)
        {
            double[,] expected = new double[4, 4]
            {
                { expected00, expected01, expected02, expected03 },
                { expected10, expected11, expected12, expected13 },
                { expected20, expected21, expected22, expected23 },
                { expected30, expected31, expected32, expected33 }
            };
            
            Matrix4x4 matrixA = new Matrix4x4(argA00, argA01, argA02, argA03,
                                              argA10, argA11, argA12, argA13,
                                              argA20, argA21, argA22, argA23,
                                              argA30, argA31, argA32, argA33);

            Matrix4x4 matrixB = new Matrix4x4(argB00, argB01, argB02, argB03,
                                              argB10, argB11, argB12, argB13,
                                              argB20, argB21, argB22, argB23,
                                              argB30, argB31, argB32, argB33);

            Assert.AreEqual(expected, (matrixA * matrixB)._matrix);
        }

        [Test]
        [TestCase(18f, 24f, 33f, 1f,
                  1f, 2f, 3f, 4f,
                  2f, 4f, 4f, 2f,
                  8f, 6f, 4f, 1f,
                  0f, 0f, 0f, 1f,
                  1f, 2f, 3f, 1f)]
        public void MatrixMultiplication_WhenCalledWithMatrixAndVector_PerformMatrixMultipliaction(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                                   double arg00, double arg01, double arg02, double arg03,
                                                                                                   double arg10, double arg11, double arg12, double arg13,
                                                                                                   double arg20, double arg21, double arg22, double arg23,
                                                                                                   double arg30, double arg31, double arg32, double arg33,
                                                                                                   double argX, double argY, double argZ, double argW)
        {
            Vector3 expected = new Vector3(expectedX, expectedY, expectedZ, expectedW);

            Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                             arg10, arg11, arg12, arg13,
                                             arg20, arg21, arg22, arg23,
                                             arg30, arg31, arg32, arg33);

            Vector3 vector = new Vector3(argX, argY, argZ, argW);

            Assert.IsTrue(Utilities.AreObjectEquals(expected, (matrix * vector)));
        }

        [Test]
        [TestCase(1f, 2f, 3f, 4f,
                  5f, 6f, 7f, 8f,
                  9f, 8f, 7f, 6f,
                  5f, 4f, 3f, 2f,
                  1f, 2f, 3f, 4f,
                  5f, 6f, 7f, 8f,
                  9f, 8f, 7f, 6f,
                  5f, 4f, 3f, 2f)]
        public void MatrixCompare_WhenCalledWith2SameMatrixes_ReturnIfMatrixesAreSame(double argA00, double argA01, double argA02, double argA03,
                                                                                      double argA10, double argA11, double argA12, double argA13,
                                                                                      double argA20, double argA21, double argA22, double argA23,
                                                                                      double argA30, double argA31, double argA32, double argA33, 
                                                                                      double argB00, double argB01, double argB02, double argB03,
                                                                                      double argB10, double argB11, double argB12, double argB13,
                                                                                      double argB20, double argB21, double argB22, double argB23,
                                                                                      double argB30, double argB31, double argB32, double argB33)
        {
            Matrix4x4 matrixA = new Matrix4x4(argA00, argA01, argA02, argA03,
                                              argA10, argA11, argA12, argA13,
                                              argA20, argA21, argA22, argA23,
                                              argA30, argA31, argA32, argA33);

            Matrix4x4 matrixB = new Matrix4x4(argB00, argB01, argB02, argB03,
                                              argB10, argB11, argB12, argB13,
                                              argB20, argB21, argB22, argB23,
                                              argB30, argB31, argB32, argB33);

            Assert.IsTrue(matrixA == matrixB);
        }

        [Test]
        [TestCase(1f, 2f, 3f, 4f,
                  5f, 6f, 7f, 8f,
                  9f, 8f, 7f, 6f,
                  5f, 4f, 3f, 2f,
                  1f, 2f, 3f, 4f,
                  5f, 6f, 7f, 8f,
                  8f, 7f, 6f, 5f,
                  4f, 3f, 2f, 1f)]
        public void MatrixCompare_WhenCalledWith2DifferentMatrixes_ReturnIfMatrixesAreDifferent(double argA00, double argA01, double argA02, double argA03,
                                                                                                double argA10, double argA11, double argA12, double argA13,
                                                                                                double argA20, double argA21, double argA22, double argA23,
                                                                                                double argA30, double argA31, double argA32, double argA33,
                                                                                                double argB00, double argB01, double argB02, double argB03,
                                                                                                double argB10, double argB11, double argB12, double argB13,
                                                                                                double argB20, double argB21, double argB22, double argB23,
                                                                                                double argB30, double argB31, double argB32, double argB33)
        {
            Matrix4x4 matrixA = new Matrix4x4(argA00, argA01, argA02, argA03,
                                              argA10, argA11, argA12, argA13,
                                              argA20, argA21, argA22, argA23,
                                              argA30, argA31, argA32, argA33);

            Matrix4x4 matrixB = new Matrix4x4(argB00, argB01, argB02, argB03,
                                              argB10, argB11, argB12, argB13,
                                              argB20, argB21, argB22, argB23,
                                              argB30, argB31, argB32, argB33);

            Assert.IsTrue(matrixA != matrixB);
        }

        [Test]
        [TestCase(0f, 9f, 3f, 0f,
                  9f, 8f, 0f, 8f,
                  1f, 8f, 5f, 3f,
                  0f, 0f, 5f, 8f,
                  0f, 9f, 1f, 0f,
                  9f, 8f, 8f, 0f,
                  3f, 0f, 5f, 5f,
                  0f, 8f, 3f, 8f)]
        public void Transpose_WhenCalled_TransposeMatrix(double expected00, double expected01, double expected02, double expected03,
                                                         double expected10, double expected11, double expected12, double expected13,
                                                         double expected20, double expected21, double expected22, double expected23,
                                                         double expected30, double expected31, double expected32, double expected33,
                                                         double arg00, double arg01, double arg02, double arg03,
                                                         double arg10, double arg11, double arg12, double arg13,
                                                         double arg20, double arg21, double arg22, double arg23,
                                                         double arg30, double arg31, double arg32, double arg33)
        {
            double[,] expected = new double[4, 4]
            {
                { expected00, expected01, expected02, expected03 },
                { expected10, expected11, expected12, expected13 },
                { expected20, expected21, expected22, expected23 },
                { expected30, expected31, expected32, expected33 }
            };

            Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                             arg10, arg11, arg12, arg13,
                                             arg20, arg21, arg22, arg23,
                                             arg30, arg31, arg32, arg33);

            Assert.AreEqual(expected, Matrix4x4.Transpose(matrix)._matrix);
        }

        [Test]
        [TestCase(-4071, -2, -8, 3, 5,
                         -3, 1, 7, 3,
                         1, 2, -9, 6,
                         -6, 7, 7, -9)]
        public void Det_WhenCalled_CalculateDet(double expected, double arg00, double arg01, double arg02, double arg03,
                                                                 double arg10, double arg11, double arg12, double arg13,
                                                                 double arg20, double arg21, double arg22, double arg23,
                                                                 double arg30, double arg31, double arg32, double arg33)
        {
            Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                             arg10, arg11, arg12, arg13,
                                             arg20, arg21, arg22, arg23,
                                             arg30, arg31, arg32, arg33);

            Assert.AreEqual(expected, matrix.Det);
        }

        [Test]
        [TestCase(1f, 0f, 0f, 0f,
                  0f, 1f, 0f, 0f,
                  0f, 0f, 1f, 0f,
                  0f, 0f, 0f, 1f,
                  1f, 0f, 0f, 0f,
                  0f, 1f, 0f, 0f,
                  0f, 0f, 1f, 0f,
                  0f, 0f, 0f, 1f)]
        [TestCase(0.21805, 0.45113, 0.2406, -0.04511,
                  -0.80827, -1.45677, -0.44361, 0.52068,
                  -0.07895, -0.22368, -0.05263, 0.19737,
                  -0.52256, -0.81391, -0.30075, 0.30639,
                  -5f, 2f, 6f, -8f,
                  1f, -5f, 1f, 8f,
                  7f, 7f, -6f, -7f,
                  1f, -3f, 7f, 4f)]
        [TestCase(-0.15385, -0.15385, -0.28205, -0.53846,
                  -0.07692, 0.12308, 0.02564, 0.03077,
                  0.35897, 0.35897, 0.4359, 0.92308,
                  -0.69231, -0.69231, -0.76923, -1.92308,
                  8f, -5f, 9f, 2f,
                  7f, 5f, 6f, 1f,
                  -6f, 0f, 9f, 6f,
                  -3f, 0f, -9f, -4f)]
        [TestCase(-0.04074, -0.07778, 0.14444, -0.22222,
                  -0.07778, 0.03333, 0.36667, -0.33333,
                  -0.02901, -0.14630, -0.10926, 0.12963,
                  0.17778, 0.06667, -0.26667, 0.33333,
                  9f, 3f, 0f, 9f,
                  -5f, -2f, -6f, -3f,
                  -4f, 9f, 6f, 4f,
                  -7f, 6f, 6f, 2f)]
        public void Inverse_WhenCalled_InverseMatrix(double expected00, double expected01, double expected02, double expected03,
                                                     double expected10, double expected11, double expected12, double expected13,
                                                     double expected20, double expected21, double expected22, double expected23,
                                                     double expected30, double expected31, double expected32, double expected33,
                                                     double arg00, double arg01, double arg02, double arg03,
                                                     double arg10, double arg11, double arg12, double arg13,
                                                     double arg20, double arg21, double arg22, double arg23,
                                                     double arg30, double arg31, double arg32, double arg33)
        {
            Matrix4x4 expected = new Matrix4x4(expected00, expected01, expected02, expected03,
                                               expected10, expected11, expected12, expected13,
                                               expected20, expected21, expected22, expected23,
                                               expected30, expected31, expected32, expected33);

            Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                             arg10, arg11, arg12, arg13,
                                             arg20, arg21, arg22, arg23,
                                             arg30, arg31, arg32, arg33);

            Assert.IsTrue(expected == Matrix4x4.Inverse(matrix));
        }

        [Test]
        [TestCase(0f, 9f, 3f, 0f,
                  9f, 8f, 0f, 8f,
                  1f, 8f, 5f, 3f,
                  0f, 0f, 5f, 8f)]
        public void Inverse_WhenCalledTwice_ReturnOriginalMatrix(double arg00, double arg01, double arg02, double arg03,
                                                                 double arg10, double arg11, double arg12, double arg13,
                                                                 double arg20, double arg21, double arg22, double arg23,
                                                                 double arg30, double arg31, double arg32, double arg33)
        {
            Matrix4x4 expected = new Matrix4x4(arg00, arg01, arg02, arg03,
                                               arg10, arg11, arg12, arg13,
                                               arg20, arg21, arg22, arg23,
                                               arg30, arg31, arg32, arg33);

            Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                             arg10, arg11, arg12, arg13,
                                             arg20, arg21, arg22, arg23,
                                             arg30, arg31, arg32, arg33);

            Assert.IsTrue(expected == Matrix4x4.Inverse(Matrix4x4.Inverse(matrix)));
        }

        [Test]
        [TestCase(-6f, 1f, 6f,
                  -8f, 8f, 6f,
                  -7f, -1f, 1f,
                  -6f, 1f, 1f, 6f,
                  -8f, 5f, 8f, 6f,
                  -1f, 0f, 8f, 2f,
                  -7f, 1f, -1f, 1f,
                  2, 1)]
        public void GetSubmatrix_WhenCalled_RemoveRowAndColumn(double expected00, double expected01, double expected02,
                                                               double expected10, double expected11, double expected12,
                                                               double expected20, double expected21, double expected22,
                                                               double arg00, double arg01, double arg02, double arg03,
                                                               double arg10, double arg11, double arg12, double arg13,
                                                               double arg20, double arg21, double arg22, double arg23,
                                                               double arg30, double arg31, double arg32, double arg33,
                                                               int row, int column)
        {
            double[,] expected = new double[3, 3]
            {
                { expected00, expected01, expected02 },
                { expected10, expected11, expected12 },
                { expected20, expected21, expected22 }
            };

            Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                             arg10, arg11, arg12, arg13,
                                             arg20, arg21, arg22, arg23,
                                             arg30, arg31, arg32, arg33);

            Assert.AreEqual(expected, Matrix4x4.GetSubmatrix(matrix, row, column)._matrix);
        }

        [Test]
        [TestCase(32,
                  -6f, 1f, 0f, 0f,
                  -8f, 5f, 8f, 6f,
                  -1f, 0f, 8f, 0f,
                  -7f, 0f, 0f, 4f,
                  1, 0)]
        public void GetMinor_WhenCalled_ReturnMinor(double expected,
                                                    double arg00, double arg01, double arg02, double arg03,
                                                    double arg10, double arg11, double arg12, double arg13,
                                                    double arg20, double arg21, double arg22, double arg23,
                                                    double arg30, double arg31, double arg32, double arg33,
                                                    int row, int column)
        {
            Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                             arg10, arg11, arg12, arg13,
                                             arg20, arg21, arg22, arg23,
                                             arg30, arg31, arg32, arg33);

            Assert.AreEqual(expected, Matrix4x4.GetMinor(matrix, row, column));
        }

        [Test]
        [TestCase(-32,
                  -6f, 1f, 0f, 0f,
                  -8f, 5f, 8f, 6f,
                  -1f, 0f, 8f, 0f,
                  -7f, 0f, 0f, 4f,
                  1, 0)]
        public void GetCofactor_WhenCalled_ReturnCofactor(double expected,
                                                          double arg00, double arg01, double arg02, double arg03,
                                                          double arg10, double arg11, double arg12, double arg13,
                                                          double arg20, double arg21, double arg22, double arg23,
                                                          double arg30, double arg31, double arg32, double arg33,
                                                          int row, int column)
        {
            Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                             arg10, arg11, arg12, arg13,
                                             arg20, arg21, arg22, arg23,
                                             arg30, arg31, arg32, arg33);

            Assert.AreEqual(expected, Matrix4x4.GetCofactor(matrix, row, column));
        }

        [Test]
        [TestCase(2f, 1f, 7f, 1f,
                  5f, -3f, 2f,
                  -3f, 4f, 5f, 1f)]
        public void TranslationMatrix_WhenMultipliedWithPoint_ReturnTranslatedPoint(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                    double x, double y, double z,
                                                                                    double argX, double argY, double argZ, double argW)
        {
            Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

            Matrix4x4 matrix = Matrix4x4.TranslationMatrix(x, y, z);

            Point3D point = new Point3D(argX, argY, argZ, argW);

            Assert.IsTrue(Utilities.AreObjectEquals(expected, (matrix * point)));
        }

        [Test]
        [TestCase(-8f, 7f, 3f, 1f,
                  5f, -3f, 2f,
                  -3f, 4f, 5f, 1f)]
        public void TranslationMatrix_WhenMultipliedInverseWithPoint_ReturnTranslatedPoint(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                           double x, double y, double z,
                                                                                           double argX, double argY, double argZ, double argW)
        {
            Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

            Matrix4x4 matrix = Matrix4x4.Inverse(Matrix4x4.TranslationMatrix(x, y, z));

            Point3D point = new Point3D(argX, argY, argZ, argW);

            Assert.IsTrue(Utilities.AreObjectEquals(expected, (matrix * point)));
        }

        [Test]
        [TestCase(5f, -3f, 2f,
                  -3f, 4f, 5f, 0f)]
        [TestCase(-5f, -3f, 2.5f,
                  -3f, 4f, 5f, 0f)]
        [TestCase(5f, -3f, 2f,
                  -3.734f, 4f, -5f, 0f)]
        [TestCase(0f, -3f, 2f,
                  -3f, 1231f, 5f, 0f)]
        public void TranslationMatrix_WhenMultipliedWithVector_ReturnUnchangedVector(double x, double y, double z,
                                                                                     double argX, double argY, double argZ, double argW)
        {
            Matrix4x4 matrix = Matrix4x4.TranslationMatrix(x, y, z);

            Vector3 vector = new Vector3(argX, argY, argZ, argW);

            Assert.IsTrue(Utilities.AreObjectEquals(vector, (matrix * vector)));
        }

        [Test]
        [TestCase(-8f, 18f, 32f, 1f,
                  2f, 3f, 4f,
                  -4f, 6f, 8f, 1f)]
        [TestCase(-2f, 3f, 4f, 1f,
                  -1f, 1f, 1f,
                  2f, 3f, 4f, 1f)]
        public void ScalingMatrix_WhenMultipliedWithPoint_ReturnPointWithScaledCordinates(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                          double x, double y, double z,
                                                                                          double argX, double argY, double argZ, double argW)
        {
            Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

            Matrix4x4 matrix = Matrix4x4.ScalingMatrix(x, y, z);

            Point3D point = new Point3D(argX, argY, argZ, argW);

            Assert.IsTrue(Utilities.AreObjectEquals(expected, (matrix * point)));
        }

        [Test]
        [TestCase(-8f, 18f, 32f, 0f,
                  2f, 3f, 4f,
                  -4f, 6f, 8f, 0f)]
        public void ScalingMatrix_WhenMultipliedWithVector_ReturnVectorWithScaledCordinates(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                            double x, double y, double z,
                                                                                            double argX, double argY, double argZ, double argW)
        {
            Vector3 expected = new Vector3(expectedX, expectedY, expectedZ, expectedW);

            Matrix4x4 matrix = Matrix4x4.ScalingMatrix(x, y, z);

            Vector3 vector = new Vector3(argX, argY, argZ, argW);

            Assert.IsTrue(Utilities.AreObjectEquals(expected, (matrix * vector)));
        }

        [Test]
        [TestCase(-2f, 2f, 2f, 0f,
                  2f, 3f, 4f,
                  -4f, 6f, 8f, 0f)]
        public void ScalingMatrix_WhenMultipliedInverseWithVector_ReturnVectorWithScaledCordinates(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                                   double x, double y, double z,
                                                                                                   double argX, double argY, double argZ, double argW)
        {
            Vector3 expected = new Vector3(expectedX, expectedY, expectedZ, expectedW);

            Matrix4x4 matrix = Matrix4x4.Inverse(Matrix4x4.ScalingMatrix(x, y, z));

            Vector3 vector = new Vector3(argX, argY, argZ, argW);

            Assert.IsTrue(Utilities.AreObjectEquals(expected, (matrix * vector)));
        }
    }
}
