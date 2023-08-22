using System.Text.RegularExpressions;

class Problem9
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
                else if (action.Length >= 2)
                {
                    int[] temp = new int[action.Length - 1]; // для запису оцінок
                    for (int i = 0; i < temp.Length; i++)
                        temp[i] = Convert.ToInt32(action[i + 1]); // запис оцінки

                    students.Add(new Student(action[0], temp)); // додавання студента
                }
        }

        var SelectedStudents = from s in students
                               where new Regex(@"((14)|(15))$").IsMatch(s.Id) // якщо s.Id закінчується на 14 або 15
                               select s; // то s записуєтся в SelectedStudents

        foreach (var student in SelectedStudents)
        {
            Console.WriteLine(student);
        }
    }
}
