using System;
using System.Diagnostics;
using RayTracer.MathLibrary;

namespace CannonTestProject
{
    internal class Program
    {
        public static Canvas canvas = new Canvas(900, 550); 

        public static Projectile projectile = new Projectile()
        {
            Point = new Point3D(0f, 1f, 0f),
            Velocity = Vector3.Normalize(new Vector3(1f, 1.8f, 0f)) * 11.25f
        };

        public static Environment environment = new Environment()
        {
            Gravity = new Vector3(0f, -0.1f, 0f),
            Wind = new Vector3(-0.01f, 0f, 0f)
        };

        private static void Main()
        {
            for (int i = 0; true; i++)
            {
                Tick();
                Console.WriteLine(i);
            }
        }

        public static void Tick()
        {
            try
            {
                canvas.WritePixel((int)projectile.Point.X, canvas.Height - (int)projectile.Point.Y, new Color(1f, 0f, 1f));
            }
            catch (Exception)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                PPMFileStorage.CanvasToPPMFile("Cannon", canvas.GetCanvas());
                stopwatch.Stop();
                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
                System.Environment.Exit(0);
            }
            projectile.Point += projectile.Velocity;
            projectile.Velocity += environment.Gravity + environment.Wind;
        }
    }
}
