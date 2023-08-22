using System.Text.RegularExpressions;

class Problem1
{
    static void Main()
    {
        string pattern = @"[A-Z]{1}[a-z]*\s[A-Z]{1}[a-z]*"; // шаблон
        /*
            [A-Z]{1}    перша буква велика і її кількість 1
            [a-z]*    подальші букти лише в малому регістрі і кількість обмежена до кінця строки або пробіла
            \s    пробіл
            [A-Z]{1}    перша буква після пробіла велика і її кількість 1
            [a-z]*    подальші букти лише в малому регістрі і кількість обмежена до кінця строки або пробіла
        */

        while (true)
        {
            string? action = Console.ReadLine();


            if (action?.ToLower() == "end")
            {
                break;
            }

            if (action != null)
            {
                if (Regex.IsMatch(action, pattern))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(action);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("The entered name and surname do not match the template");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}
