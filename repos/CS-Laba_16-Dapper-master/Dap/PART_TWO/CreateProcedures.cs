using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

// Створення процедур
internal class CreateProcedures
{
    public static async Task Create(SqlConnection connection)
    {
        string query = ""; // для кодy запиту
        var command = new SqlCommand(query, connection); // для виконування команд

        // Створення процедури [CountBuyersInEachCity]
        // Відобразити кількість покупців у кожному місті
        try
        {
            query =
            @"
                CREATE PROCEDURE CountBuyersInEachCity
                AS
                BEGIN
                    SELECT COUNT(A.[ID покупця]) AS Count, B.[Назва міста] AS NameCity
                    FROM [Покупці] A, [Міста] B
                    WHERE A.[ID міста] = B.[ID міста] AND A.[ID країни] = B.[ID країни]
                    GROUP BY B.[Назва міста]
                END
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [CountBuyersInEachCity] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [CountBuyersInEachCountry]
        // Відобразити кількість покупців у кожній країні
        try
        {
            query =
            @"
                CREATE PROCEDURE CountBuyersInEachCountry
                AS
                BEGIN
                    SELECT COUNT(A.[ID покупця]) AS Count, B.[Назва країни] AS NameCountry
                    FROM [Покупці] A, [Країни] B
                    WHERE A.[ID Країни] = B.[ID Країни]
                    GROUP BY B.[Назва Країни]
                END
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [CountBuyersInEachCountry] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [CountCityInEachCountry]
        // Відобразити кількість міст у кожній країні
        try
        {
            query =
            @"
                CREATE PROCEDURE CountCityInEachCountry
                AS
                BEGIN
                    SELECT COUNT(A.[ID міста]) AS Count, B.[Назва країни] AS NameCountry
                    FROM [Міста] A, [Країни] B
                    WHERE A.[ID Країни] = B.[ID Країни]
                    GROUP BY B.[ID Країни],B.[Назва Країни]
                END
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [CountCityInEachCountry] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [AVGCountCityInAllCountry]
        // Відобразити середню кількість міст по всіх країнах
        try
        {
            query =
            @"
                CREATE PROCEDURE AVGCountCityInAllCountry
                @City INT OUTPUT,
                @Country INT OUTPUT
                AS
	                BEGIN
		                SELECT @City = COUNT([Міста].[ID міста]) FROM [Міста]
		                SELECT @Country = COUNT([Країни].[ID країни]) FROM [Країни]
	                END
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [AVGCountCityInAllCountry] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [AllSectionsOfInterest]
        // Відобразити всі розділи, у яких зацікавлені
        try
        {
            query =
            @"
                CREATE PROCEDURE AllSectionsOfInterest
                AS
                    SELECT A.[ID розділу] AS ID_Section, A.[Назва розділу] AS NameSection
                    FROM [Розділи товарів] A,[Зацікавлені розділи] B
                    WHERE A.[ID розділу] = B.[ID розділу]
                    GROUP BY A.[Назва розділу], A.[ID розділу]
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [AllSectionsOfInterest] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [SpecificBuyerInSpecificCountry]
        // Відобразити конкретного покупця конкретної країни
        try
        {
            query =
            @"
                CREATE PROCEDURE SpecificBuyerInSpecificCountry
                @Name NVARCHAR(50),
                @Country NVARCHAR(30)
                AS
                    SELECT  A.[ID покупця] AS [ID_Buyer],
                            A.ПІБ AS [Name],
                            A.[Дата народження] AS [Birthday],
                            A.Email AS [Email],
                            A.[ID країни] AS [ID_Country],
                            A.[ID міста] AS [ID_City]
                    FROM [Покупці] A, [Країни] B
                    WHERE A.[ID країни] = B.[ID країни] AND A.ПІБ LIKE ('%' + @Name + '%') AND B.[Назва країни] LIKE ('%' + @Country + '%')
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [SpecificBuyerInSpecificCountry] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [AllPromotionsSpecSectionInSpecPeriod]
        // Відобразити всі акції товару конкретного розділу за вказаний проміжок часу
        try
        {
            query =
            @"
                CREATE PROCEDURE AllPromotionsSpecSectionInSpecPeriod
                @Name NVARCHAR(100),
                @Start DATE,
                @End DATE
                AS
	                SELECT	A.[ID акції] AS [ID_Stock],
			                A.[Назва товару] AS [NameProduct],
			                A.[ID розділу] AS [ID_Section],
			                A.[Дата початку] AS [StartTime],
			                A.[Дата кінця] AS [EndTime]
	                FROM [Акційні товари] A
	                WHERE A.[Назва товару] LIKE ('%' + @Name + '%') AND
	                (A.[Дата початку] >= @Start AND A.[Дата кінця] <= @End)
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [AllPromotionsSpecSectionInSpecPeriod] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [AllPromotionsForSpecBuyer]
        // Відобразити всі акційні товари для конкретного покупця
        try
        {
            query =
            @"
                CREATE PROCEDURE AllPromotionsForSpecBuyer
                @Name NVARCHAR(50)
                AS
	                SELECT	A.[ID акції] AS [ID_Stock],
			                A.[Назва товару] AS [NameProduct],
			                A.[ID розділу] AS [ID_Section],
			                A.[Дата початку] AS [StartTime],
			                A.[Дата кінця] AS [EndTime]
	                FROM	[Акційні товари] A,
			                [Розділи_Товари] B,
			                [Розділи товарів] C, 
			                [Зацікавлені розділи] D, 
			                [Покупці] E
	                WHERE	A.[ID акції] = B.[ID акції] AND
			                B.[ID розділу] = C.[ID розділу] AND
			                C.[ID розділу] = D.[ID розділу] AND
			                D.[ID покупця] = E.[ID покупця] AND
			                E.ПІБ LIKE ('%' + @Name + '%')
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [AllPromotionsForSpecBuyer] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [TopThreeCountryByCountBuyers]
        // Відобразити топ-3 країн за кількістю покупців
        try
        {
            query =
            @"
                CREATE PROCEDURE TopThreeCountryByCountBuyers
                AS
                    SELECT TOP 3 A.[ID країни] AS ID_Country, B.[Назва країни] AS Name, COUNT(A.[ID країни]) AS NumCount
                    FROM [Покупці] A,[Країни] B
                    WHERE A.[ID країни] = B.[ID країни]
                    GROUP BY A.[ID країни],B.[Назва країни]
                    ORDER BY NumCount DESC
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [TopThreeCountryByCountBuyers] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [TopCountryByCountBuyers]
        // Показати найкращу країну за кількістю покупців
        try
        {
            query =
            @"
                CREATE PROCEDURE TopCountryByCountBuyers
                AS
                    SELECT TOP 1 A.[ID країни] AS ID_Country, B.[Назва країни] AS Name, COUNT(A.[ID країни]) AS NumCount
                    FROM [Покупці] A,[Країни] B
                    WHERE A.[ID країни] = B.[ID країни]
                    GROUP BY A.[ID країни],B.[Назва країни]
                    ORDER BY NumCount DESC
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [TopCountryByCountBuyers] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [TopThreeCitiesByCountBuyers]
        // Показати топ-3 міст за кількістю покупців
        try
        {
            query =
            @"
                CREATE PROCEDURE TopThreeCitiesByCountBuyers
                AS
                    SELECT TOP 3 B.[ID міста] AS ID_City, B.[Назва міста] AS Name, A.[ID країни] AS ID_Country, COUNT(A.[ID країни]) AS NumCount
                    FROM [Покупці] A, [Міста] B
                    WHERE A.[ID міста] = B.[ID міста] AND A.[ID країни] = B.[ID країни]
                    GROUP BY B.[Назва міста],B.[ID міста], A.[ID країни]
                    ORDER BY NumCount DESC
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [TopThreeCitiesByCountBuyers] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Створення процедури [TopCityByCountBuyers]
        // Показати найкраще місто за кількістю покупців
        try
        {
            query =
            @"
                CREATE PROCEDURE TopCityByCountBuyers
                AS
                    SELECT TOP 1 B.[ID міста] AS ID_City, B.[Назва міста] AS Name, A.[ID країни] AS ID_Country, COUNT(A.[ID країни]) AS NumCount
                    FROM [Покупці] A, [Міста] B
                    WHERE A.[ID міста] = B.[ID міста] AND A.[ID країни] = B.[ID країни]
                    GROUP BY B.[Назва міста],B.[ID міста], A.[ID країни]
                    ORDER BY NumCount DESC
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [TopCityByCountBuyers] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}