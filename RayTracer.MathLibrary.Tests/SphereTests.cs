using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests
{
    [TestFixture]
    public class SphereTests
    {
        [Test]
        public void Transformation_WhenCalledWithDefaultValue_ReturnIdentityMatrix()
        {
            Sphere sphere = new Sphere(0);

            Assert.AreEqual(Matrix4x4.IdentityMatrix, sphere.Transformation);
        }

        [Test]
        public void Transformation_WhenCalled_ReturnTransformationMatrix()
        {
            Sphere sphere = new Sphere(0);
            Matrix4x4 transformationMatrix = Matrix4x4.TranslationMatrix(2, 3, 4);

            sphere.Transformation = transformationMatrix;

            Assert.AreEqual(transformationMatrix, sphere.Transformation);
        }
    }
}
