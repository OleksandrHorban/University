using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

internal class CREATE
{
    public static async Task Create()
    {
        // Строка підключення
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";

        // using для автоматичного закриття підключення
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync(); // асинхронно відкривається підключення

            var command = new SqlCommand() { Connection = connection }; // для виконування команд

            try
            {
                command.CommandText = // створення БД
                    "CREATE DATABASE [Список розсилки] ";
                await command.ExecuteNonQueryAsync(); // асинхронне виконування команди

                Console.WriteLine("Базу даних [Список розсилки] створено успішно");
            }
            catch (SqlException e) // якщо створення БД не получилось
            {
                Console.WriteLine(e.Message);

                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }

            // строка підключення змінюється на новостворену базу данних
            connectionString = "Server=(localdb)\\mssqllocaldb;Database=Список розсилки;Trusted_Connection=True;";
        }

        try // якщо БД [Список розсилки] вдалось створити
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync(); // асинхронно відкривається нове підключення

                var command = new SqlCommand() { Connection = connection };

                // Створення таблиць
                {
                    // Створення таблиці [Країни]
                    try
                    {
                        command.CommandText =
                            "CREATE TABLE [Країни] " +
                            "( " +
                            "   [ID країни] INT IDENTITY(10000,1), " +
                            "   [Назва країни] NVARCHAR(30) UNIQUE NOT NULL, " +
                            " " +
                            "   PRIMARY KEY ([ID країни]) " +
                            ")";
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Країни] створено успішно");
                    }
                    catch (SqlException e) // якщо створення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Створення таблиці [Міста]
                    try
                    {
                        command.CommandText =
                            "CREATE TABLE [Міста] " +
                            "( " +
                            "   [ID міста] INT IDENTITY(10000,1), " +
                            "   [Назва міста] NVARCHAR(30) UNIQUE NOT NULL, " +
                            "   [ID країни] INT NOT NULL, " +
                            " " +
                            "   PRIMARY KEY ([ID міста]), " +
                            "   CONSTRAINT FK_Міста_To_Країни FOREIGN KEY([ID країни]) REFERENCES [Країни] ([ID країни]) ON DELETE CASCADE " +
                            ")";
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Міста] створено успішно");
                    }
                    catch (SqlException e) // якщо створення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Створення таблиці [Покупці]
                    try
                    {
                        command.CommandText =
                            "CREATE TABLE [Покупці] " +
                            "( " +
                            "   [ID покупця] INT IDENTITY(10000,1), " +
                            "   [ПІБ] NVARCHAR(50) NOT NULL, " +
                            "   [Дата народження] DATE NOT NULL, " +
                            "   [Email] NVARCHAR(50) UNIQUE NOT NULL, " +
                            "   [ID країни] INT NOT NULL, " +
                            "   [ID міста] INT, " +
                            " " +
                            "   PRIMARY KEY ([ID покупця]), " +
                            "   CONSTRAINT FK_Покупці_To_Міста FOREIGN KEY([ID міста]) REFERENCES [Міста] ([ID міста]) ON DELETE CASCADE, " +
                            "   CONSTRAINT FK_Покупці_To_Країни FOREIGN KEY([ID країни]) REFERENCES [Країни] ([ID країни]) ON DELETE NO ACTION " +
                            ")";
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Покупці] створено успішно");
                    }
                    catch (SqlException e) // якщо створення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Створення таблиці [Розділи товарів]
                    try
                    {
                        command.CommandText =
                            "CREATE TABLE [Розділи товарів] " +
                            "( " +
                            "   [ID розділу] INT IDENTITY(10000,1), " +
                            "   [Назва розділу] NVARCHAR(50) UNIQUE NOT NULL, " +
                            " " +
                            "   PRIMARY KEY ([ID розділу]), " +
                            ")";
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Розділи товарів] створено успішно");
                    }
                    catch (SqlException e) // якщо створення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Створення таблиці [Акційні товари]
                    try
                    {
                        command.CommandText =
                            "CREATE TABLE [Акційні товари] " +
                            "( " +
                            "   [ID акції] INT IDENTITY(10000,1), " +
                            "   [Назва товару] NVARCHAR(100) UNIQUE NOT NULL, " +
                            "   [ID розділу] INT NOT NULL, " +
                            "   [Дата початку] DATE NOT NULL, " +
                            "   [Дата кінця] DATE NOT NULL, " +
                            " " +
                            "   PRIMARY KEY ([ID акції]) " +
                            ")";
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Акційні товари] створено успішно");
                    }
                    catch (SqlException e) // якщо створення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Створення таблиці [Зацікавлені розділи]
                    try
                    {
                        command.CommandText =
                            "CREATE TABLE [Зацікавлені розділи] " +
                            "( " +
                            "   [ID покупця] INT NOT NULL, " +
                            "   [ID розділу] INT NOT NULL, " +
                            " " +
                            "   PRIMARY KEY ([ID покупця],[ID розділу]), " +
                            "   CONSTRAINT FK_Зацікавлені_розділи_To_Покупці FOREIGN KEY([ID покупця]) REFERENCES [Покупці] ([ID покупця]) ON DELETE CASCADE, " +
                            "   CONSTRAINT FK_Зацікавлені_розділи_To_Розділи FOREIGN KEY([ID розділу]) REFERENCES [Розділи товарів] ([ID розділу]) ON DELETE CASCADE " +
                            ")";
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Зацікавлені розділи] створено успішно");
                    }
                    catch (SqlException e) // якщо створення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Створення таблиці [Розділи_Товари]
                    try
                    {
                        command.CommandText =
                            "CREATE TABLE [Розділи_Товари] " +
                            "( " +
                            "   [ID розділу] INT NOT NULL, " +
                            "   [ID акції] INT NOT NULL, " +
                            " " +
                            "   PRIMARY KEY ([ID розділу],[ID акції]), " +
                            "   CONSTRAINT FK_Розділи_Товари_To_Розділи FOREIGN KEY([ID розділу]) REFERENCES [Розділи товарів] ([ID розділу]) ON DELETE CASCADE, " +
                            "   CONSTRAINT FK_Розділи_Товари_To_Товари FOREIGN KEY([ID акції]) REFERENCES [Акційні товари] ([ID акції]) ON DELETE CASCADE " +
                            ")";
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Розділи_Товари] створено успішно");
                    }
                    catch (SqlException e) // якщо створення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Створення таблиці [Акції_Країни]
                    try
                    {
                        command.CommandText =
                            "CREATE TABLE [Акції_Країни] " +
                            "( " +
                            "   [ID країни] INT NOT NULL, " +
                            "   [ID акції] INT NOT NULL, " +
                            " " +
                            "   PRIMARY KEY ([ID країни],[ID акції]), " +
                            "   CONSTRAINT FK_Акції_Країни_To_Країни FOREIGN KEY([ID країни]) REFERENCES [Країни] ([ID країни]) ON DELETE CASCADE, " +
                            "   CONSTRAINT FK_Акції_Країни_To_Акції FOREIGN KEY([ID акції]) REFERENCES [Акційні товари] ([ID акції]) ON DELETE CASCADE " +
                            ")";
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Акції_Країни] створено успішно");
                    }
                    catch (SqlException e) // якщо створення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }
                }

                // Заповнення таблиць
                {
                    // Заповнення таблиці [Країни]
                    try
                    {
                        command.CommandText = // заповнення таблиці [Менеджери]
                           "INSERT INTO [Країни] " +
                           "   VALUES   (N'Україна')," +
                           "            (N'Польша')," +
                           "            (N'Латвія')," +
                           "            (N'Литва')," +
                           "            (N'Данія')," +
                           "            (N'США')," +
                           "            (N'Німеччина')," +
                           "            (N'Франція')," +
                           "            (N'Іспанія')," +
                           "            (N'Австрія')," +
                           "            (N'Словаччина')," +
                           "            (N'Канада')," +
                           "            (N'Казахстан')," +
                           "            (N'Китай')," +
                           "            (N'Японія')," +
                           "            (N'Південна Корея')," +
                           "            (N'Індія')," +
                           "            (N'Бразилія')," +
                           "            (N'Швеція')," +
                           "            (N'Норвегія')," +
                           "            (N'Ісландія')," +
                           "            (N'Нова Зеландія')," +
                           "            (N'Австралія')," +
                           "            (N'Португалія');";
                        /*
                        command.CommandText =
                            "INSERT INTO [Країни] VALUES (N'')";
                         */
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Країни] заповненo успішно");
                    }
                    catch (SqlException e) // якщо заповнення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Заповнення таблиці [Міста]
                    try
                    {
                        command.CommandText =
                           "INSERT INTO [Міста] " +
                           "   VALUES   (N'Сідней',             10022)," +
                           "            (N'Мельбурн',           10022)," +
                           "            (N'Брисбен',            10022)," +
                           "            (N'Вена',               10009)," +
                           "            (N'Зальцбург',          10009)," +
                           "            (N'Лінц',               10009)," +
                           "            (N'Грац',               10009)," +
                           "            (N'Вельс',              10009)," +
                           "            (N'Бразиліа',           10017)," +
                           "            (N'Ріо-де-Жанейро',     10017)," +
                           "            (N'Сан-Паулу',          10017)," +
                           "            (N'Сан-Ліус',           10017)," +
                           "            (N'Копенгаген',         10004)," +
                           "            (N'Орхус',              10004)," +
                           "            (N'Гернінг',            10004)," +
                           "            (N'Мумбаї',             10016)," +
                           "            (N'Пуне',               10016)," +
                           "            (N'Джайпур',            10016)," +
                           "            (N'Рейк`явік',          10020)," +
                           "            (N'Коупавоґур',         10020)," +
                           "            (N'Гапнарфйордур',      10020)," +
                           "            (N'Мадрид',             10008)," +
                           "            (N'Барселона',          10008)," +
                           "            (N'Гранада',            10008)," +
                           "            (N'Державінськ',        10012)," +
                           "            (N'Сарань',             10012)," +
                           "            (N'Хромтау',            10012)," +
                           "            (N'Торонто',            10011)," +
                           "            (N'Оттава',             10011)," +
                           "            (N'Монреаль',           10011)," +
                           "            (N'Пекін',              10013)," +
                           "            (N'Шанхай',             10013)," +
                           "            (N'Гонконг',            10013)," +
                           "            (N'Рига',               10002)," +
                           "            (N'Валмієра',           10002)," +
                           "            (N'Резекне',            10002)," +
                           "            (N'Вільнюс',            10003)," +
                           "            (N'Каунас',             10003)," +
                           "            (N'Клайпеда',           10003)," +
                           "            (N'Берлін',             10006)," +
                           "            (N'Гамбург',            10006)," +
                           "            (N'Вільгельмсгафен',    10006)," +
                           "            (N'Окленд',             10021)," +
                           "            (N'Даргавілл',          10021)," +
                           "            (N'Нельсон',            10021)," +
                           "            (N'Осло',               10019)," +
                           "            (N'Олесун',             10019)," +
                           "            (N'Берген',             10019)," +
                           "            (N'Сеул',               10015)," +
                           "            (N'Бусан',              10015)," +
                           "            (N'Інчон',              10015)," +
                           "            (N'Варшава',            10001)," +
                           "            (N'Краков',             10001)," +
                           "            (N'Лодзь',              10001)," +
                           "            (N'Ліссабон',           10023)," +
                           "            (N'Порту',              10023)," +
                           "            (N'Фаро',               10023)," +
                           "            (N'Братислава',         10010)," +
                           "            (N'Кошице',             10010)," +
                           "            (N'Тренчин',            10010)," +
                           "            (N'Нью-Йорк',           10005)," +
                           "            (N'Сан-Франциско',      10005)," +
                           "            (N'Лос-Анджелес',       10005)," +
                           "            (N'Київ',               10000)," +
                           "            (N'Бахмут',             10000)," +
                           "            (N'Херсон',             10000)," +
                           "            (N'Марсель',            10007)," +
                           "            (N'Ліон',               10007)," +
                           "            (N'Тулуза',             10007)," +
                           "            (N'Стокгольм',          10018)," +
                           "            (N'Ґетерборг',          10018)," +
                           "            (N'Умео',               10018)," +
                           "            (N'Токіо',              10014)," +
                           "            (N'Кіото',              10014)," +
			               "            (N'Хіросима',           10014);";
                        /*
                        command.CommandText =
                            "INSERT INTO [Міста] VALUES (N'',10000)";
                         */
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Міста] заповненo успішно");
                    }
                    catch (SqlException e) // якщо заповнення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Заповнення таблиці [Покупці]
                    try
                    {
                        command.CommandText =
                           "INSERT INTO [Покупці] " +
                           "   VALUES   (N'Андронік Веніамін Ігорович',         '04.04.2000', 'exempl1@gmail.com',                  10023,  10056)," +
                           "            (N'Босак Максим Олександрович',         '12.22.1968', 'exempl2@gmail.com',                  10022,  10002)," +
                           "            (N'Грицюк Олександра Олегівна',         '11.08.2000', 'exempl3@gmail.com',                  10021,  10044)," +
                           "            (N'Іонуца Віктор Вікторович',           '04.13.2001', 'exempl4@gmail.com',                  10020,  10018)," +
                           "            (N'Крупчак Анастасія Володимирівна',    '04.04.1955', 'exempl5@gmail.com',                  10019,  10046)," +
                           "            (N'Кульчицький Андрій Сергійович',      '10.24.1988', 'exempl6@gmail.com',                  10018,  10071)," +
                           "            (N'Макогон Роман Павлович',             '10.29.1975', 'exempl7@gmail.com',                  10017,  10008)," +
                           "            (N'Мачик Назарій Анатолійович',         '12.18.2003', 'exempl8@gmail.com',                  10016,  10016)," +
                           "            (N'Мельничук Анна Геннадіївна',         '03.25.1987', 'exempl9@gmail.com',                  10015,  10050)," +
                           "            (N'Милостива Анна Олександрівна',       '06.19.2002', 'exempl10@gmail.com',                 10014,  10074)," +
                           "            (N'Минзат Валентин Володимирович',      '04.28.1981', 'exempl11@gmail.com',                 10013,  10031)," +
                           "            (N'Мулик Андрій Васильович',            '10.03.2000', 'exempl12@gmail.com',                 10012,  10026)," +
                           "            (N'Нємцов Євген Андрійович',            '11.18.1972', 'exempl13@gmail.com',                 10011,  10029)," +
                           "            (N'Сташко Іванна Іванівна',             '11.24.1998', 'exempl14@gmail.com',                 10010,  10059)," +
                           "            (N'Ткач Євгеній Анатолійович',          '08.25.1966', 'exempl15@gmail.com',                 10009,  10006)," +
                           "            (N'Федько Дмитро Михайлович',           '08.07.2001', 'exempl16@gmail.com',                 10008,  10023)," +
                           "            (N'Яким`юк Вікторія Миколаївна',        '04.24.1983', 'exempl17@gmail.com',                 10007,  10066)," +
                           "            (N'Горобчик Максим Васильович',         '10.16.2002', 'exempl18@gmail.com',                 10006,  10039)," +
                           "            (N'Зварко Вікторія Станіславівна',      '09.12.1955', 'exempl19@gmail.com',                 10005,  10061)," +
                           "            (N'Ярмолюк Ілля Віталійович',           '07.08.2003', 'exempl20@gmail.com',                 10004,  10013)," +
                           "            (N'Арнаутов Кирил Анатолійович',        '06.23.1988', 'exempl21@gmail.com',                 10003,  10037)," +
                           "            (N'Колчанова Тетяна Олександрівна',     '11.17.1994', 'exempl22@gmail.com',                 10002,  10034)," +
                           "            (N'Веркаш Віталій Юрійович',            '11.13.1998', 'exempl23@gmail.com',                 10001,  10051)," +
                           "            (N'Сиримак Марина Миколаївна',          '02.06.1961', 'exempl24@gmail.com',                 10000,  10065)," +
                           "            (N'Шевчук Тетяна Борисівна',            '05.24.1977', 'fmikituk@pickuplanet.com',           10001,  10065)," +
                           "            (N'Броварчук Данило Олексійович',       '07.02.1985', 'vitalij.antonen@kenvanharen.com',    10002,  10065)," +
                           "            (N'Середа Ілля Євгенович',              '08.18.1989', 'anton.dmitrenko@bengkoan.ninja',     10003,  10065)," +
                           "            (N'Васильчук Віталій Федорович',        '11.11.1997', 'zaharcuk.baleri@freeallapp.com',     10004,  10065)," +
                           "            (N'Василенко Олена Євгенівна',          '08.28.1972', 'vira.kramarcuk@54.mk',               10005,  10065)," +
                           "            (N'Таращук Наташа Андріївна',           '02.13.1965', 'artur98@24hinbox.com',               10009,  10065)," +
                           "            (N'Ніна Шевчук Борисівна',              '01.01.1983', 'aponomarenko@mailsupply.net',        10007,  10065)," +
                           "            (N'Васильчук Bіктор Олександрович',     '05.14.1997', 'brovarcuk.roman@iniprm.com',         10007,  10066)," +
                           "            (N'Крамарчук Раїса Янівна',             '02.17.1964', 'valentin.brovar@onlinecmail.com',    10009,  10065)," +
                           "            (N'Мірошниченко Андрій Євгенійович',    '01.21.1978', 'olena03@yt-google.com',              10010,  10065)," +
                           "            (N'Броварчук Данил Михайлович',         '08.07.1972', 'melnicenko.aros@dailyladylog.com',   10015,  10050)," +
                           "            (N'Боднаренко Віра Сергіївна',          '10.09.1996', 'margarita61@crossfitcoastal.com',    10016,  10016)," +
                           "            (N'Кравчук Bалерій Тарасович',          '12.25.2002', 'xzaharcuk@kurma-rasulullah.store',   10013,  10065)," +
                           "            (N'Гнатюк Валерія Євгенівна',           '09.16.2001', 'sevcuk.oksana@email-temp.com',       10022,  10002)," +
                           "            (N'Петренко Марина Олександрівна',      '01.28.1984', 'sinkarenko.lev@hongsaitu.com',       10015,  10065)," +
                           "            (N'Задорожна Марія Олександрівна',      '05.20.2001', 'exempl25@gmail.com',                 10021,  10044);";
                        /*
                        command.CommandText =
                            "INSERT INTO [Покупці] VALUES (N'','mm.dd.yyyy','@',10000,10000)";
                         */
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Покупці] заповненo успішно");
                    }
                    catch (SqlException e) // якщо заповнення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Заповнення таблиці [Розділи товарів]
                    try
                    {
                        command.CommandText =
                           "INSERT INTO [Розділи товарів] " +
                           "   VALUES   (N'Ноутбуки та комп`ютери')," +
                           "            (N'Смартфони, ТВ і електроніка')," +
                           "            (N'Товари для геймерів')," +
                           "            (N'Товари для дому')," +
                           "            (N'Інструменти та автотовари')," +
                           "            (N'Сантехніка та ремонт')," +
                           "            (N'Дача, сад і город')," +
                           "            (N'Спорт і захоплення')," +
                           "            (N'Одяг, взуття та прикраси')," +
                           "            (N'Краса та здоров`я')," +
                           "            (N'Дитячі товари')," +
                           "            (N'Зоотовари')," +
                           "            (N'Офіс, школа, книги')," +
                           "            (N'Алкогольні напої та продукти')," +
                           "            (N'Товари для бізнесу та послуги');";
                        /*
                        command.CommandText =
                            "INSERT INTO [Розділи товарів] VALUES (N'')";
                         */
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Розділи товарів] заповненo успішно");
                    }
                    catch (SqlException e) // якщо заповнення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Заповнення таблиці [Акційні товари]
                    try
                    {
                        command.CommandText =
                           "INSERT INTO [Акційні товари] " +
                           "    VALUES  (N'Ноутбук Acer Aspire 7 A715-42G-R8BL (NH.QDLEU.008) Charcoal Black',           10000,'01.04.2022','01.24.2022')," +
                           "            (N'Ноутбук ASUS TUF Gaming F15 FX506LH-HN236 (90NR03U2-M006F0) Bonfire Black',   10000,'10.16.2022','11.30.2022')," +
                           "            (N'Ноутбук Lenovo IdeaPad 3 15ALC6 (82KU01C4RA) Arctic Grey',                    10000,'03.22.2022','04.30.2022')," +
                           "            (N'Мобільний телефон Samsung Galaxy M32 6/128 GB Light Blue (SM-M325FLBGSEK)',   10001,'06.27.2022','02.25.2022')," +
                           "            (N'Телевізор Samsung UE50AU7100UXUA',                                            10001,'01.19.2022','08.01.2022')," +
                           "            (N'Навушники Defunc True Music TWS Black (D4271M)',                              10001,'12.14.2022','01.15.2023')," +
                           "            (N'Ігрова приставка PS5 PlayStation 5 (PS5/RAT/SACK)',                           10002,'06.08.2022','07.30.2022')," +
                           "            (N'Клавіатура дротова Hator Starfall Outemu Red (HTK-608)',                      10002,'11.24.2022','12.15.2022')," +
                           "            (N'Бездротовий геймпад PlayStation Dualshock 4 v2 Black для PS4',                10002,'10.24.2022','11.14.2022')," +
                           "            (N'Конвектор RZTK CVT 2520HP',                                                   10003,'06.06.2022','07.13.2022')," +
                           "            (N'Холодильник BOSCH KGN39VL316',                                                10003,'06.02.2022','08.28.2022')," +
                           "            (N'Мікрохвильова піч Candy CMW20TNMB',                                           10003,'08.18.2022','09.01.2022')," +
                           "            (N'Тюль на грек-сітці Декор-Ін Флора Градієнт 400х260 Сірий (ROZ6400068415)',    10004,'10.14.2022','12.24.2022')," +
                           "            (N'Сковорода Tefal Simply Clean 12 см (B5670053)',                               10004,'11.28.2022','12.17.2022')," +
                           "            (N'Камінокомплект ArtiFlame Colorado HC-23 Б`янко Білий (COLORADO HC-23 WB)',    10004,'09.05.2022','10.05.2022')," +
                           "            (N'Відеореєстратор Aspiring MAXI 4 SPEEDCAM, WIFI, GPS, 4K (MA1050WSPC)',        10005,'07.11.2022','07.30.2022')," +
                           "            (N'Автомобільний акумулятор Bosch 60Ah Єв (-/+) S4005 (540EN) (0 092 S40 050)',  10005,'11.10.2022','12.10.2022')," +
                           "            (N'Моторна олива Mobil 1 ESP 5W-30 4 л',                                         10005,'05.04.2022','06.04.2022')," +
                           "            (N'Ванна акрилова CERSANIT VIRGO 170',                                           10006,'08.17.2022','09.17.2022')," +
                           "            (N'Душовий гарнітур STEINBERG Serie 199 1991600',                                10006,'11.09.2022','11.29.2022')," +
                           "            (N'Радіатор сталевий Roda 22 R 500 x 1000 бічний',                               10006,'07.03.2022','07.13.2022')," +
                           "            (N'Повітродувка RZTK BL 600E',                                                   10007,'02.27.2022','04.27.2022')," +
                           "            (N'Обприскувач акумуляторний RZTK 16A',                                          10007,'10.15.2022','11.10.2022')," +
                           "            (N'Шланг Verto Профі садовий 20 м 3/4 (15G823)',                                 10007,'10.12.2022','11.05.2022')," +
                           "            (N'Електросамокат Segway Ninebot F40E Black (AA.00.0010.78)',                    10008,'11.28.2022','12.07.2022')," +
                           "            (N'Велосипед CORRADO Piemont DB 26 21 2019 Біло-синій (0307-С-21)',              10008,'08.15.2022','08.30.2022')," +
                           "            (N'Бігова доріжка EnergyFIT EF-JC',                                              10008,'05.18.2022','08.18.2022')," +
                           "            (N'Пуховик Under Armour UA CGI Down Jkt 1375442-100 L Білий (195253568114)',     10009,'12.03.2022','12.30.2022')," +
                           "            (N'Черевики Prime Shoes 16-659-30110 45 29.5 см Чорні (2000000164830)',          10009,'12.16.2022','12.30.2022')," +
                           "            (N'Комплект термобілизни Rough Radical Rock S Чорний із синім швом',             10009,'11.23.2022','12.23.2022')," +
                           "            (N'Крем для обличчя Doliva (Olivenol) інтенсив Light 50 мл (4016369527696)',     10010,'03.18.2022','03.28.2022')," +
                           "            (N'Тональний крем Enough Collagen Moisture Foundation SPF 15 #21 100 мл',        10010,'07.15.2022','08.15.2022')," +
                           "            (N'Туалетна вода для жінок Dolce & Gabbana L`Imperatrice 100 мл',                10010,'01.08.2022','03.08.2022')," +
                           "            (N'Лялька Barbie Cutie Reveal Милий кролик (HHG19)',                             10011,'05.20.2022','07.20.2022')," +
                           "            (N'Конструктор LEGO DOTS Додаткові елементи DOTS – випуск 4 105 деталей',        10011,'11.15.2022','12.15.2022')," +
                           "            (N'Гра настільна Hasbro Монополія Бонуси без кордонів - українська версія',      10011,'10.13.2022','11.13.2022')," +
                           "            (N'Сухий корм для котів Purina Pro Plan Original Adult 1+ з куркою 1.5 кг',      10012,'07.18.2022','09.18.2022')," +
                           "            (N'Сухий корм для собак Purina Pro Plan Dog Large Adult Robust з куркою 14 кг',  10012,'04.05.2022','06.05.2022')," +
                           "            (N'Корм для середніх папуг Versele-Laga Prestige Cockatiels зернова суміш 1 кг', 10012,'12.12.2022','12.30.2022')," +
                           "            (N'Рюкзак каркасний Kite для дівчинки 35x26x13.5 см 12 л Studio Pets',           10013,'11.28.2022','12.28.2022')," +
                           "            (N'Словник для запису іноземних слів Kite 48 аркушів',                           10013,'08.26.2022','09.26.2022')," +
                           "            (N'Спеціальний промисловий лак-маркер Edding Industry Paint 8750 2-4 мм Білий',  10013,'02.20.2022','04.20.2022')," +
                           "            (N'Віскі Bushmills Original 6 років витримки 1 л 40%',                           10014,'03.05.2022','07.05.2022')," +
                           "            (N'Вино Hommage Et Memoire червоне сухе 0.75 л 13%',                             10014,'11.22.2022','12.22.2022')," +
                           "            (N'Упаковка пива Corona Extra світле фільтроване 4.5% 0.355 л x 6 шт.',          10014,'12.02.2022','12.12.2022');";
                        /*
                        command.CommandText =
                            "INSERT INTO [Акційні товари] VALUES (N'',10000,'mm.dd.yyyy','dd.mm.yyyy')";
                         */
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Акційні товари] заповненo успішно");
                    }
                    catch (SqlException e) // якщо заповнення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Заповнення таблиці [Зацікавлені розділи]
                    try
                    {
                        command.CommandText =
                           "INSERT INTO [Зацікавлені розділи] " +
                           "    VALUES  (10000,10004), " +
                           "            (10000,10011), " +
                           "            (10000,10008), " +
                           "            (10001,10014), " +
                           "            (10001,10011), " +
                           "            (10001,10013), " +
                           "            (10002,10001), " +
                           "            (10002,10000), " +
                           "            (10002,10008), " +
                           "            (10003,10009), " +
                           "            (10003,10005), " +
                           "            (10003,10011), " +
                           "            (10004,10013), " +
                           "            (10004,10010), " +
                           "            (10004,10009), " +
                           "            (10005,10004), " +
                           "            (10005,10013), " +
                           "            (10005,10010), " +
                           "            (10006,10003), " +
                           "            (10006,10009), " +
                           "            (10006,10004), " +
                           "            (10007,10014), " +
                           "            (10007,10011), " +
                           "            (10007,10013), " +
                           "            (10008,10014), " +
                           "            (10008,10008), " +
                           "            (10008,10011), " +
                           "            (10009,10009), " +
                           "            (10009,10010), " +
                           "            (10009,10007), " +
                           "            (10010,10009), " +
                           "            (10010,10006), " +
                           "            (10010,10002), " +
                           "            (10011,10008), " +
                           "            (10011,10007), " +
                           "            (10011,10010), " +
                           "            (10012,10005), " +
                           "            (10012,10010), " +
                           "            (10012,10012), " +
                           "            (10013,10007), " +
                           "            (10013,10009), " +
                           "            (10013,10010), " +
                           "            (10014,10012), " +
                           "            (10014,10007), " +
                           "            (10014,10009), " +
                           "            (10015,10004), " +
                           "            (10015,10000), " +
                           "            (10015,10009), " +
                           "            (10016,10011), " +
                           "            (10016,10008), " +
                           "            (10016,10007), " +
                           "            (10017,10014), " +
                           "            (10017,10008), " +
                           "            (10017,10000), " +
                           "            (10018,10003), " +
                           "            (10018,10004), " +
                           "            (10018,10014), " +
                           "            (10019,10008), " +
                           "            (10019,10000), " +
                           "            (10019,10001), " +
                           "            (10020,10008), " +
                           "            (10020,10010), " +
                           "            (10020,10011), " +
                           "            (10021,10007), " +
                           "            (10021,10008), " +
                           "            (10021,10001), " +
                           "            (10022,10000), " +
                           "            (10022,10010), " +
                           "            (10022,10011), " +
                           "            (10023,10007), " +
                           "            (10023,10009), " +
                           "            (10023,10004), " +
                           "            (10024,10003), " +
                           "            (10024,10008), " +
                           "            (10024,10004);";
                        /*
                        command.CommandText =
                            "INSERT INTO [Зацікавлені розділи] VALUES (10000,10000)";
                         */
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Зацікавлені розділи] заповненo успішно");
                    }
                    catch (SqlException e) // якщо заповнення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Заповнення таблиці [Розділи_Товари]
                    try
                    {
                        command.CommandText =
                           "INSERT INTO [Розділи_Товари] " +
                           "    VALUES  (10000,10044), " +
                           "            (10000,10043), " +
                           "            (10000,10042), " +
                           "            (10000,10041), " +
                           "            (10000,10040), " +
                           "            (10001,10039), " +
                           "            (10001,10038), " +
                           "            (10001,10037), " +
                           "            (10001,10036), " +
                           "            (10001,10035), " +
                           "            (10002,10034), " +
                           "            (10002,10033), " +
                           "            (10002,10032), " +
                           "            (10002,10031), " +
                           "            (10002,10030), " +
                           "            (10003,10029), " +
                           "            (10003,10028), " +
                           "            (10003,10027), " +
                           "            (10003,10026), " +
                           "            (10003,10025), " +
                           "            (10004,10024), " +
                           "            (10004,10023), " +
                           "            (10004,10022), " +
                           "            (10004,10021), " +
                           "            (10004,10020), " +
                           "            (10005,10019), " +
                           "            (10005,10018), " +
                           "            (10005,10017), " +
                           "            (10005,10016), " +
                           "            (10005,10015), " +
                           "            (10006,10014), " +
                           "            (10006,10013), " +
                           "            (10006,10012), " +
                           "            (10006,10011), " +
                           "            (10006,10010), " +
                           "            (10007,10009), " +
                           "            (10007,10008), " +
                           "            (10007,10007), " +
                           "            (10007,10006), " +
                           "            (10007,10005), " +
                           "            (10008,10004), " +
                           "            (10008,10003), " +
                           "            (10008,10002), " +
                           "            (10008,10001), " +
                           "            (10008,10000), " +
                           "            (10009,10001), " +
                           "            (10009,10002), " +
                           "            (10009,10003), " +
                           "            (10009,10004), " +
                           "            (10009,10005), " +
                           "            (10010,10006), " +
                           "            (10010,10007), " +
                           "            (10010,10008), " +
                           "            (10010,10009), " +
                           "            (10010,10010), " +
                           "            (10011,10011), " +
                           "            (10011,10012), " +
                           "            (10011,10013), " +
                           "            (10011,10014), " +
                           "            (10011,10015), " +
                           "            (10012,10016), " +
                           "            (10012,10017), " +
                           "            (10012,10018), " +
                           "            (10012,10019), " +
                           "            (10012,10020), " +
                           "            (10013,10021), " +
                           "            (10013,10022), " +
                           "            (10013,10023), " +
                           "            (10013,10024), " +
                           "            (10013,10025), " +
                           "            (10014,10026), " +
                           "            (10014,10027), " +
                           "            (10014,10028), " +
                           "            (10014,10029), " +
                           "            (10014,10030);";
                        /*
                        command.CommandText =
                            "INSERT INTO [Розділи_Товари] VALUES (10000,10000)";
                         */
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Розділи_Товари] заповненo успішно");
                    }
                    catch (SqlException e) // якщо заповнення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }

                    // Заповнення таблиці [Акції_Країни]
                    try
                    {
                        command.CommandText =
                           "INSERT INTO [Акції_Країни] " +
                           "    VALUES  (10023,10044), " +
                           "            (10023,10043), " +
                           "            (10023,10042), " +
                           "            (10022,10041), " +
                           "            (10022,10040), " +
                           "            (10022,10039), " +
                           "            (10021,10038), " +
                           "            (10021,10037), " +
                           "            (10021,10036), " +
                           "            (10020,10035), " +
                           "            (10020,10034), " +
                           "            (10020,10033), " +
                           "            (10019,10032), " +
                           "            (10019,10031), " +
                           "            (10019,10030), " +
                           "            (10018,10029), " +
                           "            (10018,10028), " +
                           "            (10018,10027), " +
                           "            (10017,10026), " +
                           "            (10017,10025), " +
                           "            (10017,10024), " +
                           "            (10016,10023), " +
                           "            (10016,10022), " +
                           "            (10016,10021), " +
                           "            (10015,10020), " +
                           "            (10015,10019), " +
                           "            (10015,10018), " +
                           "            (10014,10017), " +
                           "            (10014,10016), " +
                           "            (10014,10015), " +
                           "            (10013,10014), " +
                           "            (10013,10013), " +
                           "            (10013,10012), " +
                           "            (10012,10011), " +
                           "            (10012,10010), " +
                           "            (10012,10009), " +
                           "            (10011,10008), " +
                           "            (10011,10007), " +
                           "            (10011,10006), " +
                           "            (10010,10005), " +
                           "            (10010,10004), " +
                           "            (10010,10003), " +
                           "            (10009,10002), " +
                           "            (10009,10001), " +
                           "            (10009,10000), " +
                           "            (10008,10001), " +
                           "            (10008,10002), " +
                           "            (10008,10003), " +
                           "            (10007,10004), " +
                           "            (10007,10005), " +
                           "            (10007,10006), " +
                           "            (10006,10007), " +
                           "            (10006,10008), " +
                           "            (10006,10009), " +
                           "            (10005,10010), " +
                           "            (10005,10011), " +
                           "            (10005,10012), " +
                           "            (10004,10013), " +
                           "            (10004,10014), " +
                           "            (10004,10015), " +
                           "            (10003,10016), " +
                           "            (10003,10017), " +
                           "            (10003,10018), " +
                           "            (10002,10019), " +
                           "            (10002,10020), " +
                           "            (10002,10021), " +
                           "            (10001,10022), " +
                           "            (10001,10023), " +
                           "            (10001,10024), " +
                           "            (10000,10025), " +
                           "            (10000,10026), " +
                           "            (10000,10027);";
                        /*
                        command.CommandText =
                            "INSERT INTO [Акції_Країни] VALUES (10000,10000)";
                         */
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Таблицю [Акції_Країни] заповненo успішно");
                    }
                    catch (SqlException e) // якщо заповнення таблиці не получилось
                    {
                        Console.WriteLine(e.Message);

                        Console.Write("\nНатисніть для продовження...");
                        Console.ReadKey(); Console.Clear();
                    }
                }


                Console.ReadKey(); Console.Clear(); 
            }
        }
        catch (Exception e) // якщо БД [Список розсилки] не вдалось створити
        {
            Console.WriteLine(e.Message);

            Console.Write("\nНатисніть для продовження...");
            Console.ReadKey(); Console.Clear();
        }
    }
}