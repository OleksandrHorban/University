using System.Text.RegularExpressions;

class Problem6
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
                               where new Regex(@"^((02)|(\+3592))").IsMatch(s.Phone) // якщо телефон починається на 02 або +3592
                               select s;

        foreach (var student in SelectedStudents)
        {
            Console.WriteLine(student);
        }
    }
}
