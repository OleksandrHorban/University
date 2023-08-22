using System;
using System.Linq;

public class LargestCommonEnd
{
    public static void Main()
    {
        string[] firstWords = Console.ReadLine().Split().ToArray();
        string[] secondWords = Console.ReadLine().Split().ToArray();

        int minLength = Math.Min(firstWords.Length, secondWords.Length);

        int firstLength = GetMaxLength(firstWords, secondWords, minLength);

        Array.Reverse(firstWords);
        Array.Reverse(secondWords);

        int secondLength = GetMaxLength(firstWords, secondWords, minLength);

        if (firstLength > secondLength)
        {
            Console.WriteLine(firstLength);
        }
        else
        {
            Console.WriteLine(secondLength);
        }
    }

    private static int GetMaxLength(string[] firstWords, string[] secondWords, int minLength)
    {
        int firstLength = 0;
        for (int i = 0; i < minLength; i++)
        {
            if (firstWords[i].Equals(secondWords[i]))
            {
                firstLength++;
            }
            else
            {
                break;
            }
        }

        return firstLength;
    }
}