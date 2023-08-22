class Problem4
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
                else if (action.Length == 2)
                {
                    students.Add(new Student(action[0], action[1]));
                }
        }

        var SelectedStudents = students.OrderBy(s => s.LastName) // спочатку по зростанню за прізвищем
                                        .OrderByDescending(s => s.FirstName); // потім по спаданню за іменем

        foreach (var student in SelectedStudents)
        {
            Console.WriteLine(student);
        }
    }
}
