using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests;

public class PPMFileStorageTests
{
    [Theory]
    [InlineData(80, 40)]
    public void CanvasToPPMFile_WhenCalled_CorrectlyInitializeHeader(int width, int height)
    {
        Canvas canvas = new Canvas(width, height);

        string ppmContent = "";

        PPMFileStorage.CanvasToPPMFile("test1", canvas.GetCanvas());

        using (StreamReader reader = new StreamReader("./test1.ppm"))
        {
            ppmContent = reader.ReadToEnd();
        }

        ppmContent.StartsWith($"P3{Environment.NewLine}{width} {height}{Environment.NewLine}255{Environment.NewLine}").Should().BeTrue();
    }

    [Theory]
    [InlineData(80, 40)]
    public void CanvasToPPMFile_WhenCalled_CorrectlyInitializeLastCharacter(int width, int height)
    {
        Canvas canvas = new Canvas(width, height);

        string ppmContent = "";

        PPMFileStorage.CanvasToPPMFile("test2", canvas.GetCanvas());

        using (StreamReader reader = new StreamReader("./test2.ppm"))
        {
            ppmContent = reader.ReadToEnd();
        }

        (ppmContent.EndsWith(Environment.NewLine)).Should().BeTrue();
    }

    [Fact]
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

        string ppmContent = "";

        PPMFileStorage.CanvasToPPMFile("test3", canvas.GetCanvas());

        using (StreamReader reader = new StreamReader("./test3.ppm"))
        {
            ppmContent = reader.ReadToEnd();
        }

        ppmContent.Should().Be(expected);
    }

    [Fact]
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

        string ppmContent = "";

        PPMFileStorage.CanvasToPPMFile("test4", canvas);

        using (StreamReader reader = new StreamReader("./test4.ppm"))
        {
            ppmContent = reader.ReadToEnd();
        }

        ppmContent.Should().Be(expected);
    }
}
