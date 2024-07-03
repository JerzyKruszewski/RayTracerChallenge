using System;

namespace RayTracer.MathLibrary.Tests;

public class MathHelperTests
{
    [Theory]
    [InlineData(0f, 0f, 0f)]
    public void CreateObjectIn3DSpace_WhenCalledWithPointCordinates_DoesCreatePoint(double x, double y, double z)
    {
        MathHelper.CreateObjectIn3DSpace(Tuple.Create<double, double, double, double>(x, y, z, 1.0f)).Should().BeOfType<Point3D>();
    }

    [Theory]
    [InlineData(0f, 0f, 0f)]
    public void CreateObjectIn3DSpace_WhenCalledWithPointCordinates_DoesNotCreateVector(double x, double y, double z)
    {
        MathHelper.CreateObjectIn3DSpace(Tuple.Create<double, double, double, double>(x, y, z, 1.0f)).Should().NotBeOfType<Vector3>();
    }

    [Theory]
    [InlineData(0f, 0f, 0f)]
    public void CreateObjectIn3DSpace_WhenCalledWithVectorCordinates_DoesCreateVector(double x, double y, double z)
    {
        MathHelper.CreateObjectIn3DSpace(Tuple.Create<double, double, double, double>(x, y, z, 0.0f)).Should().BeOfType<Vector3>();
    }

    [Theory]
    [InlineData(0f, 0f, 0f)]
    public void CreateObjectIn3DSpace_WhenCalledWithVectorCordinates_DoesNotCreatePoint(double x, double y, double z)
    {
        MathHelper.CreateObjectIn3DSpace(Tuple.Create<double, double, double, double>(x, y, z, 0.0f)).Should().NotBeOfType<Point3D>();
    }

    [Theory]
    [InlineData(true, 0f, 0.09f, 0.1f)]
    [InlineData(true, 0f, -0.09f, 0.1f)]
    [InlineData(true, 0f, 0.00009f, 0.0001f)]
    [InlineData(true, 0.000009f, 0f, 0.00001f)]
    [InlineData(false, 0f, 0.11f, 0.1f)]
    [InlineData(false, 1f, 0.09f, 0.1f)]
    public void AreNumbersEqual_WhenCalled_ReturnIfNumbersAreEqual(bool expected, double first, double second, double epsilon)
    {
        MathHelper.AreNumbersEqual(first, second, epsilon).Should().Be(expected);
    }
}