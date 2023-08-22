namespace Problem5
{
    using System;
    using System.Collections.Generic;

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

            string givenElement = Console.ReadLine();

            Console.WriteLine(GetCountOfGreaterElements(box.Elements, givenElement));
        }

        public static int GetCountOfGreaterElements<T>(List<T> listWithElements, T element) where T : IComparable
        {
            int count = 0;

            foreach (var e in listWithElements)
            {
                if (e.CompareTo(element) == 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
