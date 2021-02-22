using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Matrix3x3
    {
        public static readonly double[,] IdentityMatrix = new double[3, 3]
        {
            { 1f, 0f, 0f },
            { 0f, 1f, 0f },
            { 0f, 0f, 1f }
        };

        public readonly double[,] _matrix;

        public Matrix3x3()
        {
            _matrix = new double[3, 3];
        }

        public Matrix3x3(double arg00, double arg01, double arg02,
                         double arg10, double arg11, double arg12,
                         double arg20, double arg21, double arg22)
        {
            _matrix = new double[3, 3]
            {
                { arg00, arg01, arg02 },
                { arg10, arg11, arg12 },
                { arg20, arg21, arg22 }
            };
        }

        public double Det
        {
            get
            {
                return _matrix[0, 0] * _matrix[1, 1] * _matrix[2, 2] +
                       _matrix[1, 0] * _matrix[2, 1] * _matrix[0, 2] +
                       _matrix[2, 0] * _matrix[0, 1] * _matrix[1, 2] -
                       _matrix[0, 2] * _matrix[1, 1] * _matrix[2, 0] -
                       _matrix[1, 2] * _matrix[2, 1] * _matrix[0, 0] -
                       _matrix[2, 2] * _matrix[0, 1] * _matrix[1, 0];
            }
        }

        //Test
        public static Matrix3x3 operator *(Matrix3x3 matrixA, Matrix3x3 matrixB)
        {
            Matrix3x3 result = new Matrix3x3();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result._matrix[i, j] = matrixA._matrix[i, 0] * matrixB._matrix[0, j] +
                                           matrixA._matrix[i, 1] * matrixB._matrix[1, j] +
                                           matrixA._matrix[i, 2] * matrixB._matrix[2, j];
                }
            }

            return result;
        }

        //Test
        public static Vector3 operator *(Matrix3x3 matrixA, Vector3 vector)
        {
            Vector3 result = new Vector3();

            result.X = matrixA._matrix[0, 0] * vector.X +
                       matrixA._matrix[0, 1] * vector.Y +
                       matrixA._matrix[0, 2] * vector.Z;

            result.Y = matrixA._matrix[1, 0] * vector.X +
                       matrixA._matrix[1, 1] * vector.Y +
                       matrixA._matrix[1, 2] * vector.Z;

            result.Z = matrixA._matrix[2, 0] * vector.X +
                       matrixA._matrix[2, 1] * vector.Y +
                       matrixA._matrix[2, 2] * vector.Z;

            return result;
        }

        public static bool operator ==(Matrix3x3 matrixA, Matrix3x3 matrixB)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!MathHelper.AreNumbersEqual(matrixA._matrix[i,j], matrixB._matrix[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix3x3 matrixA, Matrix3x3 matrixB)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (MathHelper.AreNumbersEqual(matrixA._matrix[i, j], matrixB._matrix[i, j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static Matrix3x3 Transpose(Matrix3x3 matrix)
        {
            Matrix3x3 result = new Matrix3x3();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result._matrix[j, i] = matrix._matrix[i, j];
                }
            }

            return result;
        }

        public static Matrix3x3 Inverse(Matrix3x3 matrix)
        {
            double det = matrix.Det;

            if (det == 0.0)
            {
                throw new DivideByZeroException("det(matrix_to_inverse) cannot be equal 0");
            }

            Matrix3x3 result = new Matrix3x3();

            double a = matrix._matrix[0, 0];
            double b = matrix._matrix[0, 1];
            double c = matrix._matrix[0, 2];
            double d = matrix._matrix[1, 0];
            double e = matrix._matrix[1, 1];
            double f = matrix._matrix[1, 2];
            double g = matrix._matrix[2, 0];
            double h = matrix._matrix[2, 1];
            double i = matrix._matrix[2, 2];

            result._matrix[0, 0] = (e * i - f * h) / det;
            result._matrix[0, 1] = -(b * i - c * h) / det;
            result._matrix[0, 2] = (b * f - c * e) / det;
            result._matrix[1, 0] = -(d * i - f * g) / det;
            result._matrix[1, 1] = (a * i - c * g) / det;
            result._matrix[1, 2] = -(a * f - c * d) / det;
            result._matrix[2, 0] = (d * h - e * g) / det;
            result._matrix[2, 1] = -(a * h - b * g) / det;
            result._matrix[2, 2] = (a * e - b * d) / det;

            return result;
        }
    }
}
