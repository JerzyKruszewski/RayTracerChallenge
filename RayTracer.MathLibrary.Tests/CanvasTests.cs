using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests
{
    public class CanvasTests
    {
        [Test]
        [TestCase(10, 10, 20)]
        public void CanvasConstructor_WhenCalled_CreateCanvasWithProperWidth(int expected, int width, int height)
        {
            Assert.AreEqual(expected, new Canvas(width, height).Width);
        }

        [Test]
        [TestCase(20, 10, 20)]
        public void CanvasConstructor_WhenCalled_CreateCanvasWithProperHeight(int expected, int width, int height)
        {
            Assert.AreEqual(expected, new Canvas(width, height).Height);
        }

        [Test]
        [TestCase(10, 20)]
        public void GetCanvas_WhenCalled_CreateAndReturnCanvasWithOnlyBlackPixels(int width, int height)
        {
            bool allBlack = true;
            Color black = new Color(0f, 0f, 0f);
            Color[,] canvas = new Canvas(width, height).GetCanvas();

            for (int i = 0; i < canvas.GetLongLength(0); i++)
            {
                for (int j = 0; j < canvas.GetLongLength(1); j++)
                {
                    if (!Color.AreColorsEqual(canvas[i, j], black))
                    {
                        allBlack = false;
                        break;
                    }
                }
            }

            Assert.IsTrue(allBlack);
        }

        [Test]
        [TestCase(0, 0, 1f, 0f, 0f)]
        public void WritePixel_WhenCalled_ChangeColorOfOnePixel(int x, int y, float red, float green, float blue)
        {
            Color color = new Color(red, green, blue);
            Canvas canvas = new Canvas(10, 10);
            Color[,] canvasTable = canvas.GetCanvas();

            canvas.WritePixel(x, y, color);

            Assert.IsTrue(Color.AreColorsEqual(color, canvasTable[x, y]));
        }

        [Test]
        [TestCase(0f, 0f, 0f, 0, 0)]
        public void PixelAt_WhenCalled_ReturnColorOfPixel(float red, float green, float blue, int x, int y)
        {
            Color expected = new Color(red, green, blue);
            Canvas canvas = new Canvas(10, 10);
            Color[,] canvasTable = canvas.GetCanvas();

            Assert.IsTrue(Color.AreColorsEqual(expected, canvasTable[x, y]));
        }

    }
}
