using System.Text;

namespace RayTracer.MathLib;

public class PPMFileStorage
{
    public static void CanvasToPPMFile(string fileName, Color[,] canvas)
    {
        int width = (int)canvas.GetLongLength(0);
        int height = (int)canvas.GetLongLength(1);

        using StreamWriter writer = new StreamWriter($"./{fileName}.ppm", false, Encoding.Default);
        writer.Write($"P3{Environment.NewLine}{width} {height}{Environment.NewLine}255{Environment.NewLine}");

        string line = "";

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                string redText = $"{Color.ConvertColorValueToByte(canvas[j, i].Red)} ";

                if (line.Length + redText.Length > 70)
                {
                    writer.Write($"{line.Trim()}{Environment.NewLine}");

                    line = $"{redText}";
                }
                else
                {
                    line += $"{redText}";
                }

                string greenText = $"{Color.ConvertColorValueToByte(canvas[j, i].Green)} ";

                if (line.Length + greenText.Length > 70)
                {
                    writer.Write($"{line.Trim()}{Environment.NewLine}");

                    line = $"{greenText}";
                }
                else
                {
                    line += $"{greenText}";
                }

                string blueText = $"{Color.ConvertColorValueToByte(canvas[j, i].Blue)} ";

                if (line.Length + blueText.Length > 70)
                {
                    writer.Write($"{line.Trim()}{Environment.NewLine}");

                    line = $"{blueText}";
                }
                else
                {
                    line += $"{blueText}";
                }
            }

            writer.Write($"{line.Trim()}{Environment.NewLine}");

            line = "";
        }
    }
}
