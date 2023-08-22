using System.Text.RegularExpressions;

class Problem3
{
    static void Main()
    {
        while (true)
        {
            string? action = Console.ReadLine();
            if (action?.ToLower() == "end")
            {
                break;
            }
            if (action != null)
            {
                string pattern = @"(\w)\1+";

                /*
                   (   група 1
                        \w   яка складається з одної букви
                    )
                    \1+   повторення групи 1 один раз і більше
                 */

                Regex regex = new(pattern);
                action = regex.Replace(action, "$1");
                Console.WriteLine(action);
            }
        }
    }
}
