using System;
using System.Linq;
using System.Collections.Generic;

namespace RayTracer.MathLibrary.Tests;

public class RayTests
{
    [Theory]
    [InlineData(2, 3, 4,
              2, 3, 4,
              1, 0, 0,
              0)]
    [InlineData(3, 3, 4,
              2, 3, 4,
              1, 0, 0,
              1)]
    [InlineData(1, 3, 4,
              2, 3, 4,
              1, 0, 0,
              -1)]
    [InlineData(4.5, 3, 4,
              2, 3, 4,
              1, 0, 0,
              2.5)]
    public void Position_WhenCalled_ReturnPointRepresentingPositionOfRay(double expectedX, double expectedY, double expectedZ,
                                                                         double originX, double originY, double originZ,
                                                                         double directionX, double directionY, double directionZ,
                                                                         double time)
    {
        Point3D expected = new Point3D(expectedX, expectedY, expectedZ);

        Ray ray = new Ray(new Point3D(originX, originY, originZ), new Vector3(directionX, directionY, directionZ));

        Utilities.AreObjectEquals(expected, ray.Position(time)).Should().BeTrue();
    }

    [Theory]
    //Stright through
    [InlineData(0, 0, -5,
              0, 0, 1,
              0, 0, 0,
              2)]
    //At a tangent
    [InlineData(0, 1, -5,
              0, 0, 1,
              0, 0, 0,
              2)]
    //Miss a sphere
    [InlineData(0, 2, -5,
              0, 0, 1,
              0, 0, 0,
              0)]
    //Ray inside sphere
    [InlineData(0, 0, 0,
              0, 0, 1,
              0, 0, 0,
              2)]
    //Sphere behind ray
    [InlineData(0, 0, 5,
              0, 0, 1,
              0, 0, 0,
              2)]
    public void IntersectWithSphere_WhenCalled_ReturnIntersectionsCountWithSphere(double rayOriginX, double rayOriginY, double rayOriginZ,
                                                                                  double directionX, double directionY, double directionZ,
                                                                                  double sphereOriginX, double sphereOriginY, double sphereOriginZ,
                                                                                  int expectedIntersections)
    {
        Ray ray = new Ray(new Point3D(rayOriginX, rayOriginY, rayOriginZ), new Vector3(directionX, directionY, directionZ));
        Sphere sphere = new Sphere(id: 1, new Point3D(sphereOriginX, sphereOriginY, sphereOriginZ));

        ray.IntersectWithSphere(sphere).Count.Should().Be(expectedIntersections);
    }

    [Fact]
    public void IntersectWithSphere_WhenCalledWithScaledSphere_ReturnIntersectionsCountWithSphere()
    {
        int expectedIntersections = 2;
        Ray ray = new Ray(new Point3D(0, 0, -5), new Vector3(0, 0, 1));
        Sphere sphere = new Sphere(id: 1, new Point3D(0, 0, 0));

        sphere.Transformation = Matrix4x4.ScalingMatrix(2, 2, 2);

        ray.IntersectWithSphere(sphere).Count.Should().Be(expectedIntersections);
    }

    [Fact]
    public void IntersectWithSphere_WhenCalledWithTranslatedSphereWhichWillNotBeHit_ReturnZeroIntersections()
    {
        int expectedIntersections = 0;
        Ray ray = new Ray(new Point3D(0, 0, -5), new Vector3(0, 0, 1));
        Sphere sphere = new Sphere(id: 1, new Point3D(0, 0, 0));

        sphere.Transformation = Matrix4x4.TranslationMatrix(5, 0, 0);

        ray.IntersectWithSphere(sphere).Count.Should().Be(expectedIntersections);
    }

    [Theory]
    //Stright through
    [InlineData(0, 0, -5,
              0, 0, 1,
              0, 0, 0,
              4)]
    [InlineData(0, 0, -5,
              0, 0, 1,
              0, 0, 0,
              6)]
    //At a tangent
    [InlineData(0, 1, -5,
              0, 0, 1,
              0, 0, 0,
              5)]
    //Ray inside sphere
    [InlineData(0, 0, 0,
              0, 0, 1,
              0, 0, 0,
              1)]
    [InlineData(0, 0, 0,
              0, 0, 1,
              0, 0, 0,
              -1)]
    //Sphere behind ray
    [InlineData(0, 0, 5,
              0, 0, 1,
              0, 0, 0,
              -4)]
    [InlineData(0, 0, 5,
              0, 0, 1,
              0, 0, 0,
              -6)]
    public void IntersectWithSphere_WhenCalled_CheckIfIntersectionWasFound(double rayOriginX, double rayOriginY, double rayOriginZ,
                                                                           double directionX, double directionY, double directionZ,
                                                                           double sphereOriginX, double sphereOriginY, double sphereOriginZ,
                                                                           double expectedIntersection)
    {
        Ray ray = new Ray(new Point3D(rayOriginX, rayOriginY, rayOriginZ), new Vector3(directionX, directionY, directionZ));
        Sphere sphere = new Sphere(id: 1, new Point3D(sphereOriginX, sphereOriginY, sphereOriginZ));

        (ray.IntersectWithSphere(sphere).FirstOrDefault(i => i.IntersectionTime == expectedIntersection) != null).Should().BeTrue();
    }

    [Theory]
    [InlineData(3)]
    [InlineData(7)]
    public void IntersectWithSphere_WhenCalledWithTransformedSphere_CheckIfIntersectionWasFound(double expectedIntersection)
    {
        Ray ray = new Ray(new Point3D(0,0,-5), new Vector3(0,0,1));
        Sphere sphere = new Sphere(id: 1, new Point3D(0,0,0));

        sphere.Transformation = Matrix4x4.ScalingMatrix(2, 2, 2);

        (ray.IntersectWithSphere(sphere).FirstOrDefault(i => i.IntersectionTime == expectedIntersection) != null).Should().BeTrue();
    }

    [Theory]
    //Stright through
    [InlineData(0, 0, -5,
              0, 0, 1,
              0, 0, 0,
              4.0)]
    //At a tangent
    [InlineData(0, 1, -5,
              0, 0, 1,
              0, 0, 0,
              5.0)]
    //Ray inside sphere
    [InlineData(0, 0, 0,
              0, 0, 1,
              0, 0, 0,
              1.0)]
    //Sphere behind ray
    [InlineData(0, 0, 5,
              0, 0, 1,
              0, 0, 0,
              null)]
    public void Hit_WhenCalled_ReturnFirstIntersection(double rayOriginX, double rayOriginY, double rayOriginZ,
                                                       double directionX, double directionY, double directionZ,
                                                       double sphereOriginX, double sphereOriginY, double sphereOriginZ,
                                                       double? expectedIntersection)
    {
        Ray ray = new Ray(new Point3D(rayOriginX, rayOriginY, rayOriginZ), new Vector3(directionX, directionY, directionZ));
        Sphere sphere = new Sphere(id: 1, new Point3D(sphereOriginX, sphereOriginY, sphereOriginZ));

        ray.IntersectWithSphere(sphere);

        ray.Hit().Should().Be(expectedIntersection);
    }

    [Fact]
    public void Transform_WhenCalledWithTranslationMatrix_ChangeOriginPosition()
    {
        Point3D expectedOriginAfterTrans = new Point3D(4, 6, 8);
        Ray ray = new Ray(new Point3D(1, 2, 3), new Vector3(0, 1, 0));

        Ray transformed = ray.Transform(Matrix4x4.TranslationMatrix(3, 4, 5));

        (expectedOriginAfterTrans == transformed.Origin).Should().BeTrue();
    }

    [Fact]
    public void Transform_WhenCalledWithTranslationMatrix_DoNotChangeVector()
    {
        Vector3 expectedDirection = new Vector3(0, 1, 0);
        Ray ray = new Ray(new Point3D(1, 2, 3), new Vector3(0, 1, 0));

        Ray transformed = ray.Transform(Matrix4x4.TranslationMatrix(3, 4, 5));

        (expectedDirection == transformed.Direction).Should().BeTrue();
    }

    [Fact]
    public void Transform_WhenCalledWithScalingMatrix_ChangeOriginPosition()
    {
        Point3D expectedOriginAfterTrans = new Point3D(2, 6, 12);
        Ray ray = new Ray(new Point3D(1, 2, 3), new Vector3(0, 1, 0));

        Ray transformed = ray.Transform(Matrix4x4.ScalingMatrix(2, 3, 4));

        (expectedOriginAfterTrans == transformed.Origin).Should().BeTrue();
    }

    [Fact]
    public void Transform_WhenCalledWithScalingMatrix_ScaleVector()
    {
        Vector3 expectedDirection = new Vector3(0, 3, 0);
        Ray ray = new Ray(new Point3D(1, 2, 3), new Vector3(0, 1, 0));

        Ray transformed = ray.Transform(Matrix4x4.ScalingMatrix(2, 3, 4));

        (expectedDirection == transformed.Direction).Should().BeTrue();
    }
}
