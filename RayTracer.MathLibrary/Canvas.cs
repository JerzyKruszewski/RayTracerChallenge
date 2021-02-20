using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.MathLibrary
{
    public class Canvas
    {
        private readonly Color[,] _canvas;

        public int Width { get; set; }

        public int Height { get; set; }

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;

            _canvas = new Color[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _canvas[i, j] = new Color(0f, 0f, 0f);
                }
            }
        }

        public Color[,] GetCanvas()
        {
            return _canvas;
        }

        public void WritePixel(int x, int y, Color color)
        {
            _canvas[x, y] = color;
        }

        public Color PixelAt(int x, int y)
        {
            return _canvas[x, y];
        }
    }
}
