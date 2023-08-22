using System.Text.RegularExpressions;

class Problem4
{
    static void Main()
    {
        string pattern = @"<a\shref=\W((\W|\w)*)\W>\s?(.*)\s?<\/a>";

        /*
            <a   <a
            \s   пробіл
            href=   href=
            \W   будь-який не алфавітно-цифровий символ(лапки)
            (   група 1
                (\W|\w)*   група2, яка складається з ,алфавітно-цифрових і ні, символів
            )
            \W   будь-який не алфавітно-цифровий символ(лапки)
            >   >
            \s?   можливий пробіл
            (.*)   будь-який символ який може повторюватись багато раз або ні разу
            \s?   можливий пробіл
            <\/a>   <\/a>
         */


        string? action = "<ul>\n    <li>\n\t<a href=\"http://www.goole.com\">Hello world!</a>\n    </li>\n</ul>";

        Regex regex = new(pattern);
        string fixedString = regex.Replace(action, "[URL href=$1>$3[/URL]");

        Console.WriteLine(fixedString);

    }
}
