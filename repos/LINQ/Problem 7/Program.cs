class Problem7
{
    static void Main()
    {
        List<Student> students = new();

        while (true)
        {
            string[] action = Console.ReadLine().Split();

            if (action != null)
                if (action[0].ToLower() == "end") { 
                    Console.WriteLine(); 
                    break; 
                }
                else if (action.Length >= 3)
                {
                    int[] temp = new int[action.Length - 2]; // для запису оцінок
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i] = Convert.ToInt32(action[i + 2]); // запис оцінки
                    }

                    students.Add(new Student(action[0], action[1], temp)); // додавання студента
                }
        }

        var SelectedStudents = from s in students
                               where s.Marks.Where(m => m == 6).Any() // якщо у s.Marks є хоча б одна оцінка Відмінно (6)
                               select s; // то s записуєтся в SelectedStudents


        foreach (var student in SelectedStudents)
        {
            Console.WriteLine(student);
        }
    }
}
