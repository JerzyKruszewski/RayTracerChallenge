using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests;

public class SphereTests
{
    [Fact]
    public void Transformation_WhenCalledWithDefaultValue_ReturnIdentityMatrix()
    {
        Sphere sphere = new Sphere(0);

        sphere.Transformation.Should().BeEquivalentTo(Matrix4x4.IdentityMatrix);
    }

    [Fact]
    public void Transformation_WhenCalled_ReturnTransformationMatrix()
    {
        Sphere sphere = new Sphere(0);
        Matrix4x4 transformationMatrix = Matrix4x4.TranslationMatrix(2, 3, 4);

        sphere.Transformation = transformationMatrix;

        sphere.Transformation.Should().BeEquivalentTo(transformationMatrix);
    }

    [Theory]
    [InlineData(1f, 0f, 0f,
              1f, 0f, 0f)]
    [InlineData(0f, 1f, 0f,
              0f, 1f, 0f)]
    [InlineData(0f, 0f, 1f,
              0f, 0f, 1f)]
    [InlineData(0.5773502691896258, 0.5773502691896258, 0.5773502691896258,
              0.5773502691896258, 0.5773502691896258, 0.5773502691896258)]
    public void NormalAt_WhenCalledWithPointOnSphere_ReturnItsNormalVector(double expectedX, double expectedY, double expectedZ,
                                                                           double argX, double argY, double argZ)
    {
        Vector3 expected = new Vector3(expectedX, expectedY, expectedZ);
        Sphere sphere = new Sphere(0, new Point3D(0f, 0f, 0f));
        Point3D point = new Point3D(argX, argY, argZ);

        Vector3 vector = sphere.NormalAt(point);

        Utilities.AreObjectEquals(expected, vector).Should().BeTrue();
    }

    [Theory]
    [InlineData(1f, 0f, 0f)]
    [InlineData(0f, 1f, 0f)]
    [InlineData(0f, 0f, 1f)]
    [InlineData(0.5773502691896258, 0.5773502691896258, 0.5773502691896258)]
    public void NormalAt_WhenCalledWithPointOnSphere_ReturnNormalisedVector(double argX, double argY, double argZ)
    {
        double expectedLength = 1f;
        Sphere sphere = new Sphere(0, new Point3D(0f, 0f, 0f));
        Point3D point = new Point3D(argX, argY, argZ);

        Vector3 vector = sphere.NormalAt(point);

        vector.Magnitude.Should().Be(expectedLength);
    }

    [Fact]
    public void NormalAt_WhenSphereOriginIsShifted_ReturnItsNormalVector()
    {
        Vector3 expected = new Vector3(0f, 0.7071067811865475, -0.7071067811865476);
        Sphere sphere = new Sphere(0, new Point3D(0f, 0f, 0f));
        sphere.Transformation = sphere.Transformation.Translate(0, 1, 0);
        Point3D point = new Point3D(0, 1.707106781186548, -0.707106781186548);

        Vector3 vector = sphere.NormalAt(point);

        Utilities.AreObjectEquals(expected, vector).Should().BeTrue();
    }

    [Fact]
    public void NormalAt_WhenSphereIsScaled_ReturnItsNormalVector()
    {
        Vector3 expected = new Vector3(0f, 0.970142500145332, -0.24253562503633294);
        Sphere sphere = new Sphere(0, new Point3D(0f, 0f, 0f));
        sphere.Transformation = sphere.Transformation.RotateZ(Math.PI / 5).Scale(1, 0.5, 1);
        Point3D point = new Point3D(0, 0.707106781186548, -0.707106781186548);

        Vector3 vector = sphere.NormalAt(point);

        Utilities.AreObjectEquals(expected, vector).Should().BeTrue();
    }
}
