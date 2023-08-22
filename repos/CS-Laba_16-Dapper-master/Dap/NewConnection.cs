using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class NewConnection
{
    public static async Task Connection()
    {
        try // якщо БД [Список розсилки] створенно
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Список розсилки;Trusted_Connection=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync(); // асинхронно відкривається нове підключення

                // Повідомлення про успішне підключення
                Console.WriteLine("Пiдключення до бази [Список розсилки] завершено успішно");
                Console.ReadKey(); Console.Clear();

                await PRINT_MENU.Print(connection, new MENU_PART_ONE()); // меню з викликом запитів PART_ONE
                await PRINT_MENU.Print(connection, new MENU_PART_TWO()); // меню з викликом запитів PART_TWO
            }

            // Повідомлення про успішне відключення
            Console.WriteLine("Відключення від бази [Список розсилки] завершено успішно");
        }
        catch (Exception e) // якщо БД [Список розсилки] не вдалось створити
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("\nНе вдалося підключитися до бази даних [Список розсилки]");
        }
    }
}