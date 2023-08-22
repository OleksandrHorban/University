using System;

class Problem1
{
    static void Main()
    {
        Dispatcher dispatcher = new();
        Handler handler = new();
        dispatcher.NameChange += handler.OnDispatcherNameChange; //  додаємо делегат

        while (true)
        {
            string? action = Console.ReadLine();

            if (action?.ToLower() == "end")
            {
                break;
            }
            else if (action != null)
            {
                dispatcher.Name = action;
            }
        }

        Console.ReadKey();
    }
}
