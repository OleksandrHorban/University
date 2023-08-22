using System.Collections.Generic;

class Problem6
{
    static void Main()
    {
        string? sentence = Console.ReadLine(); // речення

        if (sentence != null)
        {
            // речення розбивається на слова
            string[] temp = sentence.Split('.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ');
            List<string> words = new(); // для слів, тому що пробіл і тд. може бути словом " = "
            List<string> characters = new(); // для символів між словами


            foreach (string item in temp) // записуються слова
                if (item.Length > 0) words.Add(item);

            for (int i = 0; i < words.Count - 1; i++) // записуються символи віж словами
                characters.Add
                    (
                        sentence.Substring // вирізається строка
                        (
                            sentence.IndexOf(words[i]) + words[i].Length, // між першим входженням слова
                            sentence.IndexOf(words[i + 1]) - (sentence.IndexOf(words[i]) + words[i].Length) // до початку наступного слова
                        )
                    );

            string newSentence = ""; // зареверснене речення
            int index = 0; // для проходження по characters
            for (int i = words.Count - 1; i >= 0; i--) // з останнього слова до першого
            {
                newSentence += words[i]; // додається слово

                if (index < characters.Count)
                    newSentence += characters[index++]; // додається символ між словами
            }
            newSentence += sentence.Substring(newSentence.Length); // додаються символи після останнього слова

            Console.WriteLine(newSentence); // виводиться зареверснене речення
        }


        Console.ReadKey();
    }
}
