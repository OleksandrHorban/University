using System.Text.RegularExpressions;

class Ex7
{
    static void Main()
    {
        string pattern = @"\w+";

        string[] line =
            //"ds3bhj y1ter/wfsdg 1nh_jgf ds2c_vbg\4htref"
            //"min23/ace hahah21 ( sasa ) att3454/a/a2/abc"
            "chico/ gosho \\ sapunerka (3sas) mazut lelQ_Van4e"
            .Split('/', '\\', ' ', '(', ')');

        int[] Max = new int[]
        {
            0,  // Max
            0,  // Index one
            0   // Index two
        };

        for (int i = 0; i < line.Length; i++) // по першим словам
            for (int j = i + 1; j < line.Length; j++) // по другим словам
                if (Regex.IsMatch(line[i], pattern) // якщо слово відповідає патерну
                    && line[i].Length >= 3 && line[i].Length <= 25)  // якщо слово відповідає мін і макс довжині слова
                    if (Regex.IsMatch(line[j], pattern) // якщо слово відповідає патерну
                        && line[j].Length >= 3 && line[j].Length <= 25)  // якщо слово відповідає мін і макс довжині слова
                    {
                        int length = line[i].Length + line[j].Length; // довжина двох слів

                        Console.WriteLine(line[i] + " " + line[j] + " " + length); // для порівняння (можна закоментувати)

                        if (length > Max[0]) // якщо знайдений нове максимальне число
                        {
                            Max[0] = length; // змінюється максимальна сума двох слів
                            Max[1] = i; // індекс першого слова
                            Max[2] = j; // індекс другого слова
                            j++; // змінюється індекс другого слова
                            i = j; // змінюється індекс першого слова
                        }
                    }

        Console.WriteLine("\n\n" + line[Max[1]]);
        Console.WriteLine(line[Max[2]]);


        Console.ReadKey();
    }
}