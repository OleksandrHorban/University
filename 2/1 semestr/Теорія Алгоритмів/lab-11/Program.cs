using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        List<IntPoint> points = new List<IntPoint>();

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; points.Count != number; ++i)
        {
            int x = rand.Next(200)-100;
            int y = rand.Next(200)-100;

            if(x > 0 && y > 0)
                points.Add(new IntPoint(x, y));
        }

        IConvexHullAlgorithm hullFinder = new GrahamConvexHull();
        List<IntPoint> hull = hullFinder.FindHull(points);

        Console.WriteLine("result: \n\n");

        foreach (IntPoint point in hull)
        {
            Console.WriteLine("X: " + point.X + " Y: " + point.Y);
        }
    }
}