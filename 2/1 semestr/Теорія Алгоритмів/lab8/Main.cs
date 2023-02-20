class Program
{
    static void Main(string[] args)
    {
        var binaryTree = new BinaryTree<int>();

        string[] arr = Console.ReadLine().Split(' ');
        List<int> l_integer = new List<int>();

       foreach (string str in arr)
        {
            binaryTree.Add(int.Parse(str));
            l_integer.Add(int.Parse(str));
        }
            
        

        binaryTree.PrintTree();

        // CLR - прямий обхід 
        // LCR - зворотній обхід
        // RCL - симентричний обхід

        Console.WriteLine("\nEnter any type of the bypass: CLR, LCR, RCL");
        string input = Console.ReadLine();

        switch (input)
        {
            case "CLR":
                binaryTree.PrintTree();
                Console.WriteLine();
                break;

            case "LCR":
                int k = 0;
                foreach(var output in binaryTree.LeftSide)
                {
                    ++k;
                    if (k % 2 == 0)
                        Console.WriteLine(output);
                    else
                        Console.WriteLine(" " + output);
                }

                k = 0;

                Console.WriteLine("    " + binaryTree.Center);

                foreach (var output in binaryTree.RightSide)
                {
                    ++k;
                    if (k % 2 == 0)
                        Console.WriteLine(output);
                    else
                        Console.WriteLine(" " + output);
                }
                break;
            case "RCL":
                 int k1 = 0;
                foreach (var output in binaryTree.RightSide)
                {
                    ++k1;
                    if (k1 % 2 == 0)
                        Console.WriteLine(output);
                    else
                        Console.WriteLine(" " + output);
                }

                k1 = 0;

                Console.WriteLine("    " + binaryTree.Center);

                foreach (var output in binaryTree.LeftSide)
                {
                    ++k1;
                    if (k1 % 2 == 0)
                        Console.WriteLine(output);
                    else
                        Console.WriteLine(" " + output);
                }
                break;
        }

        Console.WriteLine("\n");

        FindMinMax(l_integer);

        int summa = FindSum(l_integer);

        Console.WriteLine($"\nsum == {summa}");

        Console.WriteLine("\nRemoving....");

        RemovePairEl(ref binaryTree, l_integer);

        binaryTree.PrintTree();

        Console.Write("\nEnter any number you want to find in tree: ");

        int number = int.Parse(Console.ReadLine());
        int count = FindEqNumber(l_integer, number);

        Console.WriteLine($"Count of the entering {number} == {count}\n");
    }


    static void FindMinMax(List<int> list)
    {
        int max = -9999999;
        int min = 9999999;

        foreach (var item in list)
        {
            try
            {
                string numb = Convert.ToString(item);
                if(item> max)
                {
                    max = item;
                }
                if (item < min)
                {
                    min = item;
                }
                
            }
            catch { }
        }

        Console.WriteLine("\n" + "max == " + max + "\nmin == " + min);
    }

    static void RemovePairEl(ref BinaryTree<int> bt, List<int> l1)
    {
        foreach (var list in l1)
        {
            try
            {
                if (list % 2 == 0)
                    bt.Remove(list);
            }
            catch { }
        }
    }

    static int FindEqNumber(List<int> list, int number)
    {
        
        int count = 0;

        foreach (var item in list)
        {
                if (number == item)
                    ++count;
        }

        return count;
    }

    static int FindSum(List<int> l)
    {
        int sum = 0;

        foreach (var item in l)
        {
            sum += item;
        }

        return sum;
    }
}