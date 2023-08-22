class Problem2
{
    static void Main()
    {
        string str = Console.ReadLine();

        if (str != null)
        {
            if (str.Length > 20)
                str = str.Substring(0, 20);
            else if (str.Length < 20)
                str = str.PadRight(20, '*');
        }
        Console.WriteLine(str);


        Console.ReadKey();
    }
}
