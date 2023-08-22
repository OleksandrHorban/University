class Problem2
{
    static void Main()
    {
        List<Student> students = new();

        while (true)
        {
            string[]? action = Console.ReadLine()?.Split();

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

        var SelectedStudents = from s in students // кожен елемент з students педерається в s
                               where string.Compare(s.FirstName, s.LastName) <= 0 // при умові що FirstName >= LastName
                               select s; // об'єкт який іде в SelectedStudents

        foreach (var student in SelectedStudents)
        {
            Console.WriteLine(student);
        }
    }
}
