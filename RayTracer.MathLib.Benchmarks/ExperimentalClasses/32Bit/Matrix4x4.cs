using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RayTracer.MathLib.Benchmarks.ExperimentalClasses._32Bit;

public class Matrix4x4
{
    public static readonly Matrix4x4 IdentityMatrix = new Matrix4x4(1f, 0f, 0f, 0f, 
                                                                    0f, 1f, 0f, 0f,
                                                                    0f, 0f, 1f, 0f,
                                                                    0f, 0f, 0f, 1f);

    public readonly float[,] _matrix;

    public Matrix4x4()
    {
        _matrix = new float[4, 4];
    }

    public Matrix4x4(float arg00, float arg01, float arg02, float arg03,
                     float arg10, float arg11, float arg12, float arg13,
                     float arg20, float arg21, float arg22, float arg23,
                     float arg30, float arg31, float arg32, float arg33)
    {
        _matrix = new float[4, 4]
        {
            { arg00, arg01, arg02, arg03 },
            { arg10, arg11, arg12, arg13 },
            { arg20, arg21, arg22, arg23 },
            { arg30, arg31, arg32, arg33 }
        };
    }

    public float Det
    {
        get
        {
            /*
            return _matrix[0, 0] * GetCofactor(this, 0, 0) +
                   _matrix[0, 1] * GetCofactor(this, 0, 1) +
                   _matrix[0, 2] * GetCofactor(this, 0, 2) +
                   _matrix[0, 3] * GetCofactor(this, 0, 3);
            */

            //Following code is 5 times faster
            return (_matrix[0, 0] * _matrix[1, 1] * _matrix[2, 2] * _matrix[3, 3]) +
                   (_matrix[0, 0] * _matrix[1, 2] * _matrix[2, 3] * _matrix[3, 1]) +
                   (_matrix[0, 0] * _matrix[1, 3] * _matrix[2, 1] * _matrix[3, 2]) +
                   (_matrix[0, 1] * _matrix[1, 0] * _matrix[2, 3] * _matrix[3, 2]) +
                   (_matrix[0, 1] * _matrix[1, 2] * _matrix[2, 0] * _matrix[3, 3]) +
                   (_matrix[0, 1] * _matrix[1, 3] * _matrix[2, 2] * _matrix[3, 0]) +
                   (_matrix[0, 2] * _matrix[1, 0] * _matrix[2, 1] * _matrix[3, 3]) +
                   (_matrix[0, 2] * _matrix[1, 1] * _matrix[2, 3] * _matrix[3, 0]) +
                   (_matrix[0, 2] * _matrix[1, 3] * _matrix[2, 0] * _matrix[3, 1]) +
                   (_matrix[0, 3] * _matrix[1, 0] * _matrix[2, 2] * _matrix[3, 1]) +
                   (_matrix[0, 3] * _matrix[1, 1] * _matrix[2, 0] * _matrix[3, 2]) +
                   (_matrix[0, 3] * _matrix[1, 2] * _matrix[2, 1] * _matrix[3, 0]) -
                   (_matrix[0, 0] * _matrix[1, 1] * _matrix[2, 3] * _matrix[3, 2]) -
                   (_matrix[0, 0] * _matrix[1, 2] * _matrix[2, 1] * _matrix[3, 3]) -
                   (_matrix[0, 0] * _matrix[1, 3] * _matrix[2, 2] * _matrix[3, 1]) -
                   (_matrix[0, 1] * _matrix[1, 0] * _matrix[2, 2] * _matrix[3, 3]) -
                   (_matrix[0, 1] * _matrix[1, 2] * _matrix[2, 3] * _matrix[3, 0]) -
                   (_matrix[0, 1] * _matrix[1, 3] * _matrix[2, 0] * _matrix[3, 2]) -
                   (_matrix[0, 2] * _matrix[1, 0] * _matrix[2, 3] * _matrix[3, 1]) -
                   (_matrix[0, 2] * _matrix[1, 1] * _matrix[2, 0] * _matrix[3, 3]) -
                   (_matrix[0, 2] * _matrix[1, 3] * _matrix[2, 1] * _matrix[3, 0]) -
                   (_matrix[0, 3] * _matrix[1, 0] * _matrix[2, 1] * _matrix[3, 2]) -
                   (_matrix[0, 3] * _matrix[1, 1] * _matrix[2, 2] * _matrix[3, 0]) -
                   (_matrix[0, 3] * _matrix[1, 2] * _matrix[2, 0] * _matrix[3, 1]);
        }
    }

    public static Matrix4x4 operator *(Matrix4x4 matrixA, Matrix4x4 matrixB)
    {
        Matrix4x4 result = new Matrix4x4();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                result._matrix[i, j] = (matrixA._matrix[i, 0] * matrixB._matrix[0, j]) +
                                       (matrixA._matrix[i, 1] * matrixB._matrix[1, j]) +
                                       (matrixA._matrix[i, 2] * matrixB._matrix[2, j]) +
                                       (matrixA._matrix[i, 3] * matrixB._matrix[3, j]);
            }
        }

        return result;
    }

    public static Vector3 operator *(Matrix4x4 matrixA, Vector3 vector)
    {
        Vector3 result = new Vector3
        {
            X = (matrixA._matrix[0, 0] * vector.X) +
                (matrixA._matrix[0, 1] * vector.Y) +
                (matrixA._matrix[0, 2] * vector.Z) +
                (matrixA._matrix[0, 3] * vector.W),
            Y = (matrixA._matrix[1, 0] * vector.X) +
                (matrixA._matrix[1, 1] * vector.Y) +
                (matrixA._matrix[1, 2] * vector.Z) +
                (matrixA._matrix[1, 3] * vector.W),
            Z = (matrixA._matrix[2, 0] * vector.X) +
                (matrixA._matrix[2, 1] * vector.Y) +
                (matrixA._matrix[2, 2] * vector.Z) +
                (matrixA._matrix[2, 3] * vector.W),
            W = (matrixA._matrix[3, 0] * vector.X) +
                (matrixA._matrix[3, 1] * vector.Y) +
                (matrixA._matrix[3, 2] * vector.Z) +
                (matrixA._matrix[3, 3] * vector.W)
        };

        return result;
    }

    public static Point3D operator *(Matrix4x4 matrixA, Point3D point)
    {
        Point3D result = new Point3D
        {
            X = (matrixA._matrix[0, 0] * point.X) +
                (matrixA._matrix[0, 1] * point.Y) +
                (matrixA._matrix[0, 2] * point.Z) +
                (matrixA._matrix[0, 3] * point.W),
            Y = (matrixA._matrix[1, 0] * point.X) +
                (matrixA._matrix[1, 1] * point.Y) +
                (matrixA._matrix[1, 2] * point.Z) +
                (matrixA._matrix[1, 3] * point.W),
            Z = (matrixA._matrix[2, 0] * point.X) +
                (matrixA._matrix[2, 1] * point.Y) +
                (matrixA._matrix[2, 2] * point.Z) +
                (matrixA._matrix[2, 3] * point.W),
            W = (matrixA._matrix[3, 0] * point.X) +
                (matrixA._matrix[3, 1] * point.Y) +
                (matrixA._matrix[3, 2] * point.Z) +
                (matrixA._matrix[3, 3] * point.W)
        };

        return result;
    }

    public static bool operator ==(Matrix4x4 matrixA, Matrix4x4 matrixB)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (!MathHelper.AreNumbersEqual(matrixA._matrix[i, j], matrixB._matrix[i, j]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(Matrix4x4 matrixA, Matrix4x4 matrixB)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (!MathHelper.AreNumbersEqual(matrixA._matrix[i, j], matrixB._matrix[i, j]))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static Matrix4x4 Transpose(Matrix4x4 matrix)
    {
        Matrix4x4 result = new Matrix4x4();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                result._matrix[j, i] = matrix._matrix[i, j];
            }
        }

        return result;
    }

    public static Matrix4x4 Inverse(Matrix4x4 matrix)
    {
        /*
        float det = matrix.Det;

        if (det == 0.0)
        {
            throw new DivideByZeroException("det(matrix_to_inverse) cannot be equal 0");
        }

        Matrix4x4 result = new Matrix4x4();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                result._matrix[j, i] = GetCofactor(matrix, i, j) / det;
            }
        }

        return result;
        */

        //this code is 5 times faster
        Matrix4x4 inv = new Matrix4x4();

        inv._matrix[0, 0] = (matrix._matrix[1, 1] * matrix._matrix[2, 2] * matrix._matrix[3, 3]) -
                            (matrix._matrix[1, 1] * matrix._matrix[2, 3] * matrix._matrix[3, 2]) -
                            (matrix._matrix[2, 1] * matrix._matrix[1, 2] * matrix._matrix[3, 3]) +
                            (matrix._matrix[2, 1] * matrix._matrix[1, 3] * matrix._matrix[3, 2]) +
                            (matrix._matrix[3, 1] * matrix._matrix[1, 2] * matrix._matrix[2, 3]) -
                            (matrix._matrix[3, 1] * matrix._matrix[1, 3] * matrix._matrix[2, 2]);

        inv._matrix[1, 0] = (-matrix._matrix[1, 0] * matrix._matrix[2, 2] * matrix._matrix[3, 3]) +
                            (matrix._matrix[1, 0] * matrix._matrix[2, 3] * matrix._matrix[3, 2]) +
                            (matrix._matrix[2, 0] * matrix._matrix[1, 2] * matrix._matrix[3, 3]) -
                            (matrix._matrix[2, 0] * matrix._matrix[1, 3] * matrix._matrix[3, 2]) -
                            (matrix._matrix[3, 0] * matrix._matrix[1, 2] * matrix._matrix[2, 3]) +
                            (matrix._matrix[3, 0] * matrix._matrix[1, 3] * matrix._matrix[2, 2]);

        inv._matrix[2, 0] = (matrix._matrix[1, 0] * matrix._matrix[2, 1] * matrix._matrix[3, 3]) -
                            (matrix._matrix[1, 0] * matrix._matrix[2, 3] * matrix._matrix[3, 1]) -
                            (matrix._matrix[2, 0] * matrix._matrix[1, 1] * matrix._matrix[3, 3]) +
                            (matrix._matrix[2, 0] * matrix._matrix[1, 3] * matrix._matrix[3, 1]) +
                            (matrix._matrix[3, 0] * matrix._matrix[1, 1] * matrix._matrix[2, 3]) -
                            (matrix._matrix[3, 0] * matrix._matrix[1, 3] * matrix._matrix[2, 1]);

        inv._matrix[3, 0] = (-matrix._matrix[1, 0] * matrix._matrix[2, 1] * matrix._matrix[3, 2]) +
                            (matrix._matrix[1, 0] * matrix._matrix[2, 2] * matrix._matrix[3, 1]) +
                            (matrix._matrix[2, 0] * matrix._matrix[1, 1] * matrix._matrix[3, 2]) -
                            (matrix._matrix[2, 0] * matrix._matrix[1, 2] * matrix._matrix[3, 1]) -
                            (matrix._matrix[3, 0] * matrix._matrix[1, 1] * matrix._matrix[2, 2]) +
                            (matrix._matrix[3, 0] * matrix._matrix[1, 2] * matrix._matrix[2, 1]);

        inv._matrix[0, 1] = (-matrix._matrix[0, 1] * matrix._matrix[2, 2] * matrix._matrix[3, 3]) +
                            (matrix._matrix[0, 1] * matrix._matrix[2, 3] * matrix._matrix[3, 2]) +
                            (matrix._matrix[2, 1] * matrix._matrix[0, 2] * matrix._matrix[3, 3]) -
                            (matrix._matrix[2, 1] * matrix._matrix[0, 3] * matrix._matrix[3, 2]) -
                            (matrix._matrix[3, 1] * matrix._matrix[0, 2] * matrix._matrix[2, 3]) +
                            (matrix._matrix[3, 1] * matrix._matrix[0, 3] * matrix._matrix[2, 2]);

        inv._matrix[1, 1] = (matrix._matrix[0, 0] * matrix._matrix[2, 2] * matrix._matrix[3, 3]) -
                            (matrix._matrix[0, 0] * matrix._matrix[2, 3] * matrix._matrix[3, 2]) -
                            (matrix._matrix[2, 0] * matrix._matrix[0, 2] * matrix._matrix[3, 3]) +
                            (matrix._matrix[2, 0] * matrix._matrix[0, 3] * matrix._matrix[3, 2]) +
                            (matrix._matrix[3, 0] * matrix._matrix[0, 2] * matrix._matrix[2, 3]) -
                            (matrix._matrix[3, 0] * matrix._matrix[0, 3] * matrix._matrix[2, 2]);

        inv._matrix[2, 1] = (-matrix._matrix[0, 0] * matrix._matrix[2, 1] * matrix._matrix[3, 3]) +
                            (matrix._matrix[0, 0] * matrix._matrix[2, 3] * matrix._matrix[3, 1]) +
                            (matrix._matrix[2, 0] * matrix._matrix[0, 1] * matrix._matrix[3, 3]) -
                            (matrix._matrix[2, 0] * matrix._matrix[0, 3] * matrix._matrix[3, 1]) -
                            (matrix._matrix[3, 0] * matrix._matrix[0, 1] * matrix._matrix[2, 3]) +
                            (matrix._matrix[3, 0] * matrix._matrix[0, 3] * matrix._matrix[2, 1]);

        inv._matrix[3, 1] = (matrix._matrix[0, 0] * matrix._matrix[2, 1] * matrix._matrix[3, 2]) -
                            (matrix._matrix[0, 0] * matrix._matrix[2, 2] * matrix._matrix[3, 1]) -
                            (matrix._matrix[2, 0] * matrix._matrix[0, 1] * matrix._matrix[3, 2]) +
                            (matrix._matrix[2, 0] * matrix._matrix[0, 2] * matrix._matrix[3, 1]) +
                            (matrix._matrix[3, 0] * matrix._matrix[0, 1] * matrix._matrix[2, 2]) -
                            (matrix._matrix[3, 0] * matrix._matrix[0, 2] * matrix._matrix[2, 1]);

        inv._matrix[0, 2] = (matrix._matrix[0, 1] * matrix._matrix[1, 2] * matrix._matrix[3, 3]) -
                            (matrix._matrix[0, 1] * matrix._matrix[1, 3] * matrix._matrix[3, 2]) -
                            (matrix._matrix[1, 1] * matrix._matrix[0, 2] * matrix._matrix[3, 3]) +
                            (matrix._matrix[1, 1] * matrix._matrix[0, 3] * matrix._matrix[3, 2]) +
                            (matrix._matrix[3, 1] * matrix._matrix[0, 2] * matrix._matrix[1, 3]) -
                            (matrix._matrix[3, 1] * matrix._matrix[0, 3] * matrix._matrix[1, 2]);

        inv._matrix[1, 2] = (-matrix._matrix[0, 0] * matrix._matrix[1, 2] * matrix._matrix[3, 3]) +
                            (matrix._matrix[0, 0] * matrix._matrix[1, 3] * matrix._matrix[3, 2]) +
                            (matrix._matrix[1, 0] * matrix._matrix[0, 2] * matrix._matrix[3, 3]) -
                            (matrix._matrix[1, 0] * matrix._matrix[0, 3] * matrix._matrix[3, 2]) -
                            (matrix._matrix[3, 0] * matrix._matrix[0, 2] * matrix._matrix[1, 3]) +
                            (matrix._matrix[3, 0] * matrix._matrix[0, 3] * matrix._matrix[1, 2]);

        inv._matrix[2, 2] = (matrix._matrix[0, 0] * matrix._matrix[1, 1] * matrix._matrix[3, 3]) -
                            (matrix._matrix[0, 0] * matrix._matrix[1, 3] * matrix._matrix[3, 1]) -
                            (matrix._matrix[1, 0] * matrix._matrix[0, 1] * matrix._matrix[3, 3]) +
                            (matrix._matrix[1, 0] * matrix._matrix[0, 3] * matrix._matrix[3, 1]) +
                            (matrix._matrix[3, 0] * matrix._matrix[0, 1] * matrix._matrix[1, 3]) -
                            (matrix._matrix[3, 0] * matrix._matrix[0, 3] * matrix._matrix[1, 1]);

        inv._matrix[3, 2] = (-matrix._matrix[0, 0] * matrix._matrix[1, 1] * matrix._matrix[3, 2]) +
                            (matrix._matrix[0, 0] * matrix._matrix[1, 2] * matrix._matrix[3, 1]) +
                            (matrix._matrix[1, 0] * matrix._matrix[0, 1] * matrix._matrix[3, 2]) -
                            (matrix._matrix[1, 0] * matrix._matrix[0, 2] * matrix._matrix[3, 1]) -
                            (matrix._matrix[3, 0] * matrix._matrix[0, 1] * matrix._matrix[1, 2]) +
                            (matrix._matrix[3, 0] * matrix._matrix[0, 2] * matrix._matrix[1, 1]);

        inv._matrix[0, 3] = (-matrix._matrix[0, 1] * matrix._matrix[1, 2] * matrix._matrix[2, 3]) +
                            (matrix._matrix[0, 1] * matrix._matrix[1, 3] * matrix._matrix[2, 2]) +
                            (matrix._matrix[1, 1] * matrix._matrix[0, 2] * matrix._matrix[2, 3]) -
                            (matrix._matrix[1, 1] * matrix._matrix[0, 3] * matrix._matrix[2, 2]) -
                            (matrix._matrix[2, 1] * matrix._matrix[0, 2] * matrix._matrix[1, 3]) +
                            (matrix._matrix[2, 1] * matrix._matrix[0, 3] * matrix._matrix[1, 2]);

        inv._matrix[1, 3] = (matrix._matrix[0, 0] * matrix._matrix[1, 2] * matrix._matrix[2, 3]) -
                            (matrix._matrix[0, 0] * matrix._matrix[1, 3] * matrix._matrix[2, 2]) -
                            (matrix._matrix[1, 0] * matrix._matrix[0, 2] * matrix._matrix[2, 3]) +
                            (matrix._matrix[1, 0] * matrix._matrix[0, 3] * matrix._matrix[2, 2]) +
                            (matrix._matrix[2, 0] * matrix._matrix[0, 2] * matrix._matrix[1, 3]) -
                            (matrix._matrix[2, 0] * matrix._matrix[0, 3] * matrix._matrix[1, 2]);

        inv._matrix[2, 3] = (-matrix._matrix[0, 0] * matrix._matrix[1, 1] * matrix._matrix[2, 3]) +
                            (matrix._matrix[0, 0] * matrix._matrix[1, 3] * matrix._matrix[2, 1]) +
                            (matrix._matrix[1, 0] * matrix._matrix[0, 1] * matrix._matrix[2, 3]) -
                            (matrix._matrix[1, 0] * matrix._matrix[0, 3] * matrix._matrix[2, 1]) -
                            (matrix._matrix[2, 0] * matrix._matrix[0, 1] * matrix._matrix[1, 3]) +
                            (matrix._matrix[2, 0] * matrix._matrix[0, 3] * matrix._matrix[1, 1]);

        inv._matrix[3, 3] = (matrix._matrix[0, 0] * matrix._matrix[1, 1] * matrix._matrix[2, 2]) -
                            (matrix._matrix[0, 0] * matrix._matrix[1, 2] * matrix._matrix[2, 1]) -
                            (matrix._matrix[1, 0] * matrix._matrix[0, 1] * matrix._matrix[2, 2]) +
                            (matrix._matrix[1, 0] * matrix._matrix[0, 2] * matrix._matrix[2, 1]) +
                            (matrix._matrix[2, 0] * matrix._matrix[0, 1] * matrix._matrix[1, 2]) -
                            (matrix._matrix[2, 0] * matrix._matrix[0, 2] * matrix._matrix[1, 1]);

        float det = (matrix._matrix[0, 0] * inv._matrix[0, 0]) + (matrix._matrix[0, 1] * inv._matrix[1, 0]) +
                     (matrix._matrix[0, 2] * inv._matrix[2, 0]) + (matrix._matrix[0, 3] * inv._matrix[3, 0]);

        if (det == 0.0)
        {
            throw new DivideByZeroException("det(matrix_to_inverse) cannot be equal 0");
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                inv._matrix[i, j] = inv._matrix[i, j] / det;
            }
        }

        return inv;
    }

    public static Matrix3x3 GetSubmatrix(Matrix4x4 matrix, int row, int column)
    {
        bool removedRow = false;
        bool removedColumn = false;
        Matrix3x3 result = new Matrix3x3();
        int insertRow;
        int insertColumn;

        for (int i = 0; i < 4; i++)
        {
            if (i == row)
            {
                removedRow = true;
                continue;
            }

            insertRow = removedRow ? i - 1 : i;

            for (int j = 0; j < 4; j++)
            {
                if (j == column)
                {
                    removedColumn = true;
                    continue;
                }

                insertColumn = removedColumn ? j - 1 : j;

                result._matrix[insertRow, insertColumn] = matrix._matrix[i, j];
            }

            removedColumn = false;
        }

        return result;
    }

    public static float GetMinor(Matrix4x4 matrix, int row, int column)
    {
        return GetSubmatrix(matrix, row, column).Det;
    }

    public static float GetCofactor(Matrix4x4 matrix, int row, int column)
    {
        if ((row + column) % 2 == 1)
        {
            return -GetMinor(matrix, row, column);
        }

        return GetMinor(matrix, row, column);
    }

    public static Matrix4x4 TranslationMatrix(float x, float y, float z)
    {
        return new Matrix4x4(1, 0, 0, x,
                             0, 1, 0, y,
                             0, 0, 1, z,
                             0, 0, 0, 1);
    }

    public static Matrix4x4 ScalingMatrix(float x, float y, float z)
    {
        return new Matrix4x4(x, 0, 0, 0,
                             0, y, 0, 0,
                             0, 0, z, 0,
                             0, 0, 0, 1);
    }

    public static Matrix4x4 RotationXMatrix(float r)
    {
        return new Matrix4x4(1, 0, 0, 0,
                             0, MathF.Cos(r), -MathF.Sin(r), 0,
                             0, MathF.Sin(r), MathF.Cos(r), 0,
                             0, 0, 0, 1);
    }

    public static Matrix4x4 RotationYMatrix(float r)
    {
        return new Matrix4x4(MathF.Cos(r), 0, MathF.Sin(r), 0,
                             0, 1, 0, 0,
                             -MathF.Sin(r), 0, MathF.Cos(r), 0,
                             0, 0, 0, 1);
    }

    public static Matrix4x4 RotationZMatrix(float r)
    {
        return new Matrix4x4(MathF.Cos(r), -MathF.Sin(r), 0, 0,
                             MathF.Sin(r), MathF.Cos(r), 0, 0,
                             0, 0, 1, 0,
                             0, 0, 0, 1);
    }

    public static Matrix4x4 ShearingMatrix(float xy, float xz, float yx, float yz, float zx, float zy)
    {
        return new Matrix4x4(1, xy, xz, 0,
                             yx, 1, yz, 0,
                             zx, zy, 1, 0,
                             0, 0, 0, 1);
    }

    //Fluent API
    public Matrix4x4 Translate(float x, float y, float z)
    {
        return TranslationMatrix(x, y, z) * this;
    }

    public Matrix4x4 Scale(float x, float y, float z)
    {
        return ScalingMatrix(x, y, z) * this;
    }

    public Matrix4x4 RotateX(float angle) //in radians
    {
        return RotationXMatrix(angle) * this;
    }

    public Matrix4x4 RotateY(float angle) //in radians
    {
        return RotationYMatrix(angle) * this;
    }

    public Matrix4x4 RotateZ(float angle) //in radians
    {
        return RotationZMatrix(angle) * this;
    }

    public Matrix4x4 Shearing(float xy, float xz, float yx, float yz, float zx, float zy)
    {
        return ShearingMatrix(xy, xz, yx, yz, zx, zy) * this;
    }
}
