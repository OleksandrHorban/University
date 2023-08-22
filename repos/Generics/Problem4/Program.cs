namespace Problem4
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < numberOfLines; i++)
            {
                int content = int.Parse(Console.ReadLine());

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
