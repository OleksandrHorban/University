using System.Text.RegularExpressions;

class Problem5
{
    static void Main()
    {
        string URL = Console.ReadLine();

        if (URL != null)
        {
            string protocol = "";
            string server = "";
            string resource = "";

            if (Regex.IsMatch(URL, @"(\w|\W)+://(\w|\W)+")) // якщо є протокол
                for (int i = 0; i < URL.Length; i++)
                    if (i + 1 < URL.Length && URL[i] != '/' && URL[i + 1] != '/') // записується поки не дойде до ://
                        protocol += URL[i];
                    else break;

            if (Regex.IsMatch(URL, @"[A-Z,a-z,0-9]+/(\w|\W)+")) // якщо є ресурс
            {
                for (int i = protocol.Length + 3; i < URL.Length; i++) // записується сервер поки не дойде до /
                    if (i + 2 < URL.Length && URL[i] != '/')
                        server += URL[i];
                    else break;

                for (int i = protocol.Length + 3 + server.Length + 1; i < URL.Length; i++) // записується ресурс
                    resource += URL[i];
            }
            else // якщо ресурсу немає
                for (int i = protocol != "" ? protocol.Length + 3 : protocol.Length; i < URL.Length; i++) // записується сервер
                    server += URL[i];


            Console.WriteLine("[protocol] = \"" + protocol + "\"");
            Console.WriteLine("[server] = \"" + server + "\"");
            Console.WriteLine("[resource] = \"" + resource + "\"");
        }


        Console.ReadKey();
    }
}
