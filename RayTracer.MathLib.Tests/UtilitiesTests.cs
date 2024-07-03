using System;
using System.Collections.Generic;

namespace RayTracer.MathLibrary.Tests;

public class UtilitiesTests
{
    [Theory]
    [InlineData(0f, 0f, 0f)]
    public void CastPointToVector_WhenCalledWithPoint_CastItToVector(double argX, double argY, double argZ)
    {
        Utilities.CastPointToVector(new Point3D()
        {
            X = argX,
            Y = argY,
            Z = argZ
        }).Should().BeOfType<Vector3>();
    }

    [Theory]
    [InlineData(1, 0.9)]
    [InlineData(1, 1.1)]
    [InlineData(-1, -0.9)]
    [InlineData(-1, -1.1)]
    [InlineData(1, 1)]
    [InlineData(-1, -1)]
    [InlineData(1, 0.50001)]
    [InlineData(1, 1.00001)]
    [InlineData(-1, -0.50001)]
    [InlineData(-1, -1.00001)]
    public void CastDoubleToInt_WhenCalledWithDouble_CastToInt(int expected, double number)
    {
        Utilities.CastDoubleToInt(number).Should().Be(expected);
    }
}
