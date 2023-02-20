using static System.Net.Mime.MediaTypeNames;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        KMP();

        Console.WriteLine("\n" + new string('-', 50) + "\n");

        Rab();

        Console.ReadKey();
    }

    private static void KMP()
    {
        string txt = Console.ReadLine();
        string pat = Console.ReadLine();

        Console.WriteLine(FindSubstring(pat, txt));
    }

    private static void Rab()
    {
        string txt = Console.ReadLine();
        string pat = Console.ReadLine();

        Console.WriteLine(Rabina(pat, txt));
    }

    // Алгоритм Рабіна-Карпа

    // Хеш-функція для алгоритму Рабіна-Карпа
    public static int Hash(string x)
    {
        int p = 31; // Просте число
        int rez = 0; // Змінна для результату вичислення
        for (int i = 0; i < x.Length; i++)
            rez += (int)Math.Pow(p, x.Length - 1 - i) * (int)(x[i]); // Підрахунок хеш-функції

        return rez;
    }
    //Функція пошуку алгоритмом Рабіна-Карпа
    public static string Rabina(string x, string s)
    {
        string nom = ""; //Номера всіх входжень в рядок
        if (x.Length > s.Length) return nom;
        int xhash = Hash(x); //Обчислення хеш-функції шуканого рядка
        int shash = Hash(s.Substring(0, x.Length)); //Обчислення хеш-функції першого слова довжини зразка в рядку S
        bool flag;
        int j;
        for (int i = 0; i < s.Length - x.Length; i++)
        {
            if (xhash == shash) // Якщо значення хеш-функцій співпадають
            {
                flag = true;
                j = 0;
                while ((flag == true) && (j < x.Length))
                {
                    if (x[j] != s[i + j]) flag = false;
                    j++;
                }
                if (flag == true) //Якщо шуканий рядок співпав з частиною головної
                    nom = nom + Convert.ToString(i) + ", "; //Додаємо номер входження
            }
            else //Або вичислення нового значення хеш функції
                shash = (shash - (int)Math.Pow(31, x.Length - 1) * (int)(s[i])) * 31 + (int)(s[i + x.Length]);
        }
        if (nom != "") //Якщо входження не знайдено
        {
            nom = nom.Substring(0, nom.Length - 2); //Видаляємо кому після пробілу
        }
        return nom; //Повертаємо результат пошуку
    }

    //Алгоритм КМП
    static int[] GetPrefix(string s)
    {
        int[] result = new int[s.Length];
        result[0] = 0;
        int index = 0;

        for (int i = 1; i < s.Length; i++)
        {
            while (index >= 0 && s[index] != s[i]) { index--; }
            index++;
            result[i] = index;
        }

        return result;
    }

    static int FindSubstring(string pattern, string text)
    {
        int[] pf = GetPrefix(pattern);
        int index = 0;

        for (int i = 0; i < text.Length; i++)
        {
            while (index > 0 && pattern[index] != text[i]) { index = pf[index - 1]; }
            if (pattern[index] == text[i]) index++;
            if (index == pattern.Length)
            {
                return i - index + 1;
            }
        }

        return -1;
    }



}