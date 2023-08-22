public class Program
{
    public static void Main()
    {
        Stack<int> customStack = new Stack<int>();

        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] parts = input.Split();
            string command = parts[0];
            switch (command)
            {
                case "Push":
                    customStack.Push(parts.Skip(1).Select(int.Parse).ToArray());
                    break;
                case "Pop":
                    customStack.Pop();
                    break;
            }
            input = Console.ReadLine();
        }

        foreach (int num in customStack)
        {
            Console.WriteLine(num);
        }
    }
}