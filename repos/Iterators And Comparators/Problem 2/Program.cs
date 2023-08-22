namespace ListIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

            string commandInput = Console.ReadLine();

            while (commandInput != "END")
            {

                try
                {
                    string[] input = commandInput.Split();

                    string command = input[0];

                    switch (command)
                    {
                        case "Create":
                            List<string> elements = input.Skip(1).ToList();

                            listyIterator = new ListyIterator<string>(elements);
                            break;

                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;
                        case "Print":
                            listyIterator.Print();
                            break;
                        case "PrintAll":
                            foreach(var element in listyIterator.PrintAll())
                            {
                                Console.Write($"{element} ");
                            }
                            Console.WriteLine();
                            break;

                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                commandInput = Console.ReadLine();

            }
        }
    }
}
