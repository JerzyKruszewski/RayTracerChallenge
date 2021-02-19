﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RayTracer.MathLibrary.Tests
{
    public class UtilitiesTests
    {
        [Test]
        [TestCase(0f, 0f, 0f)]
        public void CastPointToVector_WhenCalledWithPoint_CastItToVector(float argX, float argY, float argZ)
        {
            Assert.IsInstanceOf<Vector3>(Utilities.CastPointToVector(new Point3D()
            {
                X = argX,
                Y = argY,
                Z = argZ
            }));
        }
    }
}
