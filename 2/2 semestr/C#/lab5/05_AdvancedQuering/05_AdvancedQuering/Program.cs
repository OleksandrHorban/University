using BookShop.Entities;
using BookShop.Enums;
using BookShop.Data;
using BookShop.Console;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var connection = @"Server =(localdb)\MSSQLLocalDB; Database = BookShop_Database; Trusted_Connection=True; TrustServerCertificate=True;";

var options = new DbContextOptionsBuilder<BookShopContext>()
                 .UseSqlServer(new SqlConnection(connection))
                 .Options;

var context = new BookShopContext(options);

var repo = new BookShopRepository(context);

Console.WriteLine("Welcome to Book shop!");

Console.Write("Input number to start specific query (EXIT to close app): ");
string queryNumber = Console.ReadLine();

while (queryNumber is not "EXIT")
{
    switch (queryNumber)
    {
        case "1":

            Console.WriteLine();
            Console.Write("Age restriction (Minor, Teen, Adult): ");
            string input = Console.ReadLine();

            AgeRestriction ageRestriction = new AgeRestriction();
            switch (input)
            {
                case "Minor":
                    ageRestriction = AgeRestriction.Minor;
                    break;
                case "Teen":
                    ageRestriction = AgeRestriction.Teen;
                    break;
                case "Adult":
                    ageRestriction = AgeRestriction.Adult;
                    break;
                default:

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Wrong age restriction!");
                    Console.ResetColor();

                    break;
            }

            var result1 = await repo.GetBooksByAgeRestriction(ageRestriction);

            for (int i = 0; i < result1.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Title: {result1[i].Title}");
                Console.ResetColor();
            }

            break;

        case "2":

            var result2 = await repo.GetGoldenBooks();

            for (int i = 0; i < result2.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Title: {result2[i].Title}");
                Console.ResetColor();
            }

            break;

        case "3":

            var result3 = await repo.GetBooksByPrice();

            for (int i = 0; i < result3.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result3[i].Title} - {result3[i].Price}$");
                Console.ResetColor();
            }

            break;

        case "4":

            Console.WriteLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            var result4 = await repo.GetBooksNotReleasedIn(year);

            for (int i = 0; i < result4.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result4[i].Title}");
                Console.ResetColor();
            }

            break;

        case "5":

            //example: Fantasy, Science, Manga
            Console.WriteLine();
            Console.Write("Categories: ");
            string categories = Console.ReadLine();
            List<string> categoriesList = categories.Split(" ").ToList();

            var result5 = await repo.GetBooksByCategory(categoriesList);

            for (int i = 0; i < result5.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result5[i].Title}");
                Console.ResetColor();
            }

            break;

        case "6":

            Console.WriteLine();
            Console.Write("Date (xx-xx-xxxx): ");
            string date = Console.ReadLine();
            List<string> dateList = date.Split("-").ToList();

            var result6 = await repo.GetBooksReleasedBefore(Convert.ToInt32(dateList[0]),
                                                            Convert.ToInt32(dateList[1]),
                                                            Convert.ToInt32(dateList[2]));

            for (int i = 0; i < result6.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result6[i].Title} - {result6[i].EditionType} - {result6[i].Price}");
                Console.ResetColor();
            }

            break;

        case "7":

            Console.WriteLine();
            Console.Write("Author Firstname ends with (Firstname): ");
            string authorName = Console.ReadLine();
            var result7 = await repo.GetAuthorNamesEndingIn(authorName);

            for (int i = 0; i < result7.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result7[i]}");
                Console.ResetColor();
            }

            break;

        case "8":

            Console.WriteLine();
            Console.Write("Title name contains (Titlename): ");
            string titleName = Console.ReadLine();
            var result8 = await repo.GetBookTitlesContaining(titleName);

            for (int i = 0; i < result8.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result8[i]}");
                Console.ResetColor();
            }

            break;

        case "9":

            Console.WriteLine();
            Console.Write("Author Lastname starts with (Lastname): ");
            string lastname = Console.ReadLine();
            var result9 = await repo.GetBooksByAuthor(lastname);

            for (int i = 0; i < result9.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result9[i]}");
                Console.ResetColor();
            }

            break;

        case "10":

            Console.WriteLine();
            Console.Write("Length: ");
            string length = Console.ReadLine();
            var result10 = await repo.CountBooks(Convert.ToInt32(length));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"There are {result10} books with longer title than {length} symbols");
            Console.ResetColor();

            break;

        case "11":

            Console.WriteLine();
            var result11 = await repo.CountCopiesByAuthor();

            for (int i = 0; i < result11.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result11[i]}");
                Console.ResetColor();
            }

            break;

        case "12":

            Console.WriteLine();
            var result12 = await repo.GetTotalProfitByCategory();

            for (int i = 0; i < result12.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result12[i]}");
                Console.ResetColor();
            }

            break;

        case "13":

            Console.WriteLine();
            var result13 = await repo.GetMostRecentBooks();

            for (int i = 0; i < result13.Count; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result13[i]}");
                Console.ResetColor();
            }

            break;

        case "14":

            Console.WriteLine();
            await repo.IncreasePrices();

            Console.WriteLine("Done!");

            break;

        case "15":

            Console.WriteLine();
            var result15 = await repo.RemoveBooks();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"Books deleted: {result15}");
            Console.ResetColor();

            break;

        default:

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Wrong query number!");
            Console.ResetColor();

            break;
    }

    Console.WriteLine();
    Console.Write("Input number to start specific query (EXIT to close app): ");
    queryNumber = Console.ReadLine();
}
