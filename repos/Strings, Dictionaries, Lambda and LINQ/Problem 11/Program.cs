class Problem11
{
    static void Main()
    {
        string A = Console.ReadLine();
        string B = Console.ReadLine();

        if (A != null && B != null)
            for (int i = 0; i < A.Length; i++)
                if (B.Contains(A[i]))
                {
                    Console.WriteLine("yes");
                    break;
                }
                else if (i + 1 >= A.Length)
                {
                    Console.WriteLine("no");
                }
    }
}
