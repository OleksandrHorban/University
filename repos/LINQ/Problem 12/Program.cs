class Problem12
{
    static void Main()
    {
        int N = Convert.ToInt32(Console.ReadLine()); // кількість команд

        if (N != null)
        {
            Product[] products = new Product[(int)N]; // виділяється пам'ять для N продуктів

            for (int i = 0; i < N; i++) // записування продуктів
            {
                string[] str = Console.ReadLine().Split('-'); // строка з інформацією про продукт
                for (int j = 0; j < str.Length; j++)
                {
                    str[j] = str[j].Trim().Trim('|'); // забираються зайві символи
                }

                if (str.Length == 3)
                {
                    products[i] = new(str[0], str[2], Convert.ToSingle(str[1]));
                }
            }

            var SelectedProductsInCompany = (from p in products // вибірка з продуктів
                                             group p by p.NameCompany into g // групування за назвою групи
                                             select new // створюється новий об'єкт
                                             {
                                                 NameCompany = g.Key, // ключом буде назва компанії
                                                 product = from s in g // новий продукт, Key - NameProduct
                                                           group s by s.NameProduct // який групується за іменем продукту
                                             }).OrderBy(t => t.NameCompany); // сортування за компанією

            Console.WriteLine();
            foreach (var Company in SelectedProductsInCompany) // прохід по компанії
            {
                Console.Write(Company.NameCompany + ": "); // вивід компанії

                List<string> temp = new(); // для продуктів і їх цін
                foreach (var product in Company.product) // прохід по продуктам
                {
                    float tempPrice = 0.0f; // для сумарної ціни, якщо декілька однакових продуктів

                    foreach (var p in product) // прохід по цінах продукту
                        tempPrice += p.Price; // записується сумарна ціна

                    temp.Add(product.Key + $"-{tempPrice}"); // продукт-ціна
                }

                Console.WriteLine(string.Join(", ", temp)); // вивід продукту <продукт>-<ціна>
            }
        }
    }
}

record class Product(string NameCompany, string NameProduct, float Price);