using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests
{
    public class ColorTests
    {
        [Test]
        [TestCase(-0.5f, -0.5f, 0.4f, 1.7f)]
        public void ColorConstructor_WhenCalledWithParameters_ProperlyInitializeRedComponent(float expected, float red, float green, float blue)
        {
            Assert.AreEqual(expected, new Color(red, green, blue).Red);
        }

        [Test]
        [TestCase(0.4f, -0.5f, 0.4f, 1.7f)]
        public void ColorConstructor_WhenCalledWithParameters_ProperlyInitializeGreenComponent(float expected, float red, float green, float blue)
        {
            Assert.AreEqual(expected, new Color(red, green, blue).Green);
        }

        [Test]
        [TestCase(1.7f, -0.5f, 0.4f, 1.7f)]
        public void ColorConstructor_WhenCalledWithParameters_ProperlyInitializeBlueComponent(float expected, float red, float green, float blue)
        {
            Assert.AreEqual(expected, new Color(red, green, blue).Blue);
        }
    }
}
