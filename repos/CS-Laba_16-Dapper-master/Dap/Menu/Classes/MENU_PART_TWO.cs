using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class MENU_PART_TWO : IMenu
{
    public async Task Menu(SqlConnection connection)
    {
        // Cтворення процедур
        try
        {
            await CreateProcedures.Create(connection);
            Console.ReadKey(); Console.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            Console.Write("\nНатисніть для продовження...");
            Console.ReadKey(); Console.Clear();
        }

        while (true) // міні-менюшка
        {
            Console.WriteLine("\t\tPART TWO");
            Console.WriteLine("1 - Відобразити кількість покупців у кожному місті");
            Console.WriteLine("2 - Відобразити кількість покупців у кожній країні");
            Console.WriteLine("3 - Відобразити кількість міст у кожній країні");
            Console.WriteLine("4 - Відобразити середню кількість міст по всіх країнах");
            Console.WriteLine("5 - Відобразити всі розділи, у яких зацікавлені");
            Console.WriteLine("6 - Відобразити конкретного покупця конкретної країни");
            Console.WriteLine("7 - Відобразити всі акції товару конкретного розділу за вказаний проміжок часу");
            Console.WriteLine("8 - Відобразити всі акційні товари для конкретного покупця");
            Console.WriteLine("9 - Відобразити топ-3 країн за кількістю покупців");
            Console.WriteLine("10 - Показати найкращу країну за кількістю покупців");
            Console.WriteLine("11 - Показати топ-3 міст за кількістю покупців");
            Console.WriteLine("12 - Показати найкраще місто за кількістю покупців");
            Console.Write("Exit - Відключення від БД\n > ");

            switch (Console.ReadLine()?.ToLower().Trim())
            {
                case ("1"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintCountBuyersInEachCity(), connection);
                    break;
                case ("2"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintCountBuyersInEachCountry(), connection);
                    break;
                case ("3"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintCountCityInEachCountry(),connection);
                    break;
                case ("4"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintAVGCountCityInAllCountry(), connection);
                    break;
                case ("5"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintAllSectionsOfInterest(),connection);
                    break;
                case ("6"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintSpecificBuyerInSpecificCountry(), connection);
                    break;
                case ("7"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintAllPromotionsSpecSectionInSpecPeriod(),connection);
                    break;
                case ("8"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintAllPromotionsForSpecBuyer(),connection);
                    break;
                case ("9"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintTopThreeCountryByCountBuyers(),connection);
                    break;
                case ("10"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintTopCountryByCountBuyers(), connection);
                    break;
                case ("11"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintTopThreeCitiesByCountBuyers(), connection);
                    break;
                case ("12"):
                    Console.WriteLine();
                    await PRINT_QUERIES.Print(new PrintTopCityByCountBuyers(), connection);
                    break;
                case ("exit"):
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    return;
                default:
                    Console.Write("\nВведено некоректне значення...");
                    break;
            }

            Console.ReadKey(); // щоб можна було продивитись результат команди
            Console.Clear(); // очищення консолі
        }
    }
}