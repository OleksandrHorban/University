using System.Text.RegularExpressions;

class Problem5
{
    static void Main()
    {
        List<Student> students = new();

        while (true)
        {
            string[] action = Console.ReadLine().Split();

            if (action != null)
                if (action[0].ToLower() == "end")
                {
                    Console.WriteLine();
                    break;
                }
                else if (action.Length == 3)
                {
                    students.Add(new Student(action[0], action[1], action[2]));
                }
        }

        var SelectedStudents = from s in students
                               where new Regex(@"@gmail.com").IsMatch(s.Email) // якщо хост емейла gmail.com
                               select s;

        foreach (var student in SelectedStudents)
        {
            Console.WriteLine(student);
        }
    }
}