class Problem10
{
    static void Main()
    {
        string word = Console.ReadLine();

        if (word != null)
        {
            int index = 0;

            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] == word[word.Length - i - 1])
                {
                    index++;
                }
            }

            if (index == word.Length / 2)
            {
                Console.WriteLine("-1");
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    for (int j = 0; j < word.Length; j++)
                        if (word[j] == word[word.Length - j - 1] && i != j)
                            index++;

                    if (index == word.Length / 2)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                    else index = 0;
                }

            }
        }
    }
}