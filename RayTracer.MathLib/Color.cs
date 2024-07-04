using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLib;

public class Color : IColor
{
    public double Red { get; set; }

    public double Green { get; set; }

    public double Blue { get; set; }

    public Color()
    {
    }

    public Color(double red, double green, double blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public static Color operator +(Color color1, Color color2)
    {
        return new Color(color1.Red + color2.Red, color1.Green + color2.Green, color1.Blue + color2.Blue);
    }

    public static Color operator -(Color color1, Color color2)
    {
        return new Color(color1.Red - color2.Red, color1.Green - color2.Green, color1.Blue - color2.Blue);
    }

    public static Color operator *(Color color1, Color color2)
    {
        return new Color(color1.Red * color2.Red, color1.Green * color2.Green, color1.Blue * color2.Blue);
    }

    public static Color operator *(Color color, double scalar)
    {
        return new Color(color.Red * scalar, color.Green * scalar, color.Blue * scalar);
    }

    public static bool AreColorsEqual(Color color1, Color color2, double epsilon = 0.00001f)
    {
        return MathHelper.AreNumbersEqual(color1.Red, color2.Red, epsilon)
            && MathHelper.AreNumbersEqual(color1.Green, color2.Green, epsilon)
            && MathHelper.AreNumbersEqual(color1.Blue, color2.Blue, epsilon);
    }

    public static int ConvertColorValueToByte(double color)
    {
        color *= 255;

        if (color - (int)color >= 0.5f)
        {
            return Math.Min(Math.Max(0, (int)color + 1), 255);
        }

        return Math.Min(Math.Max(0, (int)color), 255);
    }
}
