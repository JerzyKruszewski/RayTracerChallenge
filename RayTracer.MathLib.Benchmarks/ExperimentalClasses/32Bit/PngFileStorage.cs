using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.MathLib.Benchmarks.ExperimentalClasses._32Bit;

public class PngFileStorage
{
    public static void CanvasToPNGFile(string fileName, Color[,] canvas)
    {
        int width = (int)canvas.GetLongLength(0);
        int height = (int)canvas.GetLongLength(1);

        using Bitmap bitmap = new Bitmap(width, height);
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                bitmap.SetPixel(i, j, System.Drawing.Color.FromArgb((int)(canvas[i, j].Red * 255), (int)(canvas[i, j].Green * 255), (int)(canvas[i, j].Blue * 255)));
            }
        }

        bitmap.Save(fileName);
    }
}
