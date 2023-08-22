using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Rectangle
{
    public string id;
    public double width;
    public double height;
    public double x;
    public double y;

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.x = x;
        this.y = y;
    }
    public string check(Rectangle rectangle)
    {
        if ((rectangle.y >= this.y && rectangle.y - rectangle.height <= this.y && rectangle.x <= this.x && rectangle.x + rectangle.width >= this.x) ||
            (rectangle.y >= this.y && rectangle.y - rectangle.height <= this.y && rectangle.x >= this.x && rectangle.x <= this.x + this.width) ||
            (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x <= this.x && rectangle.x + rectangle.width >= this.x) ||
            (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x >= this.x && rectangle.x <= this.x + this.width))
        {
            return "true";
        }

        return "false";
    }
}

namespace Problem_9.Rectangle_Intersection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rectangles = new Rectangle[n[0]];
            for (int i = 0; i < n[0]; i++)
            {
                var rec = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                var id = rec[0];
                var width = double.Parse(rec[1]);
                var height = double.Parse(rec[2]);
                var x = double.Parse(rec[3]);
                var y = double.Parse(rec[4]);

                rectangles[i] = new Rectangle(id, width, height, x, y);
            }
            for (int i = 0; i < n[1]; i++)
            {
                var tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                var firstRectangle = rectangles.Where(r => r.id == tokens[0]).First();
                var secondRectangle = rectangles.Where(r => r.id == tokens[1]).First();

                Console.WriteLine(firstRectangle.check(secondRectangle));
            }
        }
    }
}