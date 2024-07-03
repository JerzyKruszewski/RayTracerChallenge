using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests;

public class Point3DTests
{
    [Theory]
    [InlineData(1f, -1f, 0f, 0f, 0f, 1f, 1f, -1f, -1f)]
    [InlineData(1f, 1f, 6f, 3f, -2f, 5f, -2f, 3f, 1f)]
    public void AdditionOperator_WhenCalledWithTwoPoints_ReturnPointWithCombinedCordinates(double expectedX, double expectedY, double expectedZ,
                                                                                           double arg1X, double arg1Y, double arg1Z,
                                                                                           double arg2X, double arg2Y, double arg2Z)
    {
        Point3D point1 = new Point3D()
        {
            X = arg1X,
            Y = arg1Y,
            Z = arg1Z
        };

        Point3D point2 = new Point3D()
        {
            X = arg2X,
            Y = arg2Y,
            Z = arg2Z
        };

        Point3D expected = new Point3D()
        {
            X = expectedX,
            Y = expectedY,
            Z = expectedZ,
            W = 2
        };

        (Utilities.AreObjectEquals(expected, point1 + point2)).Should().BeTrue();
    }

    [Theory]
    [InlineData(1f, -1f, 0f, 0f, 0f, 1f, 1f, -1f, -1f)]
    [InlineData(1f, 1f, 6f, 3f, -2f, 5f, -2f, 3f, 1f)]
    public void AdditionOperator_WhenCalledWithPointAndVector_ReturnPointWithCombinedCordinates(double expectedX, double expectedY, double expectedZ,
                                                                                                double arg1X, double arg1Y, double arg1Z,
                                                                                                double arg2X, double arg2Y, double arg2Z)
    {
        Point3D point = new Point3D()
        {
            X = arg1X,
            Y = arg1Y,
            Z = arg1Z
        };

        Vector3 vector = new Vector3()
        {
            X = arg2X,
            Y = arg2Y,
            Z = arg2Z
        };

        Point3D expected = new Point3D()
        {
            X = expectedX,
            Y = expectedY,
            Z = expectedZ
        };

        (Utilities.AreObjectEquals(expected, point + vector)).Should().BeTrue();
    }

    [Theory]
    [InlineData(-1f, 1f, 2f, 0f, 0f, 1f, 1f, -1f, -1f)]
    [InlineData(-2f, -4f, -6f, 3f, 2f, 1f, 5f, 6f, 7f)]
    public void SubtractionOperator_WhenCalledWithTwoPoints_ReturnPointWithSubtractedCordinates(double expectedX, double expectedY, double expectedZ,
                                                                                                double arg1X, double arg1Y, double arg1Z,
                                                                                                double arg2X, double arg2Y, double arg2Z)
    {
        Point3D point1 = new Point3D()
        {
            X = arg1X,
            Y = arg1Y,
            Z = arg1Z
        };

        Point3D point2 = new Point3D()
        {
            X = arg2X,
            Y = arg2Y,
            Z = arg2Z
        };

        Vector3 expected = new Vector3()
        {
            X = expectedX,
            Y = expectedY,
            Z = expectedZ
        };

        (Utilities.AreObjectEquals(expected, point1 - point2)).Should().BeTrue();
    }

    [Theory]
    [InlineData(-1f, 1f, 2f, 0f, 0f, 1f, 1f, -1f, -1f)]
    [InlineData(-2f, -4f, -6f, 3f, 2f, 1f, 5f, 6f, 7f)]
    public void SubtractionOperator_WhenCalledWithPointAndVector_ReturnPointWithSubtractedCordinates(double expectedX, double expectedY, double expectedZ,
                                                                                                     double arg1X, double arg1Y, double arg1Z,
                                                                                                     double arg2X, double arg2Y, double arg2Z)
    {
        Point3D point = new Point3D()
        {
            X = arg1X,
            Y = arg1Y,
            Z = arg1Z
        };

        Vector3 vector = new Vector3()
        {
            X = arg2X,
            Y = arg2Y,
            Z = arg2Z
        };

        Point3D expected = new Point3D()
        {
            X = expectedX,
            Y = expectedY,
            Z = expectedZ
        };

        (Utilities.AreObjectEquals(expected, point - vector)).Should().BeTrue();
    }

    [Theory]
    [InlineData(2f, 2f, 2f, 1f, 1f, 1f, 2f)]
    [InlineData(3f, 3f, 3f, 2f, 2f, 2f, 1.5f)]
    [InlineData(3.5f, -7f, 10.5f, 1f, -2f, 3f, 3.5f)]
    [InlineData(0.5f, -1f, 1.5f, 1f, -2f, 3f, 0.5f)]
    public void MultiplyOperator_WhenCalledWithPointAndScalar_ReturnMultipliedCordinates(double expectedX, double expectedY, double expectedZ,
                                                                                         double argX, double argY, double argZ, double scalar)
    {
        Point3D expected = new Point3D()
        {
            X = expectedX,
            Y = expectedY,
            Z = expectedZ,
            W = 1 * scalar
        };

        Point3D point = new Point3D()
        {
            X = argX,
            Y = argY,
            Z = argZ,
            W = 1
        };

        (Utilities.AreObjectEquals(expected, point * scalar)).Should().BeTrue();
    }

    [Theory]
    [InlineData(1f, 1f, 1f, 2f, 2f, 2f, 2f)]
    [InlineData(2f, 2f, 2f, 3f, 3f, 3f, 1.5f)]
    [InlineData(0.5f, -1f, 1.5f, 1f, -2f, 3f, 2f)]
    public void DivideOperator_WhenCalledWithPointAndScalar_ReturnMultipliedCordinates(double expectedX, double expectedY, double expectedZ,
                                                                                       double argX, double argY, double argZ, double scalar)
    {
        Point3D expected = new Point3D()
        {
            X = expectedX,
            Y = expectedY,
            Z = expectedZ,
            W = 1 / scalar
        };

        Point3D point = new Point3D()
        {
            X = argX,
            Y = argY,
            Z = argZ,
            W = 1
        };

        (Utilities.AreObjectEquals(expected, point / scalar)).Should().BeTrue();
    }

    [Theory]
    [InlineData(1f, -1f, 1f, 2f, -1f, 1f, -1f, -2f)]
    public void NegatePoint_WhenCalled_ReturnPointWithOppositeCordinates(double expectedX, double expectedY, double expectedZ, double expectedW,
                                                                         double argX, double argY, double argZ, double argW)
    {
        Point3D expected = new Point3D()
        {
            X = expectedX,
            Y = expectedY,
            Z = expectedZ,
            W = expectedW
        };

        Point3D point = new Point3D()
        {
            X = argX,
            Y = argY,
            Z = argZ,
            W = argW
        };

        (Utilities.AreObjectEquals(expected, Point3D.NegatePoint(point))).Should().BeTrue();
    }
}
