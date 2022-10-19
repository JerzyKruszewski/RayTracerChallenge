using RayTracer.MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RayCastingTestProject
{
    internal class Program
    {
        public static Canvas canvas = new Canvas(200, 200);
        public static Sphere Sphere = new Sphere(1, new Point3D(0, 0, 0), 1);
        public static Point3D cameraLoc = new Point3D(0, 0, -5, 1);
        public const int WallZCord = 10;
        public const int WallSize = 7;

        public static void Main()
        {
            double pixelSize = (double)(WallSize) / (double)(canvas.Width);
            double half = (double)WallSize / 2;

            for (int i = 0; i < canvas.Height; i++)
            {
                double worldY = half - pixelSize * i;

                for (int j = 0; j < canvas.Width; j++)
                {
                    double worldX = half - pixelSize * j;
                    Point3D position = new Point3D(worldX, worldY, WallZCord);
                    Ray ray = new Ray(cameraLoc, Vector3.Normalize(position - cameraLoc));
                    IList<Intersection> intersect = ray.IntersectWithSphere(Sphere);
                    if (ray.Hit().HasValue)
                    {
                        canvas.WritePixel(j, i, new Color(255, 0, 0));
                    }
                }
            }

            PPMFileStorage.CanvasToPPMFile("RayCastSphere", canvas.GetCanvas());
            Console.WriteLine("Done");
        }
    }
}
