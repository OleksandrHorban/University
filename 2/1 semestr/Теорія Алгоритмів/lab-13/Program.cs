class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("N: ");

            int n = int.Parse(Console.ReadLine());

            Console.Write("M: ");

            int m = int.Parse(Console.ReadLine());

            if ((n < 1 || n > 256) || (m < 1 || m > 256))
                throw new ArgumentException("Somethings went wrong :(");

            int[,] matrix = new int[n, m];

            Random r = new Random();

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    matrix[i, j] = r.Next(-20, 20);
                }
            }

            Console.WriteLine($"\n{new string('-', 80)}\n Original Matrix:");

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.Write("\nA(i,j) = {\ni =");

            int i_ = int.Parse(Console.ReadLine());

            Console.Write("j = ");

            int j_ = int.Parse(Console.ReadLine());

            Console.WriteLine("};\n");

            Console.WriteLine($"{new string('-', 80)}\n Road to the A({i_},{j_})");

            FindMaxSum(ref matrix, n, m, i_, j_);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n" + ex.Message);
        }
    }

    private static void FindMaxSum(ref int[,] matrix, int row, int column, int n, int m)
    {
        int maxSum = -99999, sum = 0;
        string POS = "";

        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < m; ++j)
            {
                sum += matrix[i, j];

                if (maxSum < sum)
                {
                    maxSum = sum;
                    POS = "L";
                }
            }
        }

        sum = 0;

        for (int i = row - 1; i >= n; --i)
        {
            for (int j = column - 1; j >= m; --j)
            {
                sum += matrix[i, j];

                if (maxSum < sum)
                {
                    maxSum = sum;
                    POS = "R";
                }
            }
        }

        Console.WriteLine($"MaxSum: {maxSum}");


        string[,] arr = new string[row, column];

        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < column; ++j)
            {
                arr[i, j] = Convert.ToString(matrix[i, j]);
            }
        }

        int k = 0;

        switch (POS)
        {
            case "L":

                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < column; ++j)
                    {
                        arr[i, j] = "*";
                        if (i == n && j == m)
                        {
                            k = -1;
                            break;
                        }
                    }

                    if (k == -1)
                        break;
                }

                break;

            case "R":

                for (int i = row - 1; i >= 0; --i)
                {
                    for (int j = column - 1; j >= 0; --j)
                    {
                        arr[i, j] = "*";
                        if (i == n && j == m)
                        {
                            k = -1;
                            break;
                        }
                    }

                    if (k == -1)
                        break;
                }

                break;
        }

        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < column; ++j)
            {
                Console.Write($"{arr[i, j]}\t");
            }

            Console.WriteLine();
        }

    }
}