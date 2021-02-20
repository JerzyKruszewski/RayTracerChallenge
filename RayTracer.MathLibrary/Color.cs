using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
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
            color1.Red += color2.Red;
            color1.Green += color2.Green;
            color1.Blue += color2.Blue;

            return color1;
        }

        public static Color operator -(Color color1, Color color2)
        {
            color1.Red -= color2.Red;
            color1.Green -= color2.Green;
            color1.Blue -= color2.Blue;

            return color1;
        }

        public static Color operator *(Color color1, Color color2)
        {
            color1.Red *= color2.Red;
            color1.Green *= color2.Green;
            color1.Blue *= color2.Blue;

            return color1;
        }

        public static Color operator *(Color color, float scalar)
        {
            color.Red *= scalar;
            color.Green *= scalar;
            color.Blue *= scalar;

            return color;
        }

        public static bool AreColorsEqual(Color color1, Color color2, float epsilon = 0.00001f)
        {
            return MathHelper.AreNumbersEqual(color1.Red, color2.Red, epsilon)
                && MathHelper.AreNumbersEqual(color1.Green, color2.Green, epsilon)
                && MathHelper.AreNumbersEqual(color1.Blue, color2.Blue, epsilon);
        }
    }
}
