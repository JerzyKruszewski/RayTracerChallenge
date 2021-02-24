using RayTracer.MathLibrary;
using System;

namespace ClockTestProject
{
    internal class Program
    {
        public const int NumberOfPixels = 12;
        public static Canvas canvas = new Canvas(400, 400);
        public static Point3D currentLocation = new Point3D(0, 0, 0, 1);
        public static Point3D screenSpaceLocation = new Point3D(0, 0, 0, 1);

        public static void Main()
        {
            Matrix4x4 matrix = Matrix4x4.IdentityMatrix.Translate(canvas.Width * 0.3, 0, 0);
            currentLocation = matrix * currentLocation;

            for (int i = 0; i < NumberOfPixels; i++)
            {
                matrix = Matrix4x4.IdentityMatrix.RotateZ(2 * Math.PI / NumberOfPixels);
                currentLocation = matrix * currentLocation;

                matrix = Matrix4x4.IdentityMatrix.Translate(canvas.Width / 2, canvas.Height / 2, 0);
                screenSpaceLocation = matrix * currentLocation;

                canvas.WritePixel((int)screenSpaceLocation.X, canvas.Height - (int)screenSpaceLocation.Y, new Color(255, 255, 255));
            }

            PPMFileStorage.CanvasToPPMFile("Clock", canvas.GetCanvas());
        }
    }
}
