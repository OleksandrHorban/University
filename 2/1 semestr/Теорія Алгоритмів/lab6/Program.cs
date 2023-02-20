using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            double n = double.Parse(Console.ReadLine());
            N = n;

            if (n <= 0.0)
            {
                throw new Exception($"{n} must be more than 0");
            }
            else
            {
                Stopwatch sw = Stopwatch.StartNew();
                Console.WriteLine("result: " + My_recursion(n));
                sw.Stop();

                Console.WriteLine(sw.Elapsed);

                Console.WriteLine(new string('-', 50));


                Stopwatch stopwatch = Stopwatch.StartNew();

                Console.WriteLine("result: " + My_recursion2(n));

                stopwatch.Stop();

                Console.WriteLine(new string('-', 50));

                Console.WriteLine(stopwatch.Elapsed);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    static double My_recursion(double n)
    {
        double k = n;
        double d = 0;

        while (n >= 1)
        {
            n = n / 5.0;
            d += n;
        }

        return (4.0 * d + Math.Pow(k, 3));
    }

    static double My__recursion2(double n)
    {
        if (n < 1)
            return (4.0 * (n) + Math.Pow(N, 3));

        return (My_recursion2(n / 5.0));
    }
    static double N = 0;
























































































































    static double My_recursion2(double n)
    {
        double d = My_recursion(n);

        return d;
    }
}