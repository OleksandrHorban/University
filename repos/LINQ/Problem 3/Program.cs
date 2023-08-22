class Problem3
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
                    students.Add(new Student(action[0], action[1], Convert.ToInt32(action[2])));
                }
        }

        var SelectedStudents = from s in students // кожен елемент з students педерається в s
                               where s.Age >= 18 && s.Age <= 24 // при умові що Age в діапазоні від 18 до 24
                               select s; // об'єкт який іде в SelectedStudents

        foreach (var student in SelectedStudents)
        {
            Console.WriteLine(student);
        }
    }
}
