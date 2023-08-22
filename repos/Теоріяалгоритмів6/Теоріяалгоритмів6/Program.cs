using System.Diagnostics;

public class LinearConRng
{
    private const long a = 25214903917;
    private const long c = 11;
    private long seed;
    public LinearConRng(long seed)
    {
        if (seed < 0)
            throw new Exception("Bad seed");
        this.seed = seed;
    }
    private int next(int bits)
    {
        seed = (seed * a + c) & ((1L << 48) - 1);
        return (int)(seed >> (48 - bits));
    }
    public double Next()
    {
        return (((long)next(26) << 27) + next(27)) / (double)(1L << 53);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();

        List<int> list = new List<int>();
        LinearConRng lincon = new LinearConRng(0);
        int n = int.Parse(Console.ReadLine());

        if (n > 0 && n < 256)
            for (int i = 1; i < n; ++i)
            {
                double x = lincon.Next();
                int ri = (int)((0 - 256) * x + 256);
                list.Add(ri);
            }
        else
        {
            if (n < 0)
                Console.WriteLine($"Error: {n} < 0");
            if (n > 256)
                Console.WriteLine($"Error: {n} > 256");
        }

        foreach (var l in list)
            Console.WriteLine(l);

        Console.WriteLine("\n" + new string('-', 50) + "\n");

        for (int i = 1; i < list.Count; ++i)
            Bit_test(list[i - 1], list[i]);

        sw.Stop();

        Console.WriteLine("Time: " + sw.Elapsed);
    }

    static void Bit_test(int a, int b)
    {
        int key = 101010;

        int encrypt1 = a ^ key;
        int encrypt2 = b ^ key;

        string s1 = encrypt1.ToString();
        string s2 = encrypt2.ToString();

        char zero = '0';
        char one = '1';

        int counter_null_str1 = Numerator(ref zero, ref s1);
        int counter_null_str2 = Numerator(ref zero, ref s2);

        int counter_one_str1 = Numerator(ref one, ref s1);
        int counter_one_str2 = Numerator(ref one, ref s2);

        if ((counter_null_str1 == counter_null_str2) || (counter_one_str1 == counter_one_str2))
            Console.WriteLine($"{a} && {b} == {true}");
        else
            Console.WriteLine($"{a} && {b} == {false}");
    }

    static int Numerator(ref char ch, ref string s)
    {
        int k = 0;

        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == ch)
                ++k;
        }

        return k;
    }


}
