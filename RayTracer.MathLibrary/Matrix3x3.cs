using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Matrix3x3
    {
        public static readonly float[,] IdentityMatrix = new float[3, 3]
        {
            { 1f, 0f, 0f },
            { 0f, 1f, 0f },
            { 0f, 0f, 1f }
        };

        public readonly float[,] _matrix;

        public Matrix3x3()
        {
            _matrix = new float[3, 3];
        }

        public Matrix3x3(float arg00, float arg01, float arg02,
                         float arg10, float arg11, float arg12,
                         float arg20, float arg21, float arg22)
        {
            _matrix = new float[3, 3]
            {
                { arg00, arg01, arg02 },
                { arg10, arg11, arg12 },
                { arg20, arg21, arg22 }
            };
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
    }
}
