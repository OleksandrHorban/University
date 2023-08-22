class Problem8
{
    static void Main()
    {
        string term = Console.ReadLine();

        if (term != null)
        {
            string[] words = term.Split(' ', ',', '.', '?', '!');

            List<string> palindromes = new();

            foreach (string word in words)
            {
                int index = 0;
                for (int i = 0; i < word.Length / 2; i++)
                {
                    if (word[i] == word[word.Length - i - 1])
                    {
                        index++;
                    }
                }

                if (index == word.Length / 2 && word.Length > 0) 
                {
                    for (int j = 0; j < palindromes.Count; j++) // чи записаний вже такий паліндром
                        if (word == palindromes[j])
                        {
                            index = -1;
                            break;
                        }

                    if (index != -1)
                    {
                        palindromes.Add(word);
                    }
                }
            }

            palindromes.Sort();
            Console.WriteLine(string.Join(", ", palindromes));
        }
    }
}
