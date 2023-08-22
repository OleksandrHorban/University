class Problem1
{
    public static void Main()
    {
        string str, str1 = "";


        Console.Write("\n\n");
        Console.Write("Print a string in reverse order:\n");
        Console.Write("----------------------------------");
        Console.Write("\n\n");

        Console.Write("Input  A String : ");
        str = Console.ReadLine();


        for (int i = str.Length - 1; i >= 0; i--)
        {

            str1 = str1 + str[i];


        }

        Console.WriteLine("The string in Reverse  Order Is : {0}", str1);
        Console.Write("\n");

    }
}
