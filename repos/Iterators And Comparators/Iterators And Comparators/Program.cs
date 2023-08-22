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
                    string[] tokens = commandInput.Split();
                    
                    string command = tokens[0];

                        switch (command)
                        {
                            case "Create":
                                List<string> elements = tokens.Skip(1).ToList();

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
