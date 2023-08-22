namespace Problem3
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string content = Console.ReadLine();

                box.Add(content);
            }

            int[] inputIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = inputIndexes[0];
            int secondIndex = inputIndexes[1];

            box.SwapElements(firstIndex, secondIndex);

            Console.WriteLine(box.ToString());
        }
    }
}
