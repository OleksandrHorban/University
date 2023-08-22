class Problem9
{
    static void Main()
    {
        string sentence = Console.ReadLine();

        if (sentence != null)
        {
            string[] words = sentence.Split(' ', '.', ',', '?', '!', ';');

            foreach (string word in words)
            {
                string UpdatedWord = "";
                for (int i = 0; i < word.Length; i++)
                {
                    UpdatedWord += word[i];
                    if (i == 0)
                    {
                        UpdatedWord = UpdatedWord.ToUpper();
                    }
                }

                sentence = sentence.Replace(word, UpdatedWord);
            }

            Console.WriteLine(sentence);
        }
    }
}