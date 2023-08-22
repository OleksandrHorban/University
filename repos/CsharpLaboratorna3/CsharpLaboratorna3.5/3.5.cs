using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class DateModifier
{
    public static long GetDaysBetweenTwoDates(string FirstDate, string SecondDate)
    {
        var first = DateTime.ParseExact(FirstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        var second = DateTime.ParseExact(SecondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

        return Math.Abs((first - second).Days);
    }
}

namespace Problem_5.Date_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example: " + "2017 06 20");
            Console.WriteLine();
            Console.Write("First Date: ");
            string FirstD = Console.ReadLine();
            Console.Write("Second Date: ");
            string SecondD = Console.ReadLine();
            Console.WriteLine("The difference in the days between them = " + DateModifier.GetDaysBetweenTwoDates(FirstD, SecondD));
        }
    }
}