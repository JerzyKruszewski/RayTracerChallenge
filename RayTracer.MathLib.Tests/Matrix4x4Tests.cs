using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests;

public class Matrix4x4Tests
{
    [Theory]
    [InlineData(1f, 0f, 0f, 0f,
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

        matrix._matrix.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(20f, 22f, 50f, 48f,
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

        (matrixA * matrixB)._matrix.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(18f, 24f, 33f, 1f,
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

        (Utilities.AreObjectEquals(expected, (matrix * vector))).Should().BeTrue();
    }

    [Theory]
    [InlineData(1f, 2f, 3f, 4f,
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

        (matrixA == matrixB).Should().BeTrue();
    }

    [Theory]
    [InlineData(1f, 2f, 3f, 4f,
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

        (matrixA != matrixB).Should().BeTrue();
    }

    [Theory]
    [InlineData(0f, 9f, 3f, 0f,
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

        Matrix4x4.Transpose(matrix)._matrix.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(-4071, -2, -8, 3, 5,
                     -3, 1, 7, 3,
                     1, 2, -9, 6,
                     -6, 7, 7, -9)]
    [InlineData(-4, 1, 3, 1, 4,
                  3, 9, 5, 15,
                  0, 2, 1, 1,
                  0, 4, 2, 3)]
    [InlineData(9, 0, 1, 2, 0,
                 1, 0, 3, 2,
                 2, -2, -5, -1,
                 3, -1, 1, 3)]
    [InlineData(1, 1, 2, 1, 1,
                 2, 1, 3, 1,
                 1, 3, 1, 2,
                 1, 1, 2, 1)]
    public void Det_WhenCalled_CalculateDet(double expected, double arg00, double arg01, double arg02, double arg03,
                                                             double arg10, double arg11, double arg12, double arg13,
                                                             double arg20, double arg21, double arg22, double arg23,
                                                             double arg30, double arg31, double arg32, double arg33)
    {
        Matrix4x4 matrix = new Matrix4x4(arg00, arg01, arg02, arg03,
                                         arg10, arg11, arg12, arg13,
                                         arg20, arg21, arg22, arg23,
                                         arg30, arg31, arg32, arg33);

        matrix.Det.Should().Be(expected);
    }

    [Theory]
    [InlineData(1f, 0f, 0f, 0f,
              0f, 1f, 0f, 0f,
              0f, 0f, 1f, 0f,
              0f, 0f, 0f, 1f,
              1f, 0f, 0f, 0f,
              0f, 1f, 0f, 0f,
              0f, 0f, 1f, 0f,
              0f, 0f, 0f, 1f)]
    [InlineData(0.21805, 0.45113, 0.2406, -0.04511,
              -0.80827, -1.45677, -0.44361, 0.52068,
              -0.07895, -0.22368, -0.05263, 0.19737,
              -0.52256, -0.81391, -0.30075, 0.30639,
              -5f, 2f, 6f, -8f,
              1f, -5f, 1f, 8f,
              7f, 7f, -6f, -7f,
              1f, -3f, 7f, 4f)]
    [InlineData(-0.15385, -0.15385, -0.28205, -0.53846,
              -0.07692, 0.12308, 0.02564, 0.03077,
              0.35897, 0.35897, 0.4359, 0.92308,
              -0.69231, -0.69231, -0.76923, -1.92308,
              8f, -5f, 9f, 2f,
              7f, 5f, 6f, 1f,
              -6f, 0f, 9f, 6f,
              -3f, 0f, -9f, -4f)]
    [InlineData(-0.04074, -0.07778, 0.14444, -0.22222,
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

        (expected == Matrix4x4.Inverse(matrix)).Should().BeTrue();
    }

    [Theory]
    [InlineData(0f, 9f, 3f, 0f,
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

        (expected == Matrix4x4.Inverse(Matrix4x4.Inverse(matrix))).Should().BeTrue();
    }

    [Theory]
    [InlineData(-6f, 1f, 6f,
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

        Matrix4x4.GetSubmatrix(matrix, row, column)._matrix.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(32,
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

        Matrix4x4.GetMinor(matrix, row, column).Should().Be(expected);
    }

    [Theory]
    [InlineData(-32,
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

        Matrix4x4.GetCofactor(matrix, row, column).Should().Be(expected);
    }

    [Theory]
    [InlineData(2f, 1f, 7f, 1f,
              5f, -3f, 2f,
              -3f, 4f, 5f, 1f)]
    public void TranslationMatrix_WhenMultipliedWithPoint_ReturnTranslatedPoint(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                double x, double y, double z,
                                                                                double argX, double argY, double argZ, double argW)
    {
        Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

        Matrix4x4 matrix = Matrix4x4.TranslationMatrix(x, y, z);

        Point3D point = new Point3D(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(expected, (matrix * point))).Should().BeTrue();
    }

    [Theory]
    [InlineData(-8f, 7f, 3f, 1f,
              5f, -3f, 2f,
              -3f, 4f, 5f, 1f)]
    public void TranslationMatrix_WhenMultipliedInverseWithPoint_ReturnTranslatedPoint(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                       double x, double y, double z,
                                                                                       double argX, double argY, double argZ, double argW)
    {
        Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

        Matrix4x4 matrix = Matrix4x4.Inverse(Matrix4x4.TranslationMatrix(x, y, z));

        Point3D point = new Point3D(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(expected, (matrix * point))).Should().BeTrue();
    }

    [Theory]
    [InlineData(5f, -3f, 2f,
              -3f, 4f, 5f, 0f)]
    [InlineData(-5f, -3f, 2.5f,
              -3f, 4f, 5f, 0f)]
    [InlineData(5f, -3f, 2f,
              -3.734f, 4f, -5f, 0f)]
    [InlineData(0f, -3f, 2f,
              -3f, 1231f, 5f, 0f)]
    public void TranslationMatrix_WhenMultipliedWithVector_ReturnUnchangedVector(double x, double y, double z,
                                                                                 double argX, double argY, double argZ, double argW)
    {
        Matrix4x4 matrix = Matrix4x4.TranslationMatrix(x, y, z);

        Vector3 vector = new Vector3(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(vector, (matrix * vector))).Should().BeTrue();
    }

    [Theory]
    [InlineData(-8f, 18f, 32f, 1f,
              2f, 3f, 4f,
              -4f, 6f, 8f, 1f)]
    [InlineData(-2f, 3f, 4f, 1f,
              -1f, 1f, 1f,
              2f, 3f, 4f, 1f)]
    public void ScalingMatrix_WhenMultipliedWithPoint_ReturnPointWithScaledCordinates(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                      double x, double y, double z,
                                                                                      double argX, double argY, double argZ, double argW)
    {
        Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

        Matrix4x4 matrix = Matrix4x4.ScalingMatrix(x, y, z);

        Point3D point = new Point3D(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(expected, (matrix * point))).Should().BeTrue();
    }

    [Theory]
    [InlineData(-8f, 18f, 32f, 0f,
              2f, 3f, 4f,
              -4f, 6f, 8f, 0f)]
    public void ScalingMatrix_WhenMultipliedWithVector_ReturnVectorWithScaledCordinates(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                        double x, double y, double z,
                                                                                        double argX, double argY, double argZ, double argW)
    {
        Vector3 expected = new Vector3(expectedX, expectedY, expectedZ, expectedW);

        Matrix4x4 matrix = Matrix4x4.ScalingMatrix(x, y, z);

        Vector3 vector = new Vector3(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(expected, (matrix * vector))).Should().BeTrue();
    }

    [Theory]
    [InlineData(-2f, 2f, 2f, 0f,
              2f, 3f, 4f,
              -4f, 6f, 8f, 0f)]
    public void ScalingMatrix_WhenMultipliedInverseWithVector_ReturnVectorWithScaledCordinates(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                               double x, double y, double z,
                                                                                               double argX, double argY, double argZ, double argW)
    {
        Vector3 expected = new Vector3(expectedX, expectedY, expectedZ, expectedW);

        Matrix4x4 matrix = Matrix4x4.Inverse(Matrix4x4.ScalingMatrix(x, y, z));

        Vector3 vector = new Vector3(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(expected, (matrix * vector))).Should().BeTrue();
    }

    [Theory]
    [InlineData(0f, 0f, 1f, 1f,
              1.57079632679,
              0f, 1f, 0f, 1f)]
    [InlineData(0f, 0.70710678118, 0.70710678118, 1f,
              0.78539816339,
              0f, 1f, 0f, 1f)]
    public void RotationXMatrix_WhenMultipliedWithPoint_ReturnRotatedPoint(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                           double r,
                                                                           double argX, double argY, double argZ, double argW)
    {
        Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

        Matrix4x4 matrix = Matrix4x4.RotationXMatrix(r);

        Point3D point = new Point3D(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(expected, (matrix * point))).Should().BeTrue();
    }

    [Theory]
    [InlineData(1f, 0f, 0f, 1f,
              1.57079632679,
              0f, 0f, 1f, 1f)]
    [InlineData(0.70710678118, 0f, 0.70710678118, 1f,
              0.78539816339,
              0f, 0f, 1f, 1f)]
    public void RotationYMatrix_WhenMultipliedWithPoint_ReturnRotatedPoint(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                           double r,
                                                                           double argX, double argY, double argZ, double argW)
    {
        Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

        Matrix4x4 matrix = Matrix4x4.RotationYMatrix(r);

        Point3D point = new Point3D(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(expected, (matrix * point))).Should().BeTrue();
    }

    [Theory]
    [InlineData(-1f, 0f, 0f, 1f,
              1.57079632679,
              0f, 1f, 0f, 1f)]
    [InlineData(-0.70710678118, 0.70710678118, 0f, 1f,
              0.78539816339,
              0f, 1f, 0f, 1f)]
    public void RotationZMatrix_WhenMultipliedWithPoint_ReturnRotatedPoint(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                           double r,
                                                                           double argX, double argY, double argZ, double argW)
    {
        Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

        Matrix4x4 matrix = Matrix4x4.RotationZMatrix(r);

        Point3D point = new Point3D(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(expected, (matrix * point))).Should().BeTrue();
    }

    [Theory]
    [InlineData(5f, 3f, 4f, 1f,
              1f, 0f, 0f, 0f, 0f, 0f,
              2f, 3f, 4f, 1f)]
    [InlineData(6f, 3f, 4f, 1f,
              0f, 1f, 0f, 0f, 0f, 0f,
              2f, 3f, 4f, 1f)]
    [InlineData(2f, 5f, 4f, 1f,
              0f, 0f, 1f, 0f, 0f, 0f,
              2f, 3f, 4f, 1f)]
    [InlineData(2f, 7f, 4f, 1f,
              0f, 0f, 0f, 1f, 0f, 0f,
              2f, 3f, 4f, 1f)]
    [InlineData(2f, 3f, 6f, 1f,
              0f, 0f, 0f, 0f, 1f, 0f,
              2f, 3f, 4f, 1f)]
    [InlineData(2f, 3f, 7f, 1f,
              0f, 0f, 0f, 0f, 0f, 1f,
              2f, 3f, 4f, 1f)]
    public void ShearingMatrix_WhenMultipliedWithPoint_ReturnPointWithScaledCordinates(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                                      double xy, double xz, double yx, double yz, double zx, double zy,
                                                                                      double argX, double argY, double argZ, double argW)
    {
        Point3D expected = new Point3D(expectedX, expectedY, expectedZ, expectedW);

        Matrix4x4 matrix = Matrix4x4.ShearingMatrix(xy, xz, yx, yz, zx, zy);

        Point3D point = new Point3D(argX, argY, argZ, argW);

        (Utilities.AreObjectEquals(expected, (matrix * point))).Should().BeTrue();
    }

    [Fact]
    public void FluentAPITransformationChaining_WhenCalled_TransformPoint()
    {
        Point3D expected = new Point3D(15, 0, 7, 1);
        Point3D point = new Point3D(1, 0, 1, 1);

        Matrix4x4 matrix = Matrix4x4.IdentityMatrix.RotateX(Math.PI / 2).Scale(5, 5, 5).Translate(10, 5, 7);

        (Utilities.AreObjectEquals(expected, (matrix * point))).Should().BeTrue();
    }
}
