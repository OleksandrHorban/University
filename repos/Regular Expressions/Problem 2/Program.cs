using System.Text.RegularExpressions;

class Problem2
{
    static void Main()
    {
        string pattern = @"(\+\d{3})(([-](2)[-]\d{3}[-])|([\s](2)[\s]\d{3}[\s]))\d{4}";
        /*
        (\+\d{3})   плюс і 3 будь яких десятичних цифр
        (
            (   розділення лише дефісом
                [-]   дифіс
                (2)   двійка
                [-]   дифіс
                \d{3}   3 цифри
                [-]   дифіс
            ) |
            (   розділення лише пробілом
                [\s]   пробіл
                (2)   двійка
                [\s]   пробіл
                \d{3}   3 цифри
                [\s]   пробіл
            )
        )
        \d{4}   4 цифри
        */

        while (true)
        {
            string? action = Console.ReadLine();


            if (action?.ToLower() == "end")
            {
                break;
            }

            if (action != null)
                if (Regex.IsMatch(action, pattern))
                {

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(action);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("The phone number you entered does not match the template and is invalid");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
        }
    }
}
