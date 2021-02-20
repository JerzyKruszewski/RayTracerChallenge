using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests
{
    public class PPMFileStorageTests
    {
        [Test]
        [TestCase(80, 40)]
        public void CanvasToPPMFile_WhenCalled_CorrectlyInitializeHeader(int width, int height)
        {
            Canvas canvas = new Canvas(width, height);

            string ppmContent = PPMFileStorage.CanvasToPPMFile(canvas.GetCanvas());

            Assert.IsTrue(ppmContent.StartsWith($"P3{Environment.NewLine}{width} {height}{Environment.NewLine}255{Environment.NewLine}"));
        }

        [Test]
        [TestCase(80, 40)]
        public void CanvasToPPMFile_WhenCalled_CorrectlyInitializeLastCharacter(int width, int height)
        {
            Canvas canvas = new Canvas(width, height);

            string ppmContent = PPMFileStorage.CanvasToPPMFile(canvas.GetCanvas());

            Assert.IsTrue(ppmContent.EndsWith(Environment.NewLine));
        }

        [Test]
        public void CanvasToPPMFile_WhenCalled_CorrectlyInitializeFile()
        {
            string expected = @"P3
5 3
255
255 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 128 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 255
";
            Canvas canvas = new Canvas(5, 3);
            Color color1 = new Color(1.5f, 0f, 0f);
            Color color2 = new Color(0f, 0.5f, 0f);
            Color color3 = new Color(-0.5f, 0f, 1f);

            canvas.WritePixel(0, 0, color1);
            canvas.WritePixel(2, 1, color2);
            canvas.WritePixel(4, 2, color3);

            Assert.AreEqual(expected, PPMFileStorage.CanvasToPPMFile(canvas.GetCanvas()));
        }

        [Test]
        public void CanvasToPPMFile_WhenCalled_CorrectlySplitColors()
        {
            string expected = @"P3
10 2
255
255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
153 255 204 153 255 204 153 255 204 153 255 204 153
255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
153 255 204 153 255 204 153 255 204 153 255 204 153
";
            Canvas canvas1 = new Canvas(10, 2);
            Color color = new Color(1f, 0.8f, 0.6f);

            Color[,] canvas = canvas1.GetCanvas();

            for (int i = 0; i < canvas.GetLongLength(0); i++)
            {
                for (int j = 0; j < canvas.GetLongLength(1); j++)
                {
                    canvas1.WritePixel(i, j, color);
                }
            }

            Assert.AreEqual(expected, PPMFileStorage.CanvasToPPMFile(canvas1.GetCanvas()));
        }

        [Test]
        public void SavePPMFile_WhenCalled_CreateAFileWithContent()
        {
            string fileContent = "";
            string expected = @"P3
10 2
255
255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
153 255 204 153 255 204 153 255 204 153 255 204 153
255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
153 255 204 153 255 204 153 255 204 153 255 204 153
";

            PPMFileStorage.SavePPMFile("test", expected);

            using (System.IO.StreamReader reader = new System.IO.StreamReader("./test.ppm"))
            {
                fileContent = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, fileContent);
        }
    }
}
