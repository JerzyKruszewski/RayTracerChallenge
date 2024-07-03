using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary.Tests;

public class ColorTests
{
    [Theory]
    [InlineData(-0.5f, -0.5f, 0.4f, 1.7f)]
    public void ColorConstructor_WhenCalledWithParameters_ProperlyInitializeRedComponent(double expected, double red, double green, double blue)
    {
        new Color(red, green, blue).Red.Should().Be(expected);
    }

    [Theory]
    [InlineData(0.4f, -0.5f, 0.4f, 1.7f)]
    public void ColorConstructor_WhenCalledWithParameters_ProperlyInitializeGreenComponent(double expected, double red, double green, double blue)
    {
        new Color(red, green, blue).Green.Should().Be(expected);
    }

    [Theory]
    [InlineData(1.7f, -0.5f, 0.4f, 1.7f)]
    public void ColorConstructor_WhenCalledWithParameters_ProperlyInitializeBlueComponent(double expected, double red, double green, double blue)
    {
        new Color(red, green, blue).Blue.Should().Be(expected);
    }

    [Theory]
    [InlineData(1f, -1f, 0f, 0f, 0f, 1f, 1f, -1f, -1f)]
    [InlineData(1f, 1f, 6f, 3f, -2f, 5f, -2f, 3f, 1f)]
    [InlineData(1.6f, 0.7f, 1.0f, 0.9f, 0.6f, 0.75f, 0.7f, 0.1f, 0.25f)]
    public void AdditionOperator_WhenCalledWithTwoColors_ReturnColorWithAddedColorValues(double expectedX, double expectedY, double expectedZ,
                                                                                         double arg1X, double arg1Y, double arg1Z,
                                                                                         double arg2X, double arg2Y, double arg2Z)
    {
        Color color1 = new Color()
        {
            Red = arg1X,
            Green = arg1Y,
            Blue = arg1Z
        };

        Color color2 = new Color()
        {
            Red = arg2X,
            Green = arg2Y,
            Blue = arg2Z
        };

        Color expected = new Color()
        {
            Red = expectedX,
            Green = expectedY,
            Blue = expectedZ
        };

        Color.AreColorsEqual(expected, color1 + color2).Should().BeTrue();
    }

    [Theory]
    [InlineData(-1f, 1f, 2f, 0f, 0f, 1f, 1f, -1f, -1f)]
    [InlineData(-2f, -4f, -6f, 3f, 2f, 1f, 5f, 6f, 7f)]
    [InlineData(0.2f, 0.5f, 0.5f, 0.9f, 0.6f, 0.75f, 0.7f, 0.1f, 0.25f)]
    public void SubtractionOperator_WhenCalledWithTwoColors_ReturnColorWithSubtractedColorValues(double expectedX, double expectedY, double expectedZ,
                                                                                                 double arg1X, double arg1Y, double arg1Z,
                                                                                                 double arg2X, double arg2Y, double arg2Z)
    {
        Color color1 = new Color()
        {
            Red = arg1X,
            Green = arg1Y,
            Blue = arg1Z
        };

        Color color2 = new Color()
        {
            Red = arg2X,
            Green = arg2Y,
            Blue = arg2Z
        };

        Color expected = new Color()
        {
            Red = expectedX,
            Green = expectedY,
            Blue = expectedZ
        };

        Color.AreColorsEqual(expected, color1 - color2).Should().BeTrue();
    }

    [Theory]
    [InlineData(0f, 0f, -1f, 0f, 0f, 1f, 1f, -1f, -1f)]
    [InlineData(15f, 12f, 7f, 3f, 2f, 1f, 5f, 6f, 7f)]
    [InlineData(0.9f, 0.2f, 0.04f, 1f, 0.2f, 0.4f, 0.9f, 1f, 0.1f)]
    public void MultiplyOperator_WhenCalledWithTwoColors_ReturnColorWithMultipliedColorValues(double expectedX, double expectedY, double expectedZ,
                                                                                              double arg1X, double arg1Y, double arg1Z,
                                                                                              double arg2X, double arg2Y, double arg2Z)
    {
        Color color1 = new Color()
        {
            Red = arg1X,
            Green = arg1Y,
            Blue = arg1Z
        };

        Color color2 = new Color()
        {
            Red = arg2X,
            Green = arg2Y,
            Blue = arg2Z
        };

        Color expected = new Color()
        {
            Red = expectedX,
            Green = expectedY,
            Blue = expectedZ
        };

        Color.AreColorsEqual(expected, color1 * color2).Should().BeTrue();
    }

    [Theory]
    [InlineData(2f, 2f, 2f, 1f, 1f, 1f, 2f)]
    [InlineData(3f, 3f, 3f, 2f, 2f, 2f, 1.5f)]
    [InlineData(3.5f, -7f, 10.5f, 1f, -2f, 3f, 3.5f)]
    [InlineData(0.5f, -1f, 1.5f, 1f, -2f, 3f, 0.5f)]
    [InlineData(0.4f, 0.6f, 0.8f, 0.2f, 0.3f, 0.4f, 2f)]
    public void MultiplyOperator_WhenCalledWithColorAndScalar_ReturnColorWithMultipliedColorValues(double expectedX, double expectedY, double expectedZ,
                                                                                                   double arg1X, double arg1Y, double arg1Z, double scalar)
    {
        Color color = new Color()
        {
            Red = arg1X,
            Green = arg1Y,
            Blue = arg1Z
        };

        Color expected = new Color()
        {
            Red = expectedX,
            Green = expectedY,
            Blue = expectedZ
        };

        Color.AreColorsEqual(expected, color * scalar).Should().BeTrue();
    }

    [Theory]
    [InlineData(255, 2f)]
    [InlineData(255, 1f)]
    [InlineData(204, 0.8f)]
    [InlineData(153, 0.6f)]
    [InlineData(128, 0.5f)]
    [InlineData(0, 0f)]
    [InlineData(0, -1f)]
    public void ConvertColorValueToByte_WhenCalled_ReturnsColorValueIn8BitInteger(int expected, double color)
    {
        Color.ConvertColorValueToByte(color).Should().Be(expected);
    }
}
