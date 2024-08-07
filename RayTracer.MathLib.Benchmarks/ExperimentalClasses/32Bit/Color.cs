﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLib.Benchmarks.ExperimentalClasses._32Bit;

public class Color : IColor
{
    public float Red { get; set; }

    public float Green { get; set; }

    public float Blue { get; set; }

    public Color()
    {
    }

    public Color(float red, float green, float blue)
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

    public static Color operator *(Color color, float scalar)
    {
        return new Color(color.Red * scalar, color.Green * scalar, color.Blue * scalar);
    }

    public static bool AreColorsEqual(Color color1, Color color2, float epsilon = 0.00001f)
    {
        return MathHelper.AreNumbersEqual(color1.Red, color2.Red, epsilon)
            && MathHelper.AreNumbersEqual(color1.Green, color2.Green, epsilon)
            && MathHelper.AreNumbersEqual(color1.Blue, color2.Blue, epsilon);
    }

    public static int ConvertColorValueToByte(float color)
    {
        color *= 255;

        if (color - (int)color >= 0.5f)
        {
            return Math.Min(Math.Max(0, (int)color + 1), 255);
        }

        return Math.Min(Math.Max(0, (int)color), 255);
    }
}
