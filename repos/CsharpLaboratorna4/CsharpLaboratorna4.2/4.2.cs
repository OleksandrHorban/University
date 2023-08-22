using System;

namespace ClassBox
{
    class Program
    {
        public static float SurfaceArea(float l, float w, float h)
        {
            float sr = 2 * (l * w + w * h + l * h);
            return sr;
        }
        public static float LateralSurfaceArea(float l, float w, float h)
        {
            float ls = 2 * (l * h) + 2 * (w * h);
            return ls;
        }
        public static float Volume(float l, float w, float h)
        {
            float v = l * w * h;
            return v;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length");
            float length = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the width");
            float width = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the height");
            float height = float.Parse(Console.ReadLine());
            if (length > 0 & width > 0 & height > 0) {
                Console.WriteLine("Surface Area - " + SurfaceArea(length, width, height));
                Console.WriteLine("Lateral Surface Area - " + LateralSurfaceArea(length, width, height));
                Console.WriteLine("Volume - " + Volume(length, width, height));
            }
            else
            {
                Console.WriteLine("Width cannot be zero or negative.");
            }
        }
    }
}