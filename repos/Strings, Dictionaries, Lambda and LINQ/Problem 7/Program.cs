class Problem7
{
    static void Main()
    {
        string sentence = Console.ReadLine();

        if (sentence != null)
        {
            List<string> newSentence = new();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (i + 7 < sentence.Length)
                    if (sentence[i] == '<' && sentence[i + 1] == 'u' && sentence[i + 2] == 'p' &&
                        sentence[i + 3] == 'c' && sentence[i + 4] == 'a' && sentence[i + 5] == 's' &&
                        sentence[i + 6] == 'e' && sentence[i + 7] == '>')
                    {
                        string temp = "";
                        for (int j = i + 8; j < sentence.Length; j++)
                        {
                            temp += sentence[j];

                            if (i + 9 < sentence.Length)
                                if (sentence[j + 1] == '<' &&
                                    sentence[j + 2] == '/' &&
                                    sentence[j + 3] == 'u' &&
                                    sentence[j + 4] == 'p' &&
                                    sentence[j + 5] == 'c' &&
                                    sentence[j + 6] == 'a' &&
                                    sentence[j + 7] == 's' &&
                                    sentence[j + 8] == 'e' &&
                                    sentence[j + 9] == '>') 
                                { 
                                    i = j;
                                    break; 
                                } 
                        }
                        newSentence.Add(temp);
                    }
            }
            foreach (string temp in newSentence)
            {
                if (sentence.Contains(temp))
                {
                    sentence = sentence.Replace(temp, temp.ToUpper());
                }
            }

            sentence = sentence.Replace("<upcase>", ""); 
            sentence = sentence.Replace("</upcase>", "");

            Console.WriteLine(sentence);
        }
    }
}