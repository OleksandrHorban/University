 class Program
 {
    static int N;
    static int[,] a;

    static void Main(string[] args)

    {
        Console.Write("Count: ");
        int counT = int.Parse(Console.ReadLine());
            N = counT;
            a = new int[N, 2];
            int[] indx = new int[N];
            int[] b = new int[N];
            for (int i = 0; i < N; i++)
            {
            string[] input = Console.ReadLine().Split(' ');
               
                // Початок інтервалів та їх індекси записуємо в масив A
                a[i, 0] = int.Parse(input[0]);
                a[i, 1] = int.Parse(input[1]);
                // Кінці інтервалів записуємо в масив b
                b[i] = int.Parse(input[1]);
                //Заповнюю масив індексів
                indx[i] = i;
            }

            //Сортування масиву індексів по масиву b
            Array.Sort(b, indx);
        // Далі одним циклом проходимо масив а по полю індексів
            
            int last = 0;
            int poc = 0;
        for (int i = 0; i < N; i++) 
            {
            if (a[indx[i], 0] > last) 
                {
                // В самий початок відсортованого масиву записуємо потрібні нам числа по порядку
                    a[indx[poc], 0] = a[indx[i], 1];
                    poc++;
                    last = b[i];
                }
            }

        Console.WriteLine($"\n{new string('-', 50)}\n");

        Console.WriteLine("Кiлькiсть заявок: " + poc);

        Console.Write("\nНомера: ");
        for (int i = 0; i < poc; i++)
        {
            Console.Write(a[indx[i], 0] + " ");
        }

        Console.WriteLine();
    }

}