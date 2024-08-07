﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLib.Benchmarks.ExperimentalClasses._32Bit;

public class Matrix2x2
{
    public static readonly Matrix2x2 IdentityMatrix = new Matrix2x2(1f, 0f,
                                                                    0f, 1f);

    public readonly float[,] _matrix;

    public Matrix2x2()
    {
        _matrix = new float[2, 2];
    }

    public Matrix2x2(float arg00, float arg01,
                     float arg10, float arg11)
    {
        _matrix = new float[2, 2]
        {
            { arg00, arg01 },
            { arg10, arg11 }
        };
    }

    public float Det
    {
        get
        {
            return (_matrix[0, 0] * _matrix[1, 1]) - (_matrix[0, 1] * _matrix[1, 0]);
        }
    }

    public static Matrix2x2 operator *(Matrix2x2 matrixA, Matrix2x2 matrixB)
    {
        Matrix2x2 result = new Matrix2x2();

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                result._matrix[i, j] = (matrixA._matrix[i, 0] * matrixB._matrix[0, j]) +
                                       (matrixA._matrix[i, 1] * matrixB._matrix[1, j]);
            }
        }

        return result;
    }

    public static bool operator ==(Matrix2x2 matrixA, Matrix2x2 matrixB)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (!MathHelper.AreNumbersEqual(matrixA._matrix[i, j], matrixB._matrix[i, j]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(Matrix2x2 matrixA, Matrix2x2 matrixB)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (!MathHelper.AreNumbersEqual(matrixA._matrix[i, j], matrixB._matrix[i, j]))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static Matrix2x2 Transpose(Matrix2x2 matrix)
    {
        Matrix2x2 result = new Matrix2x2();

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                result._matrix[j, i] = matrix._matrix[i, j];
            }
        }

        return result;
    }

    public static Matrix2x2 Inverse(Matrix2x2 matrix)
    {
        float det = matrix.Det;

        if (det == 0.0)
        {
            throw new DivideByZeroException("det(matrix_to_inverse) cannot be equal 0");
        }

        Matrix2x2 result = new Matrix2x2();

        float a = matrix._matrix[0, 0];
        float b = matrix._matrix[0, 1];
        float c = matrix._matrix[1, 0];
        float d = matrix._matrix[1, 1];

        result._matrix[0, 0] = d / det;
        result._matrix[0, 1] = -c / det;
        result._matrix[1, 0] = -b / det;
        result._matrix[1, 1] = a / det;

        return result;
    }
}
